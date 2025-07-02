"use client"

import { useState } from "react"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import { ArrowLeft, GitCompare, ArrowLeftRight, BarChart } from "lucide-react"
import { crops, stages, getNutrientRequirement } from "@/lib/data"

interface CropComparatorProps {
  onBack: () => void
}

export default function CropComparator({ onBack }: CropComparatorProps) {
  const [crop1, setCrop1] = useState("")
  const [crop2, setCrop2] = useState("")
  const [stage, setStage] = useState("")
  const [results, setResults] = useState<any>(null)
  const [analysis, setAnalysis] = useState("")

  const compare = () => {
    if (!crop1 || !crop2 || !stage) {
      alert("Por favor completa todos los campos")
      return
    }

    if (crop1 === crop2) {
      alert("Selecciona cultivos diferentes para comparar")
      return
    }

    // Obtener requerimientos para ambos cultivos
    const crop1Data = {
      n: getNutrientRequirement(crop1, stage, "Nitrógeno (N)"),
      p: getNutrientRequirement(crop1, stage, "Fósforo (P2O5)"),
      k: getNutrientRequirement(crop1, stage, "Potasio (K2O)"),
      ca: getNutrientRequirement(crop1, stage, "Calcio (Ca)"),
      mg: getNutrientRequirement(crop1, stage, "Magnesio (Mg)"),
    }

    const crop2Data = {
      n: getNutrientRequirement(crop2, stage, "Nitrógeno (N)"),
      p: getNutrientRequirement(crop2, stage, "Fósforo (P2O5)"),
      k: getNutrientRequirement(crop2, stage, "Potasio (K2O)"),
      ca: getNutrientRequirement(crop2, stage, "Calcio (Ca)"),
      mg: getNutrientRequirement(crop2, stage, "Magnesio (Mg)"),
    }

    // Calcular diferencias
    const differences = {
      n: crop2Data.n - crop1Data.n,
      p: crop2Data.p - crop1Data.p,
      k: crop2Data.k - crop1Data.k,
      ca: crop2Data.ca - crop1Data.ca,
      mg: crop2Data.mg - crop1Data.mg,
    }

    setResults({ crop1Data, crop2Data, differences })
    generateAnalysis(crop1, crop2, stage, crop1Data, crop2Data, differences)
  }

  const generateAnalysis = (c1: string, c2: string, st: string, data1: any, data2: any, diff: any) => {
    const total1 = data1.n + data1.p + data1.k
    const total2 = data2.n + data2.p + data2.k

    let analysisText = `ANÁLISIS COMPARATIVO\n\nEtapa: ${st}\n\n`

    // Análisis de requerimientos totales
    if (total2 > total1) {
      const percentage = ((total2 / total1 - 1) * 100).toFixed(1)
      analysisText += `• ${c2} requiere ${percentage}% más nutrientes que ${c1}\n`
    } else if (total1 > total2) {
      const percentage = ((total1 / total2 - 1) * 100).toFixed(1)
      analysisText += `• ${c1} requiere ${percentage}% más nutrientes que ${c2}\n`
    } else {
      analysisText += `• Ambos cultivos tienen requerimientos similares\n`
    }

    analysisText += `\nDIFERENCIAS PRINCIPALES:\n`

    // Análisis por nutriente
    if (Math.abs(diff.n) > 10) {
      if (diff.n > 0) {
        analysisText += `• ${c2} necesita ${diff.n.toFixed(1)} kg/ha más de Nitrógeno\n`
      } else {
        analysisText += `• ${c1} necesita ${Math.abs(diff.n).toFixed(1)} kg/ha más de Nitrógeno\n`
      }
    }

    if (Math.abs(diff.p) > 5) {
      if (diff.p > 0) {
        analysisText += `• ${c2} necesita ${diff.p.toFixed(1)} kg/ha más de Fósforo\n`
      } else {
        analysisText += `• ${c1} necesita ${Math.abs(diff.p).toFixed(1)} kg/ha más de Fósforo\n`
      }
    }

    if (Math.abs(diff.k) > 10) {
      if (diff.k > 0) {
        analysisText += `• ${c2} necesita ${diff.k.toFixed(1)} kg/ha más de Potasio\n`
      } else {
        analysisText += `• ${c1} necesita ${Math.abs(diff.k).toFixed(1)} kg/ha más de Potasio\n`
      }
    }

    analysisText += `\nRECOMENDACIONES:\n`

    if (total2 > total1 * 1.5) {
      analysisText += `• ${c2} es significativamente más exigente nutricionalmente\n`
    } else if (total1 > total2 * 1.5) {
      analysisText += `• ${c1} es significativamente más exigente nutricionalmente\n`
    }

    analysisText += `• Considerar las diferencias nutricionales al planificar la fertilización\n`
    analysisText += `• Ajustar las dosis según los requerimientos específicos de cada cultivo`

    setAnalysis(analysisText)
  }

  const swapCrops = () => {
    const temp = crop1
    setCrop1(crop2)
    setCrop2(temp)

    if (stage && crop1 && crop2) {
      setTimeout(compare, 100)
    }
  }

  const clear = () => {
    setCrop1("")
    setCrop2("")
    setStage("")
    setResults(null)
    setAnalysis("")
  }

  const getDifferenceColor = (value: number) => {
    if (value > 0) return "text-green-600"
    if (value < 0) return "text-red-600"
    return "text-gray-600"
  }

  const formatDifference = (value: number) => {
    return value >= 0 ? `+${value.toFixed(1)}` : value.toFixed(1)
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-red-50 to-pink-50 p-4">
      <div className="max-w-7xl mx-auto">
        <div className="flex items-center gap-4 mb-6">
          <Button variant="outline" onClick={onBack}>
            <ArrowLeft className="w-4 h-4 mr-2" />
            Volver al Menú
          </Button>
          <h1 className="text-2xl font-bold text-gray-800">Comparador de Cultivos</h1>
        </div>

        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
          <Card className="lg:col-span-3">
            <CardHeader>
              <CardTitle className="flex items-center gap-2">
                <GitCompare className="w-5 h-5" />
                Selección de Cultivos
              </CardTitle>
            </CardHeader>
            <CardContent>
              <div className="flex items-center gap-4">
                <div className="flex-1 space-y-2">
                  <Label>Cultivo 1</Label>
                  <Select value={crop1} onValueChange={setCrop1}>
                    <SelectTrigger>
                      <SelectValue placeholder="Seleccionar cultivo" />
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

                <Button
                  variant="outline"
                  size="sm"
                  onClick={swapCrops}
                  className="mt-6 bg-transparent"
                  disabled={!crop1 || !crop2}
                >
                  <ArrowLeftRight className="w-4 h-4" />
                </Button>

                <div className="flex-1 space-y-2">
                  <Label>Cultivo 2</Label>
                  <Select value={crop2} onValueChange={setCrop2}>
                    <SelectTrigger>
                      <SelectValue placeholder="Seleccionar cultivo" />
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

                <div className="flex-1 space-y-2">
                  <Label>Etapa</Label>
                  <Select value={stage} onValueChange={setStage}>
                    <SelectTrigger>
                      <SelectValue placeholder="Seleccionar etapa" />
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

              <div className="flex gap-4 mt-6">
                <Button onClick={compare} className="flex-1">
                  <GitCompare className="w-4 h-4 mr-2" />
                  Comparar
                </Button>
                <Button onClick={clear} variant="outline">
                  Limpiar
                </Button>
              </div>
            </CardContent>
          </Card>

          {results && (
            <>
              <Card>
                <CardHeader>
                  <CardTitle className="text-center text-blue-600">{crop1}</CardTitle>
                </CardHeader>
                <CardContent>
                  <div className="space-y-3">
                    <div className="flex justify-between">
                      <span>N:</span>
                      <span className="font-bold">{results.crop1Data.n} kg/ha</span>
                    </div>
                    <div className="flex justify-between">
                      <span>P2O5:</span>
                      <span className="font-bold">{results.crop1Data.p} kg/ha</span>
                    </div>
                    <div className="flex justify-between">
                      <span>K2O:</span>
                      <span className="font-bold">{results.crop1Data.k} kg/ha</span>
                    </div>
                    <div className="flex justify-between">
                      <span>Ca:</span>
                      <span className="font-bold">{results.crop1Data.ca} kg/ha</span>
                    </div>
                    <div className="flex justify-between">
                      <span>Mg:</span>
                      <span className="font-bold">{results.crop1Data.mg} kg/ha</span>
                    </div>
                  </div>
                </CardContent>
              </Card>

              <Card>
                <CardHeader>
                  <CardTitle className="text-center text-purple-600">Diferencias</CardTitle>
                </CardHeader>
                <CardContent>
                  <div className="space-y-3">
                    <div className="flex justify-between">
                      <span>Δ N:</span>
                      <span className={`font-bold ${getDifferenceColor(results.differences.n)}`}>
                        {formatDifference(results.differences.n)} kg/ha
                      </span>
                    </div>
                    <div className="flex justify-between">
                      <span>Δ P2O5:</span>
                      <span className={`font-bold ${getDifferenceColor(results.differences.p)}`}>
                        {formatDifference(results.differences.p)} kg/ha
                      </span>
                    </div>
                    <div className="flex justify-between">
                      <span>Δ K2O:</span>
                      <span className={`font-bold ${getDifferenceColor(results.differences.k)}`}>
                        {formatDifference(results.differences.k)} kg/ha
                      </span>
                    </div>
                    <div className="flex justify-between">
                      <span>Δ Ca:</span>
                      <span className={`font-bold ${getDifferenceColor(results.differences.ca)}`}>
                        {formatDifference(results.differences.ca)} kg/ha
                      </span>
                    </div>
                    <div className="flex justify-between">
                      <span>Δ Mg:</span>
                      <span className={`font-bold ${getDifferenceColor(results.differences.mg)}`}>
                        {formatDifference(results.differences.mg)} kg/ha
                      </span>
                    </div>
                  </div>
                </CardContent>
              </Card>

              <Card>
                <CardHeader>
                  <CardTitle className="text-center text-green-600">{crop2}</CardTitle>
                </CardHeader>
                <CardContent>
                  <div className="space-y-3">
                    <div className="flex justify-between">
                      <span>N:</span>
                      <span className="font-bold">{results.crop2Data.n} kg/ha</span>
                    </div>
                    <div className="flex justify-between">
                      <span>P2O5:</span>
                      <span className="font-bold">{results.crop2Data.p} kg/ha</span>
                    </div>
                    <div className="flex justify-between">
                      <span>K2O:</span>
                      <span className="font-bold">{results.crop2Data.k} kg/ha</span>
                    </div>
                    <div className="flex justify-between">
                      <span>Ca:</span>
                      <span className="font-bold">{results.crop2Data.ca} kg/ha</span>
                    </div>
                    <div className="flex justify-between">
                      <span>Mg:</span>
                      <span className="font-bold">{results.crop2Data.mg} kg/ha</span>
                    </div>
                  </div>
                </CardContent>
              </Card>

              {analysis && (
                <Card className="lg:col-span-3">
                  <CardHeader>
                    <CardTitle className="flex items-center gap-2">
                      <BarChart className="w-5 h-5" />
                      Análisis Comparativo
                    </CardTitle>
                  </CardHeader>
                  <CardContent>
                    <Textarea value={analysis} readOnly className="min-h-[300px] resize-none font-mono text-sm" />
                  </CardContent>
                </Card>
              )}
            </>
          )}
        </div>
      </div>
    </div>
  )
}
