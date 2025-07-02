"use client"

import { useState } from "react"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { ArrowLeft, Calculator } from "lucide-react"
import { crops, fertilizers } from "@/lib/data"

interface BasicCalculatorProps {
  onBack: () => void
}

export default function BasicCalculator({ onBack }: BasicCalculatorProps) {
  const [crop, setCrop] = useState("")
  const [age, setAge] = useState("")
  const [fertilizer, setFertilizer] = useState("")
  const [result, setResult] = useState("")

  const calculate = () => {
    if (!crop || !age || !fertilizer) {
      alert("Por favor completa todos los campos")
      return
    }

    const ageNum = Number.parseFloat(age)
    if (ageNum <= 0) {
      alert("La edad debe ser mayor a 0")
      return
    }

    // Determinar dosis base según cultivo y edad
    let baseDose = 0

    if (["Cacao", "Café"].includes(crop)) {
      if (ageNum <= 1) baseDose = 40
      else if (ageNum <= 2.5) baseDose = 60
      else baseDose = 80
    } else if (["Maíz", "Arroz"].includes(crop)) {
      if (ageNum <= 0.5) baseDose = 50
      else if (ageNum <= 1) baseDose = 80
      else baseDose = 70
    } else if (crop === "Plátano") {
      if (ageNum <= 0.5) baseDose = 60
      else if (ageNum <= 1) baseDose = 90
      else baseDose = 110
    } else {
      // Para otros cultivos
      if (ageNum <= 0.5) baseDose = 45
      else if (ageNum <= 1) baseDose = 70
      else baseDose = 85
    }

    // Obtener porcentaje del fertilizante
    const fertilizerData = fertilizers.find((f) => f.name === fertilizer)
    const percentage = fertilizerData?.concentration || 15

    // Calcular resultado
    const needed = baseDose / (percentage / 100)

    setResult(`Necesitas ${needed.toFixed(2)} kg/ha de ${fertilizer}`)
  }

  const clear = () => {
    setCrop("")
    setAge("")
    setFertilizer("")
    setResult("")
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 to-green-50 p-4">
      <div className="max-w-2xl mx-auto">
        <div className="flex items-center gap-4 mb-6">
          <Button variant="outline" onClick={onBack}>
            <ArrowLeft className="w-4 h-4 mr-2" />
            Volver al Menú
          </Button>
          <h1 className="text-2xl font-bold text-gray-800">Calculadora Básica</h1>
        </div>

        <Card>
          <CardHeader>
            <CardTitle className="flex items-center gap-2">
              <Calculator className="w-5 h-5" />
              Cálculo Simple de Fertilizantes
            </CardTitle>
          </CardHeader>
          <CardContent className="space-y-6">
            <div className="space-y-2">
              <Label htmlFor="crop">Cultivo</Label>
              <Select value={crop} onValueChange={setCrop}>
                <SelectTrigger>
                  <SelectValue placeholder="Selecciona un cultivo" />
                </SelectTrigger>
                <SelectContent>
                  {crops.map((c) => (
                    <SelectItem key={c} value={c}>
                      {c}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>

            <div className="space-y-2">
              <Label htmlFor="age">Edad del Cultivo (años)</Label>
              <Input
                id="age"
                type="number"
                step="0.1"
                min="0"
                value={age}
                onChange={(e) => setAge(e.target.value)}
                placeholder="Ej: 1.5"
              />
            </div>

            <div className="space-y-2">
              <Label htmlFor="fertilizer">Fertilizante</Label>
              <Select value={fertilizer} onValueChange={setFertilizer}>
                <SelectTrigger>
                  <SelectValue placeholder="Selecciona un fertilizante" />
                </SelectTrigger>
                <SelectContent>
                  {fertilizers.map((f) => (
                    <SelectItem key={f.name} value={f.name}>
                      {f.name} ({f.concentration}%)
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>

            <div className="flex gap-4">
              <Button onClick={calculate} className="flex-1">
                Calcular
              </Button>
              <Button onClick={clear} variant="outline">
                Limpiar
              </Button>
            </div>

            {result && (
              <div className="p-4 bg-green-50 border border-green-200 rounded-lg">
                <p className="text-green-800 font-medium">{result}</p>
              </div>
            )}
          </CardContent>
        </Card>
      </div>
    </div>
  )
}
