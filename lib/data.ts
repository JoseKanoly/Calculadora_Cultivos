export const crops = [
  "Cacao",
  "Café",
  "Maíz",
  "Arroz",
  "Plátano",
  "Tomate",
  "Papa",
  "Frijol",
  "Soja",
  "Trigo",
  "Cebolla",
  "Lechuga",
  "Zanahoria",
  "Algodón",
  "Caña de azúcar",
  "Yuca",
  "Ñame",
  "Aguacate",
  "Mango",
  "Cítricos",
]

export const stages = ["Crecimiento", "Floración", "Desarrollo del fruto"]

export const nutrients = ["Nitrógeno (N)", "Fósforo (P2O5)", "Potasio (K2O)", "Calcio (Ca)", "Magnesio (Mg)"]

export const fertilizers = [
  { name: "Urea (46-00-00)", concentration: 46, nutrient: "Nitrógeno (N)" },
  { name: "Sulfato de amonio (21-00-00)", concentration: 21, nutrient: "Nitrógeno (N)" },
  { name: "Nitrato de amonio", concentration: 34, nutrient: "Nitrógeno (N)" },
  { name: "DAP (18-46-00)", concentration: 46, nutrient: "Fósforo (P2O5)" },
  { name: "MAP (11-52-00)", concentration: 52, nutrient: "Fósforo (P2O5)" },
  { name: "Superfosfato triple", concentration: 46, nutrient: "Fósforo (P2O5)" },
  { name: "KCl (00-00-60)", concentration: 60, nutrient: "Potasio (K2O)" },
  { name: "Sulfato de potasio", concentration: 50, nutrient: "Potasio (K2O)" },
  { name: "NPK 15-15-15", concentration: 15, nutrient: "NPK" },
  { name: "Nitrato de calcio", concentration: 19, nutrient: "Calcio (Ca)" },
  { name: "Yeso agrícola", concentration: 23, nutrient: "Calcio (Ca)" },
  { name: "Sulfato de magnesio", concentration: 10, nutrient: "Magnesio (Mg)" },
  { name: "Dolomita", concentration: 15, nutrient: "Magnesio (Mg)" },
]

