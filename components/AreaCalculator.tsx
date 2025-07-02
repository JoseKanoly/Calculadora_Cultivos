"use client"

import { useState, useEffect } from "react"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { ArrowLeft, BarChart3 } from "lucide-react"
import { crops, stages, getNutrientRequirement } from "@/lib/data"

interface AreaCalculatorProps {
  onBack: () => void
}

export default function AreaCalculator({ onBack }: AreaCalculatorProps) {
  const [crop, setCrop] = useState("")
  const [stage, setStage] = useState("")
  const [area, setArea] = useState("")
  const [requirements, setRequirements] = useState({ n: 0, p: 0, k: 0 })
  const [results, setResults] = useState({ urea: 0, dap: 0, kcl: 0, cost: 0 })

  useEffect(() => {
    if (crop && stage) {
      const n = getNutrientRequirement(crop, stage, "Nitrógeno (N)")
      const p = getNutrientRequirement(crop, stage, "Fósforo (P2O5)")
      const k = getNutrientRequirement(crop, stage, "Potasio (K2O)")
      setRequirements({ n, p, k })
    }
  }, [crop, stage])

  const calculate = () => {
    if (!crop || !stage || !area) {
      alert("Por favor completa todos los campos")
      return
    }

    const areaNum = Number.parseFloat(area)
    if (areaNum <= 0) {
      alert("El área debe ser mayor a 0")
      return
    }

    const urea = (areaNum * requirements.n) / 0.46 // Urea 46% N
    const dap = (areaNum * requirements.p) / 0.46 // DAP 46% P2O5
    const kcl = (areaNum * requirements.k) / 0.6 // KCl 60% K2O

    // Precios estimados por kg
    const cost = urea * 0.5 + dap * 0.8 + kcl * 0.6

    setResults({ urea, dap, kcl, cost })
  }

  const clear = () => {
    setCrop("")
    setStage("")
    setArea("")
    setRequirements({ n: 0, p: 0, k: 0 })
    setResults({ urea: 0, dap: 0, kcl: 0, cost: 0 })
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-green-50 to-blue-50 p-4">
      <div className="max-w-4xl mx-auto">
        <div className="flex items-center gap-4 mb-6">
          <Button variant="outline" onClick={onBack}>
            <ArrowLeft className="w-4 h-4 mr-2" />
            Volver al Menú
          </Button>
          <h1 className="text-2xl font-bold text-gray-800">Calculadora por Área</h1>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
          <Card>
            <CardHeader>
              <CardTitle className="flex items-center gap-2">
                <BarChart3 className="w-5 h-5" />
                Datos del Cultivo
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
                <Label htmlFor="area">Área (hectáreas)</Label>
                <Input
                  id="area"
                  type="number"
                  step="0.1"
                  min="0"
                  value={area}
                  onChange={(e) => setArea(e.target.value)}
                  placeholder="Ej: 2.5"
                />
              </div>

              {crop && stage && (
                <div className="p-4 bg-blue-50 border border-blue-200 rounded-lg">
                  <h4 className="font-semibold text-blue-800 mb-2">Requerimientos:</h4>
                  <div className="space-y-1 text-sm">
                    <p>N: {requirements.n} kg/ha</p>
                    <p>P2O5: {requirements.p} kg/ha</p>
                    <p>K2O: {requirements.k} kg/ha</p>
                  </div>
                </div>
              )}

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
              <CardTitle>Resultados</CardTitle>
            </CardHeader>
            <CardContent>
              {results.urea > 0 ? (
                <div className="space-y-4">
                  <div className="p-4 bg-green-50 border border-green-200 rounded-lg">
                    <h4 className="font-semibold text-green-800 mb-3">Fertilizantes Necesarios:</h4>
                    <div className="space-y-2">
                      <p className="flex justify-between">
                        <span>Urea (46% N):</span>
                        <span className="font-medium">{results.urea.toFixed(2)} kg</span>
                      </p>
                      <p className="flex justify-between">
                        <span>DAP (46% P2O5):</span>
                        <span className="font-medium">{results.dap.toFixed(2)} kg</span>
                      </p>
                      <p className="flex justify-between">
                        <span>KCl (60% K2O):</span>
                        <span className="font-medium">{results.kcl.toFixed(2)} kg</span>
                      </p>
                    </div>
                  </div>

                  <div className="p-4 bg-yellow-50 border border-yellow-200 rounded-lg">
                    <p className="flex justify-between items-center">
                      <span className="font-semibold text-yellow-800">Costo Estimado:</span>
                      <span className="text-xl font-bold text-yellow-800">${results.cost.toFixed(2)}</span>
                    </p>
                  </div>
                </div>
              ) : (
                <p className="text-gray-500 text-center py-8">
                  Completa los datos y haz clic en "Calcular" para ver los resultados
                </p>
              )}
            </CardContent>
          </Card>
        </div>
      </div>
    </div>
  )
}
