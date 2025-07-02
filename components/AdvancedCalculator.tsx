"use client"

import { useState } from "react"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import { ArrowLeft, FileText, Download } from "lucide-react"
import { crops, stages, getNutrientRequirement } from "@/lib/data"

interface AdvancedCalculatorProps {
  onBack: () => void
}

export default function AdvancedCalculator({ onBack }: AdvancedCalculatorProps) {
  const [crop, setCrop] = useState("")
  const [stage, setStage] = useState("")
  const [area, setArea] = useState("")
  const [soilN, setSoilN] = useState("")
  const [soilP, setSoilP] = useState("")
  const [soilK, setSoilK] = useState("")
  const [priceUrea, setPriceUrea] = useState("0.50")
  const [priceDAP, setPriceDAP] = useState("0.80")
  const [priceKCl, setPriceKCl] = useState("0.60")
  const [results, setResults] = useState<any>(null)
  const [recommendations, setRecommendations] = useState("")

  const calculate = () => {
    if (!crop || !stage || !area || !soilN || !soilP || !soilK) {
      alert("Por favor completa todos los campos")
      return
    }

    const areaNum = Number.parseFloat(area)
    const nSoil = Number.parseFloat(soilN)
    const pSoil = Number.parseFloat(soilP)
    const kSoil = Number.parseFloat(soilK)

    if (areaNum <= 0 || nSoil < 0 || pSoil < 0 || kSoil < 0) {
      alert("Por favor ingresa valores válidos")
      return
    }

    // Obtener requerimientos del cultivo
    const nRequired = getNutrientRequirement(crop, stage, "Nitrógeno (N)")
    const pRequired = getNutrientRequirement(crop, stage, "Fósforo (P2O5)")
    const kRequired = getNutrientRequirement(crop, stage, "Potasio (K2O)")

    // Calcular nutrientes necesarios (requerido - disponible en suelo)
    const nNeeded = Math.max(0, nRequired - nSoil)
    const pNeeded = Math.max(0, pRequired - pSoil)
    const kNeeded = Math.max(0, kRequired - kSoil)

    // Calcular fertilizantes necesarios
    const urea = (areaNum * nNeeded) / 0.46 // Urea 46% N
    const dap = (areaNum * pNeeded) / 0.46 // DAP 46% P2O5
    const kcl = (areaNum * kNeeded) / 0.6 // KCl 60% K2O

    // Calcular costo total
    const totalCost =
      urea * Number.parseFloat(priceUrea) + dap * Number.parseFloat(priceDAP) + kcl * Number.parseFloat(priceKCl)

    setResults({
      required: { n: nRequired, p: pRequired, k: kRequired },
      needed: { n: nNeeded, p: pNeeded, k: kNeeded },
      fertilizers: { urea, dap, kcl },
      cost: totalCost,
    })

    // Generar recomendaciones
    generateRecommendations(nSoil, pSoil, kSoil, nRequired, pRequired, kRequired)
  }

  const generateRecommendations = (
    nSoil: number,
    pSoil: number,
    kSoil: number,
    nReq: number,
    pReq: number,
    kReq: number,
  ) => {
    let rec = "RECOMENDACIONES:\n\n"

    // Análisis de Nitrógeno
    if (nSoil < nReq * 0.3) {
      rec += "• Nitrógeno: Nivel BAJO. Aplicar fertilización completa.\n"
    } else if (nSoil < nReq * 0.7) {
      rec += "• Nitrógeno: Nivel MEDIO. Aplicar fertilización moderada.\n"
    } else {
      rec += "• Nitrógeno: Nivel ALTO. Reducir aplicación.\n"
    }

    // Análisis de Fósforo
    if (pSoil < pReq * 0.3) {
      rec += "• Fósforo: Nivel BAJO. Aplicar fertilización completa.\n"
    } else if (pSoil < pReq * 0.7) {
      rec += "• Fósforo: Nivel MEDIO. Aplicar fertilización moderada.\n"
    } else {
      rec += "• Fósforo: Nivel ALTO. Reducir aplicación.\n"
    }

    // Análisis de Potasio
    if (kSoil < kReq * 0.3) {
      rec += "• Potasio: Nivel BAJO. Aplicar fertilización completa.\n"
    } else if (kSoil < kReq * 0.7) {
      rec += "• Potasio: Nivel MEDIO. Aplicar fertilización moderada.\n"
    } else {
      rec += "• Potasio: Nivel ALTO. Reducir aplicación.\n"
    }

    rec += "\nAplicar fertilizantes en 2-3 fracciones durante el ciclo del cultivo."

    setRecommendations(rec)
  }

  const clear = () => {
    setCrop("")
    setStage("")
    setArea("")
    setSoilN("")
    setSoilP("")
    setSoilK("")
    setPriceUrea("0.50")
    setPriceDAP("0.80")
    setPriceKCl("0.60")
    setResults(null)
    setRecommendations("")
  }

  const exportResults = () => {
    if (!results) {
      alert("Primero realiza un cálculo")
      return
    }

    const data = {
      fecha: new Date().toLocaleDateString(),
      cultivo: crop,
      etapa: stage,
      area: area,
      resultados: results,
      recomendaciones: recommendations,
    }

    const blob = new Blob([JSON.stringify(data, null, 2)], { type: "application/json" })
    const url = URL.createObjectURL(blob)
    const a = document.createElement("a")
    a.href = url
    a.download = `analisis_${crop}_${new Date().toISOString().split("T")[0]}.json`
    a.click()
    URL.revokeObjectURL(url)
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-orange-50 to-red-50 p-4">
      <div className="max-w-6xl mx-auto">
        <div className="flex items-center gap-4 mb-6">
          <Button variant="outline" onClick={onBack}>
            <ArrowLeft className="w-4 h-4 mr-2" />
            Volver al Menú
          </Button>
          <h1 className="text-2xl font-bold text-gray-800">Calculadora Avanzada</h1>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
          <div className="space-y-6">
            <Card>
              <CardHeader>
                <CardTitle className="flex items-center gap-2">
                  <FileText className="w-5 h-5" />
                  Datos del Cultivo
                </CardTitle>
              </CardHeader>
              <CardContent className="space-y-4">
                <div className="grid grid-cols-2 gap-4">
                  <div className="space-y-2">
                    <Label>Cultivo</Label>
                    <Select value={crop} onValueChange={setCrop}>
                      <SelectTrigger>
                        <SelectValue placeholder="Seleccionar" />
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
                    <Label>Etapa</Label>
                    <Select value={stage} onValueChange={setStage}>
                      <SelectTrigger>
                        <SelectValue placeholder="Seleccionar" />
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
                </div>
                <div className="space-y-2">
                  <Label>Área (hectáreas)</Label>
                  <Input
                    type="number"
                    step="0.1"
                    min="0"
                    value={area}
                    onChange={(e) => setArea(e.target.value)}
                    placeholder="Ej: 2.5"
                  />
                </div>
              </CardContent>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle>Análisis de Suelo (kg/ha)</CardTitle>
              </CardHeader>
              <CardContent>
                <div className="grid grid-cols-3 gap-4">
                  <div className="space-y-2">
                    <Label>N disponible</Label>
                    <Input
                      type="number"
                      min="0"
                      value={soilN}
                      onChange={(e) => setSoilN(e.target.value)}
                      placeholder="0"
                    />
                  </div>
                  <div className="space-y-2">
                    <Label>P disponible</Label>
                    <Input
                      type="number"
                      min="0"
                      value={soilP}
                      onChange={(e) => setSoilP(e.target.value)}
                      placeholder="0"
                    />
                  </div>
                  <div className="space-y-2">
                    <Label>K disponible</Label>
                    <Input
                      type="number"
                      min="0"
                      value={soilK}
                      onChange={(e) => setSoilK(e.target.value)}
                      placeholder="0"
                    />
                  </div>
                </div>
              </CardContent>
            </Card>

            <Card>
              <CardHeader>
                <CardTitle>Precios ($/kg)</CardTitle>
              </CardHeader>
              <CardContent>
                <div className="grid grid-cols-3 gap-4">
                  <div className="space-y-2">
                    <Label>Urea</Label>
                    <Input
                      type="number"
                      step="0.01"
                      min="0"
                      value={priceUrea}
                      onChange={(e) => setPriceUrea(e.target.value)}
                    />
                  </div>
                  <div className="space-y-2">
                    <Label>DAP</Label>
                    <Input
                      type="number"
                      step="0.01"
                      min="0"
                      value={priceDAP}
                      onChange={(e) => setPriceDAP(e.target.value)}
                    />
                  </div>
                  <div className="space-y-2">
                    <Label>KCl</Label>
                    <Input
                      type="number"
                      step="0.01"
                      min="0"
                      value={priceKCl}
                      onChange={(e) => setPriceKCl(e.target.value)}
                    />
                  </div>
                </div>
              </CardContent>
            </Card>

            <div className="flex gap-4">
              <Button onClick={calculate} className="flex-1">
                Calcular
              </Button>
              <Button onClick={clear} variant="outline">
                Limpiar
              </Button>
              <Button onClick={exportResults} variant="outline" disabled={!results}>
                <Download className="w-4 h-4 mr-2" />
                Exportar
              </Button>
            </div>
          </div>

          <div className="space-y-6">
            {results && (
              <>
                <Card>
                  <CardHeader>
                    <CardTitle>Requerimientos vs Necesidades</CardTitle>
                  </CardHeader>
                  <CardContent>
                    <div className="space-y-4">
                      <div className="grid grid-cols-3 gap-4 text-center">
                        <div className="p-3 bg-blue-50 border border-blue-200 rounded-lg">
                          <p className="text-sm text-blue-600">N Requerido</p>
                          <p className="font-bold text-blue-800">{results.required.n} kg/ha</p>
                        </div>
                        <div className="p-3 bg-green-50 border border-green-200 rounded-lg">
                          <p className="text-sm text-green-600">P Requerido</p>
                          <p className="font-bold text-green-800">{results.required.p} kg/ha</p>
                        </div>
                        <div className="p-3 bg-purple-50 border border-purple-200 rounded-lg">
                          <p className="text-sm text-purple-600">K Requerido</p>
                          <p className="font-bold text-purple-800">{results.required.k} kg/ha</p>
                        </div>
                      </div>

                      <div className="grid grid-cols-3 gap-4 text-center">
                        <div className="p-3 bg-orange-50 border border-orange-200 rounded-lg">
                          <p className="text-sm text-orange-600">N a Aplicar</p>
                          <p className="font-bold text-orange-800">{results.needed.n.toFixed(1)} kg/ha</p>
                        </div>
                        <div className="p-3 bg-red-50 border border-red-200 rounded-lg">
                          <p className="text-sm text-red-600">P a Aplicar</p>
                          <p className="font-bold text-red-800">{results.needed.p.toFixed(1)} kg/ha</p>
                        </div>
                        <div className="p-3 bg-yellow-50 border border-yellow-200 rounded-lg">
                          <p className="text-sm text-yellow-600">K a Aplicar</p>
                          <p className="font-bold text-yellow-800">{results.needed.k.toFixed(1)} kg/ha</p>
                        </div>
                      </div>
                    </div>
                  </CardContent>
                </Card>

                <Card>
                  <CardHeader>
                    <CardTitle>Fertilizantes y Costo</CardTitle>
                  </CardHeader>
                  <CardContent>
                    <div className="space-y-3">
                      <div className="flex justify-between items-center p-3 bg-gray-50 rounded-lg">
                        <span>Urea (46% N):</span>
                        <span className="font-bold">{results.fertilizers.urea.toFixed(2)} kg</span>
                      </div>
                      <div className="flex justify-between items-center p-3 bg-gray-50 rounded-lg">
                        <span>DAP (46% P2O5):</span>
                        <span className="font-bold">{results.fertilizers.dap.toFixed(2)} kg</span>
                      </div>
                      <div className="flex justify-between items-center p-3 bg-gray-50 rounded-lg">
                        <span>KCl (60% K2O):</span>
                        <span className="font-bold">{results.fertilizers.kcl.toFixed(2)} kg</span>
                      </div>
                      <div className="flex justify-between items-center p-4 bg-green-100 border border-green-300 rounded-lg">
                        <span className="font-semibold text-green-800">Costo Total:</span>
                        <span className="text-xl font-bold text-green-800">${results.cost.toFixed(2)}</span>
                      </div>
                    </div>
                  </CardContent>
                </Card>
              </>
            )}

            {recommendations && (
              <Card>
                <CardHeader>
                  <CardTitle>Recomendaciones</CardTitle>
                </CardHeader>
                <CardContent>
                  <Textarea value={recommendations} readOnly className="min-h-[200px] resize-none" />
                </CardContent>
              </Card>
            )}
          </div>
        </div>
      </div>
    </div>
  )
}
