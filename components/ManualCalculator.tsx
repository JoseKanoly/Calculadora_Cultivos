"use client"

import { useState, useEffect } from "react"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { ArrowLeft, Beaker } from "lucide-react"
import {
  crops,
  stages,
  nutrients,
  getNutrientRequirement,
  getFertilizersByNutrient,
  getFertilizerConcentration,
} from "@/lib/data"

interface ManualCalculatorProps {
  onBack: () => void
}

export default function ManualCalculator({ onBack }: ManualCalculatorProps) {
  const [crop, setCrop] = useState("")
  const [stage, setStage] = useState("")
  const [nutrient, setNutrient] = useState("")
  const [fertilizer, setFertilizer] = useState("")
  const [area, setArea] = useState("")
  const [requirement, setRequirement] = useState(0)
  const [concentration, setConcentration] = useState(0)
  const [result, setResult] = useState("")
  const [availableFertilizers, setAvailableFertilizers] = useState<string[]>([])

  useEffect(() => {
    if (crop && stage && nutrient) {
      const req = getNutrientRequirement(crop, stage, nutrient)
      setRequirement(req)
    }
  }, [crop, stage, nutrient])

  useEffect(() => {
    if (nutrient) {
      const fertilizers = getFertilizersByNutrient(nutrient)
      setAvailableFertilizers(fertilizers)
      setFertilizer("")
      setConcentration(0)
    }
  }, [nutrient])

  useEffect(() => {
    if (fertilizer && nutrient) {
      const conc = getFertilizerConcentration(fertilizer, nutrient)
      setConcentration(conc)
    }
  }, [fertilizer, nutrient])

  const calculate = () => {
    if (!crop || !stage || !nutrient || !fertilizer || !area) {
      alert("Por favor completa todos los campos")
      return
    }

    const areaNum = Number.parseFloat(area)
    if (areaNum <= 0) {
      alert("El área debe ser mayor a 0")
      return
    }

    if (concentration === 0) {
      alert("Concentración inválida para el fertilizante seleccionado")
      return
    }

    if (requirement === 0) {
      alert("No se encontraron datos para la combinación seleccionada")
      return
    }

    const dose = (requirement * areaNum) / (concentration / 100)

    setResult(
      `Para ${areaNum} ha de ${crop} en etapa de ${stage}, necesitas ${dose.toFixed(2)} kg de ${fertilizer} para aportar ${requirement} kg/ha de ${nutrient}`,
    )
  }

  const clear = () => {
    setCrop("")
    setStage("")
    setNutrient("")
    setFertilizer("")
    setArea("")
    setRequirement(0)
    setConcentration(0)
    setResult("")
    setAvailableFertilizers([])
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-purple-50 to-blue-50 p-4">
      <div className="max-w-4xl mx-auto">
        <div className="flex items-center gap-4 mb-6">
          <Button variant="outline" onClick={onBack}>
            <ArrowLeft className="w-4 h-4 mr-2" />
            Volver al Menú
          </Button>
          <h1 className="text-2xl font-bold text-gray-800">Calculadora Manual</h1>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
          <Card>
            <CardHeader>
              <CardTitle className="flex items-center gap-2">
                <Beaker className="w-5 h-5" />
                Selección Específica
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
                <Label htmlFor="stage">Etapa</Label>
                <Select value={stage} onValueChange={setStage}>
                  <SelectTrigger>
                    <SelectValue placeholder="Selecciona una etapa" />
                  </SelectTrigger>
                  <SelectContent>
                    {stages.map((s) => (
                      <SelectItem key={s} value={s}>
                        {s}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
              </div>

              <div className="space-y-2">
                <Label htmlFor="nutrient">Nutriente</Label>
                <Select value={nutrient} onValueChange={setNutrient}>
                  <SelectTrigger>
                    <SelectValue placeholder="Selecciona un nutriente" />
                  </SelectTrigger>
                  <SelectContent>
                    {nutrients.map((n) => (
                      <SelectItem key={n} value={n}>
                        {n}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
              </div>

              <div className="space-y-2">
                <Label htmlFor="fertilizer">Fertilizante</Label>
                <Select value={fertilizer} onValueChange={setFertilizer} disabled={!nutrient}>
                  <SelectTrigger>
                    <SelectValue placeholder="Selecciona un fertilizante" />
                  </SelectTrigger>
                  <SelectContent>
                    {availableFertilizers.map((f) => (
                      <SelectItem key={f} value={f}>
                        {f}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
              </div>

              <div className="space-y-2">
                <Label htmlFor="area">Área (hectáreas)</Label>
                <Input
                  id="area"
                  type="number"
                  step="0.1"
                  min="0"
                  value={area}
                  onChange={(e) => setArea(e.target.value)}
                  placeholder="Ej: 1.5"
                />
              </div>

              <div className="grid grid-cols-2 gap-4">
                <div className="p-3 bg-blue-50 border border-blue-200 rounded-lg">
                  <p className="text-sm text-blue-600">Requerimiento:</p>
                  <p className="font-semibold text-blue-800">{requirement > 0 ? `${requirement} kg/ha` : "N/A"}</p>
                </div>
                <div className="p-3 bg-green-50 border border-green-200 rounded-lg">
                  <p className="text-sm text-green-600">Concentración:</p>
                  <p className="font-semibold text-green-800">{concentration > 0 ? `${concentration}%` : "N/A"}</p>
                </div>
              </div>

              <div className="flex gap-4">
                <Button onClick={calculate} className="flex-1">
                  Calcular
                </Button>
                <Button onClick={clear} variant="outline">
                  Limpiar
                </Button>
              </div>
            </CardContent>
          </Card>

          <Card>
            <CardHeader>
              <CardTitle>Resultado</CardTitle>
            </CardHeader>
            <CardContent>
              {result ? (
                <div className="p-4 bg-green-50 border border-green-200 rounded-lg">
                  <p className="text-green-800">{result}</p>
                </div>
              ) : (
                <p className="text-gray-500 text-center py-8">
                  Completa todos los campos y haz clic en "Calcular" para ver el resultado
                </p>
              )}
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  )
}