// Base de datos completa de requerimientos nutricionales
const nutritionData: Record<string, Record<string, Record<string, number>>> = {
  Maíz: {
    Crecimiento: {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 40,
      "Calcio (Ca)": 15,
      "Magnesio (Mg)": 8,
    },
    Floración: {
      "Nitrógeno (N)": 100,
      "Fósforo (P2O5)": 40,
      "Potasio (K2O)": 70,
      "Calcio (Ca)": 20,
      "Magnesio (Mg)": 12,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 80,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 90,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 10,
    },
  },
  Cacao: {
    Crecimiento: {
      "Nitrógeno (N)": 30,
      "Fósforo (P2O5)": 15,
      "Potasio (K2O)": 40,
      "Calcio (Ca)": 20,
      "Magnesio (Mg)": 10,
    },
    Floración: {
      "Nitrógeno (N)": 50,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 50,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 12,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 40,
      "Fósforo (P2O5)": 20,
      "Potasio (K2O)": 70,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 15,
    },
  },
  Café: {
    Crecimiento: {
      "Nitrógeno (N)": 35,
      "Fósforo (P2O5)": 20,
      "Potasio (K2O)": 50,
      "Calcio (Ca)": 18,
      "Magnesio (Mg)": 10,
    },
    Floración: {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 60,
      "Calcio (Ca)": 22,
      "Magnesio (Mg)": 12,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 55,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 80,
      "Calcio (Ca)": 26,
      "Magnesio (Mg)": 15,
    },
  },
  Arroz: {
    Crecimiento: {
      "Nitrógeno (N)": 50,
      "Fósforo (P2O5)": 20,
      "Potasio (K2O)": 30,
      "Calcio (Ca)": 12,
      "Magnesio (Mg)": 7,
    },
    Floración: {
      "Nitrógeno (N)": 80,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 60,
      "Calcio (Ca)": 18,
      "Magnesio (Mg)": 9,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 70,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 70,
      "Calcio (Ca)": 20,
      "Magnesio (Mg)": 10,
    },
  },
  Plátano: {
    Crecimiento: {
      "Nitrógeno (N)": 40,
      "Fósforo (P2O5)": 15,
      "Potasio (K2O)": 60,
      "Calcio (Ca)": 22,
      "Magnesio (Mg)": 14,
    },
    Floración: {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 20,
      "Potasio (K2O)": 80,
      "Calcio (Ca)": 26,
      "Magnesio (Mg)": 16,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 70,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 100,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 18,
    },
  },
  Tomate: {
    Crecimiento: {
      "Nitrógeno (N)": 80,
      "Fósforo (P2O5)": 40,
      "Potasio (K2O)": 60,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 15,
    },
    Floración: {
      "Nitrógeno (N)": 120,
      "Fósforo (P2O5)": 60,
      "Potasio (K2O)": 100,
      "Calcio (Ca)": 45,
      "Magnesio (Mg)": 20,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 100,
      "Fósforo (P2O5)": 50,
      "Potasio (K2O)": 140,
      "Calcio (Ca)": 50,
      "Magnesio (Mg)": 25,
    },
  },
  Papa: {
    Crecimiento: {
      "Nitrógeno (N)": 70,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 80,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 12,
    },
    Floración: {
      "Nitrógeno (N)": 90,
      "Fósforo (P2O5)": 45,
      "Potasio (K2O)": 120,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 15,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 80,
      "Fósforo (P2O5)": 40,
      "Potasio (K2O)": 150,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 18,
    },
  },
  Frijol: {
    Crecimiento: {
      "Nitrógeno (N)": 25,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 40,
      "Calcio (Ca)": 20,
      "Magnesio (Mg)": 10,
    },
    Floración: {
      "Nitrógeno (N)": 35,
      "Fósforo (P2O5)": 40,
      "Potasio (K2O)": 50,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 12,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 30,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 60,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 15,
    },
  },
  Soja: {
    Crecimiento: {
      "Nitrógeno (N)": 30,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 45,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 12,
    },
    Floración: {
      "Nitrógeno (N)": 40,
      "Fósforo (P2O5)": 45,
      "Potasio (K2O)": 60,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 15,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 50,
      "Fósforo (P2O5)": 40,
      "Potasio (K2O)": 80,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 18,
    },
  },
  Trigo: {
    Crecimiento: {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 35,
      "Calcio (Ca)": 15,
      "Magnesio (Mg)": 8,
    },
    Floración: {
      "Nitrógeno (N)": 90,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 50,
      "Calcio (Ca)": 20,
      "Magnesio (Mg)": 10,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 80,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 45,
      "Calcio (Ca)": 18,
      "Magnesio (Mg)": 12,
    },
  },
  Cebolla: {
    Crecimiento: {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 70,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 12,
    },
    Floración: {
      "Nitrógeno (N)": 80,
      "Fósforo (P2O5)": 40,
      "Potasio (K2O)": 90,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 15,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 70,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 100,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 18,
    },
  },
  Lechuga: {
    Crecimiento: {
      "Nitrógeno (N)": 50,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 60,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 15,
    },
    Floración: {
      "Nitrógeno (N)": 70,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 80,
      "Calcio (Ca)": 40,
      "Magnesio (Mg)": 18,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 70,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 20,
    },
  },
  Zanahoria: {
    Crecimiento: {
      "Nitrógeno (N)": 45,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 80,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 12,
    },
    Floración: {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 40,
      "Potasio (K2O)": 100,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 15,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 50,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 120,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 18,
    },
  },
  Algodón: {
    Crecimiento: {
      "Nitrógeno (N)": 70,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 60,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 15,
    },
    Floración: {
      "Nitrógeno (N)": 100,
      "Fósforo (P2O5)": 45,
      "Potasio (K2O)": 80,
      "Calcio (Ca)": 40,
      "Magnesio (Mg)": 20,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 90,
      "Fósforo (P2O5)": 40,
      "Potasio (K2O)": 100,
      "Calcio (Ca)": 45,
      "Magnesio (Mg)": 25,
    },
  },
  "Caña de azúcar": {
    Crecimiento: {
      "Nitrógeno (N)": 80,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 90,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 15,
    },
    Floración: {
      "Nitrógeno (N)": 120,
      "Fósforo (P2O5)": 40,
      "Potasio (K2O)": 130,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 20,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 100,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 150,
      "Calcio (Ca)": 40,
      "Magnesio (Mg)": 25,
    },
  },
  Yuca: {
    Crecimiento: {
      "Nitrógeno (N)": 40,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 60,
      "Calcio (Ca)": 20,
      "Magnesio (Mg)": 12,
    },
    Floración: {
      "Nitrógeno (N)": 50,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 80,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 15,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 45,
      "Fósforo (P2O5)": 28,
      "Potasio (K2O)": 100,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 18,
    },
  },
  Ñame: {
    Crecimiento: {
      "Nitrógeno (N)": 45,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 70,
      "Calcio (Ca)": 25,
      "Magnesio (Mg)": 15,
    },
    Floración: {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 90,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 18,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 55,
      "Fósforo (P2O5)": 32,
      "Potasio (K2O)": 110,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 20,
    },
  },
  Aguacate: {
    Crecimiento: {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 80,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 20,
    },
    Floración: {
      "Nitrógeno (N)": 80,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 100,
      "Calcio (Ca)": 40,
      "Magnesio (Mg)": 25,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 70,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 120,
      "Calcio (Ca)": 45,
      "Magnesio (Mg)": 30,
    },
  },
  Mango: {
    Crecimiento: {
      "Nitrógeno (N)": 50,
      "Fósforo (P2O5)": 20,
      "Potasio (K2O)": 70,
      "Calcio (Ca)": 30,
      "Magnesio (Mg)": 18,
    },
    Floración: {
      "Nitrógeno (N)": 70,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 90,
      "Calcio (Ca)": 35,
      "Magnesio (Mg)": 22,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 60,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 110,
      "Calcio (Ca)": 40,
      "Magnesio (Mg)": 25,
    },
  },
  Cítricos: {
    Crecimiento: {
      "Nitrógeno (N)": 55,
      "Fósforo (P2O5)": 25,
      "Potasio (K2O)": 75,
      "Calcio (Ca)": 40,
      "Magnesio (Mg)": 20,
    },
    Floración: {
      "Nitrógeno (N)": 75,
      "Fósforo (P2O5)": 35,
      "Potasio (K2O)": 95,
      "Calcio (Ca)": 45,
      "Magnesio (Mg)": 25,
    },
    "Desarrollo del fruto": {
      "Nitrógeno (N)": 65,
      "Fósforo (P2O5)": 30,
      "Potasio (K2O)": 115,
      "Calcio (Ca)": 50,
      "Magnesio (Mg)": 28,
    },
  },
}

export function getNutrientRequirement(crop: string, stage: string, nutrient: string): number {
  return nutritionData[crop]?.[stage]?.[nutrient] || 0
}

export function getFertilizersByNutrient(nutrient: string): string[] {
  return fertilizers.filter((f) => f.nutrient === nutrient || f.nutrient === "NPK").map((f) => f.name)
}

export function getFertilizerConcentration(fertilizerName: string, nutrient: string): number {
  const fertilizer = fertilizers.find((f) => f.name === fertilizerName)
  if (!fertilizer) return 0

  // Casos especiales para fertilizantes compuestos
  if (fertilizerName === "DAP (18-46-00)") {
    if (nutrient === "Nitrógeno (N)") return 18
    if (nutrient === "Fósforo (P2O5)") return 46
  }

  if (fertilizerName === "MAP (11-52-00)") {
    if (nutrient === "Nitrógeno (N)") return 11
    if (nutrient === "Fósforo (P2O5)") return 52
  }

  if (fertilizerName === "NPK 15-15-15") {
    return 15 // Para N, P, K
  }

  return fertilizer.concentration
}
