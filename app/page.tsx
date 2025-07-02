"use client"

import { useState } from "react"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Calculator, Beaker, BarChart3, GitCompare, FileText } from "lucide-react"
import BasicCalculator from "@/components/BasicCalculator"
import AreaCalculator from "@/components/AreaCalculator"
import ManualCalculator from "@/components/ManualCalculator"
import AdvancedCalculator from "@/components/AdvancedCalculator"
import CropComparator from "@/components/CropComparator"

type CalculatorType = "menu" | "basic" | "area" | "manual" | "advanced" | "compare"

export default function NutrientCalculator() {
  const [activeCalculator, setActiveCalculator] = useState<CalculatorType>("menu")

  const calculators = [
    {
      id: "basic" as CalculatorType,
      title: "Calculadora Básica",
      description: "Cálculo simple basado en edad del cultivo",
      icon: Calculator,
      color: "bg-blue-500",
    },
    {
      id: "area" as CalculatorType,
      title: "Calculadora por Área",
      description: "Cálculo preciso por hectáreas cultivadas",
      icon: BarChart3,
      color: "bg-green-500",
    },
    {
      id: "manual" as CalculatorType,
      title: "Calculadora Manual",
      description: "Selección específica de nutrientes",
      icon: Beaker,
      color: "bg-purple-500",
    },
    {
      id: "advanced" as CalculatorType,
      title: "Calculadora Avanzada",
      description: "Análisis de suelo y recomendaciones",
      icon: FileText,
      color: "bg-orange-500",
    },
    {
      id: "compare" as CalculatorType,
      title: "Comparador de Cultivos",
      description: "Compara requerimientos entre cultivos",
      icon: GitCompare,
      color: "bg-red-500",
    },
  ]

  const renderCalculator = () => {
    switch (activeCalculator) {
      case "basic":
        return <BasicCalculator onBack={() => setActiveCalculator("menu")} />
      case "area":
        return <AreaCalculator onBack={() => setActiveCalculator("menu")} />
      case "manual":
        return <ManualCalculator onBack={() => setActiveCalculator("menu")} />
      case "advanced":
        return <AdvancedCalculator onBack={() => setActiveCalculator("menu")} />
      case "compare":
        return <CropComparator onBack={() => setActiveCalculator("menu")} />
      default:
        return (
          <div className="min-h-screen bg-gradient-to-br from-green-50 to-blue-50 p-4">
            <div className="max-w-6xl mx-auto">
              <div className="text-center mb-8">
                <h1 className="text-4xl font-bold text-gray-800 mb-4">🌱 Calculadora de Nutrientes para Cultivos</h1>
                <p className="text-xl text-gray-600 mb-2">Sistema completo para cálculo de fertilizantes</p>
                <p className="text-lg text-gray-500">20 cultivos • 5 nutrientes • Análisis avanzado</p>
              </div>

              <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                {calculators.map((calc) => {
                  const IconComponent = calc.icon
                  return (
                    <Card
                      key={calc.id}
                      className="hover:shadow-lg transition-all duration-300 cursor-pointer transform hover:scale-105"
                      onClick={() => setActiveCalculator(calc.id)}
                    >
                      <CardHeader className="text-center">
                        <div
                          className={`w-16 h-16 ${calc.color} rounded-full flex items-center justify-center mx-auto mb-4`}
                        >
                          <IconComponent className="w-8 h-8 text-white" />
                        </div>
                        <CardTitle className="text-xl">{calc.title}</CardTitle>
                        <CardDescription className="text-sm">{calc.description}</CardDescription>
                      </CardHeader>
                      <CardContent>
                        <Button className="w-full bg-transparent" variant="outline">
                          Abrir Calculadora
                        </Button>
                      </CardContent>
                    </Card>
                  )
                })}
              </div>

              <div className="mt-12 text-center">
                <Card className="max-w-2xl mx-auto">
                  <CardHeader>
                    <CardTitle>🚀 Características Principales</CardTitle>
                  </CardHeader>
                  <CardContent>
                    <div className="grid grid-cols-1 md:grid-cols-2 gap-4 text-left">
                      <div>
                        <h4 className="font-semibold text-green-600 mb-2">✅ 20 Cultivos Incluidos:</h4>
                        <p className="text-sm text-gray-600">
                          Cacao, Café, Maíz, Arroz, Plátano, Tomate, Papa, Frijol, Soja, Trigo, Cebolla, Lechuga,
                          Zanahoria, Algodón, Caña de azúcar, Yuca, Ñame, Aguacate, Mango, Cítricos
                        </p>
                      </div>
                      <div>
                        <h4 className="font-semibold text-blue-600 mb-2">🧪 Análisis Completo:</h4>
                        <p className="text-sm text-gray-600">
                          Nitrógeno (N), Fósforo (P2O5), Potasio (K2O), Calcio (Ca), Magnesio (Mg) para cada etapa del
                          cultivo
                        </p>
                      </div>
                    </div>
                  </CardContent>
                </Card>
              </div>
            </div>
          </div>
        )
    }
  }

  return renderCalculator()
}
