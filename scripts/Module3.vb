' Módulo adicional con funciones de utilidad para los 20 cultivos
Option Explicit

Public Function ObtenerTipoCultivo(cultivo As String) As String
    ' Función para clasificar el tipo de cultivo
    
    Select Case LCase(Trim(cultivo))
        Case "maíz", "maiz", "arroz", "trigo", "soja", "soya"
            ObtenerTipoCultivo = "Cereales y Granos"
        Case "tomate", "papa", "cebolla", "lechuga", "zanahoria"
            ObtenerTipoCultivo = "Hortalizas"
        Case "frijol", "soja", "soya"
            ObtenerTipoCultivo = "Leguminosas"
        Case "cacao", "café", "aguacate", "mango", "cítricos", "citricos", "naranja", "limón", "limon", "mandarina"
            ObtenerTipoCultivo = "Frutales Perennes"
        Case "plátano", "platano"
            ObtenerTipoCultivo = "Musáceas"
        Case "algodón", "algodon"
            ObtenerTipoCultivo = "Fibras"
        Case "caña de azúcar", "cana de azucar"
            ObtenerTipoCultivo = "Industriales"
        Case "yuca", "ñame", "name"
            ObtenerTipoCultivo = "Tubérculos"
        Case Else
            ObtenerTipoCultivo = "Otros"
    End Select
End Function

Public Function ObtenerCicloVegetativo(cultivo As String) As Integer
    ' Función para obtener el ciclo vegetativo en días
    
    Select Case LCase(Trim(cultivo))
        Case "lechuga": ObtenerCicloVegetativo = 60
        Case "zanahoria": ObtenerCicloVegetativo = 90
        Case "cebolla": ObtenerCicloVegetativo = 120
        Case "tomate": ObtenerCicloVegetativo = 150
        Case "papa": ObtenerCicloVegetativo = 120
        Case "maíz", "maiz": ObtenerCicloVegetativo = 120
        Case "arroz": ObtenerCicloVegetativo = 150
        Case "frijol": ObtenerCicloVegetativo = 90
        Case "soja", "soya": ObtenerCicloVegetativo = 120
        Case "trigo": ObtenerCicloVegetativo = 180
        Case "algodón", "algodon": ObtenerCicloVegetativo = 200
        Case "caña de azúcar", "cana de azucar": ObtenerCicloVegetativo = 365
        Case "yuca": ObtenerCicloVegetativo = 300
        Case "ñame", "name": ObtenerCicloVegetativo = 270
        Case "cacao": ObtenerCicloVegetativo = 365
        Case "café", "cafe": ObtenerCicloVegetativo = 365
        Case "plátano", "platano": ObtenerCicloVegetativo = 365
        Case "aguacate", "palta": ObtenerCicloVegetativo = 365
        Case "mango": ObtenerCicloVegetativo = 365
        Case "cítricos", "citricos", "naranja", "limón", "limon", "mandarina": ObtenerCicloVegetativo = 365
        Case Else: ObtenerCicloVegetativo = 120
    End Select
End Function

Public Function ObtenerRendimientoPromedio(cultivo As String) As Double
    ' Función para obtener rendimiento promedio en toneladas por hectárea
    
    Select Case LCase(Trim(cultivo))
        Case "lechuga": ObtenerRendimientoPromedio = 25
        Case "zanahoria": ObtenerRendimientoPromedio = 30
        Case "cebolla": ObtenerRendimientoPromedio = 35
        Case "tomate": ObtenerRendimientoPromedio = 60
        Case "papa": ObtenerRendimientoPromedio = 25
        Case "maíz", "maiz": ObtenerRendimientoPromedio = 8
        Case "arroz": ObtenerRendimientoPromedio = 6
        Case "frijol": ObtenerRendimientoPromedio = 2
        Case "soja", "soya": ObtenerRendimientoPromedio = 3
        Case "trigo": ObtenerRendimientoPromedio = 4
        Case "algodón", "algodon": ObtenerRendimientoPromedio = 2.5
        Case "caña de azúcar", "cana de azucar": ObtenerRendimientoPromedio = 80
        Case "yuca": ObtenerRendimientoPromedio = 20
        Case "ñame", "name": ObtenerRendimientoPromedio = 15
        Case "cacao": ObtenerRendimientoPromedio = 1.5
        Case "café", "cafe": ObtenerRendimientoPromedio = 2
        Case "plátano", "platano": ObtenerRendimientoPromedio = 40
        Case "aguacate", "palta": ObtenerRendimientoPromedio = 12
        Case "mango": ObtenerRendimientoPromedio = 15
        Case "cítricos", "citricos", "naranja", "limón", "limon", "mandarina": ObtenerRendimientoPromedio = 25
        Case Else: ObtenerRendimientoPromedio = 10
    End Select
End Function

Public Sub GenerarReporteCultivos()
    ' Procedimiento para generar un reporte completo de todos los cultivos
    
    Dim ws As Worksheet
    Dim i As Integer
    Dim cultivos As Variant
    
    ' Array con todos los cultivos
    cultivos = Array("Cacao", "Café", "Maíz", "Arroz", "Plátano", "Tomate", "Papa", _
                    "Frijol", "Soja", "Trigo", "Cebolla", "Lechuga", "Zanahoria", _
                    "Algodón", "Caña de azúcar", "Yuca", "Ñame", "Aguacate", "Mango", "Cítricos")
    
    ' Crear nueva hoja para el reporte
    On Error Resume Next
    Set ws = ThisWorkbook.Worksheets("Reporte_Cultivos")
    On Error GoTo 0
    
    If ws Is Nothing Then
        Set ws = ThisWorkbook.Worksheets.Add
        ws.Name = "Reporte_Cultivos"
    Else
        ws.Cells.Clear
    End If
    
    ' Crear encabezados
    With ws
        .Cells(1, 1).Value = "REPORTE COMPLETO DE CULTIVOS"
        .Cells(1, 1).Font.Bold = True
        .Cells(1, 1).Font.Size = 16
        .Range("A1:H1").Merge
        
        .Cells(3, 1).Value = "Cultivo"
        .Cells(3, 2).Value = "Tipo"
        .Cells(3, 3).Value = "Ciclo (días)"
        .Cells(3, 4).Value = "Rendimiento (t/ha)"
        .Cells(3, 5).Value = "N Crecimiento"
        .Cells(3, 6).Value = "P Crecimiento"
        .Cells(3, 7).Value = "K Crecimiento"
        .Cells(3, 8).Value = "Observaciones"
        
        .Range("A3:H3").Font.Bold = True
        .Range("A3:H3").Interior.Color = RGB(200, 200, 200)
    End With
    
    ' Llenar datos
    For i = 0 To UBound(cultivos)
        With ws
            .Cells(i + 4, 1).Value = cultivos(i)
            .Cells(i + 4, 2).Value = ObtenerTipoCultivo(cultivos(i))
            .Cells(i + 4, 3).Value = ObtenerCicloVegetativo(cultivos(i))
            .Cells(i + 4, 4).Value = ObtenerRendimientoPromedio(cultivos(i))
            .Cells(i + 4, 5).Value = ObtenerRequerimiento(cultivos(i), "Crecimiento", "Nitrógeno (N)")
            .Cells(i + 4, 6).Value = ObtenerRequerimiento(cultivos(i), "Crecimiento", "Fósforo (P2O5)")
            .Cells(i + 4, 7).Value = ObtenerRequerimiento(cultivos(i), "Crecimiento", "Potasio (K2O)")
            
            ' Agregar observaciones específicas
            Select Case LCase(cultivos(i))
                Case "cacao": .Cells(i + 4, 8).Value = "Requiere sombra parcial"
                Case "café": .Cells(i + 4, 8).Value = "Altitud 1000-2000 msnm"
                Case "tomate": .Cells(i + 4, 8).Value = "Sensible a exceso de humedad"
                Case "papa": .Cells(i + 4, 8).Value = "Requiere suelos bien drenados"
                Case "arroz": .Cells(i + 4, 8).Value = "Cultivo de inundación"
                Case "algodón": .Cells(i + 4, 8).Value = "Requiere clima cálido"
                Case "caña de azúcar": .Cells(i + 4, 8).Value = "Cultivo de ciclo largo"
                Case Else: .Cells(i + 4, 8).Value = "Manejo estándar"
            End Select
        End With
    Next i
    
    ' Autoajustar columnas
    ws.Columns("A:H").AutoFit
    
    MsgBox "Reporte de cultivos generado exitosamente en la hoja 'Reporte_Cultivos'.", vbInformation
End Sub

Public Function ValidarCombinacionCultivoEtapa(cultivo As String, etapa As String) As Boolean
    ' Función para validar si la combinación cultivo-etapa es válida
    
    ValidarCombinacionCultivoEtapa = True
    
    ' Validaciones específicas
    Select Case LCase(Trim(cultivo))
        Case "lechuga", "zanahoria"
            If LCase(Trim(etapa)) = "desarrollo del fruto" Then
                ValidarCombinacionCultivoEtapa = False
            End If
        Case "trigo", "arroz", "maíz"
            ' Todos los cereales tienen las tres etapas
            ValidarCombinacionCultivoEtapa = True
        Case Else
            ValidarCombinacionCultivoEtapa = True
    End Select
End Function
