' UserForm5 - Comparador de Cultivos
Option Explicit

Private Sub UserForm_Initialize()
    Me.Caption = "Comparador de Requerimientos entre Cultivos"
    
    ' Cargar cultivos en ambos ComboBox
    Dim cultivos As Variant
    cultivos = Array("Cacao", "Café", "Maíz", "Arroz", "Plátano", "Tomate", "Papa", _
                    "Frijol", "Soja", "Trigo", "Cebolla", "Lechuga", "Zanahoria", _
                    "Algodón", "Caña de azúcar", "Yuca", "Ñame", "Aguacate", "Mango", "Cítricos")
    
    Dim i As Integer
    For i = 0 To UBound(cultivos)
        cmbCultivo1.AddItem cultivos(i)
        cmbCultivo2.AddItem cultivos(i)
    Next i
    
    ' Cargar etapas
    With cmbEtapa
        .Clear
        .AddItem "Crecimiento"
        .AddItem "Floración"
        .AddItem "Desarrollo del fruto"
    End With
    
    Call LimpiarComparacion
End Sub

Private Sub btnComparar_Click()
    On Error GoTo ErrorHandler
    
    ' Validar campos
    If cmbCultivo1.Value = "" Then
        MsgBox "Selecciona el primer cultivo.", vbExclamation, "Campo requerido"
        cmbCultivo1.SetFocus
        Exit Sub
    End If
    
    If cmbCultivo2.Value = "" Then
        MsgBox "Selecciona el segundo cultivo.", vbExclamation, "Campo requerido"
        cmbCultivo2.SetFocus
        Exit Sub
    End If
    
    If cmbEtapa.Value = "" Then
        MsgBox "Selecciona una etapa.", vbExclamation, "Campo requerido"
        cmbEtapa.SetFocus
        Exit Sub
    End If
    
    If cmbCultivo1.Value = cmbCultivo2.Value Then
        MsgBox "Selecciona cultivos diferentes para comparar.", vbExclamation, "Cultivos iguales"
        Exit Sub
    End If
    
    ' Obtener requerimientos para ambos cultivos
    Dim cultivo1 As String, cultivo2 As String, etapa As String
    Dim n1 As Double, p1 As Double, k1 As Double, ca1 As Double, mg1 As Double
    Dim n2 As Double, p2 As Double, k2 As Double, ca2 As Double, mg2 As Double
    
    cultivo1 = cmbCultivo1.Value
    cultivo2 = cmbCultivo2.Value
    etapa = cmbEtapa.Value
    
    ' Cultivo 1
    n1 = ObtenerRequerimiento(cultivo1, etapa, "Nitrógeno (N)")
    p1 = ObtenerRequerimiento(cultivo1, etapa, "Fósforo (P2O5)")
    k1 = ObtenerRequerimiento(cultivo1, etapa, "Potasio (K2O)")
    ca1 = ObtenerRequerimiento(cultivo1, etapa, "Calcio (Ca)")
    mg1 = ObtenerRequerimiento(cultivo1, etapa, "Magnesio (Mg)")
    
    ' Cultivo 2
    n2 = ObtenerRequerimiento(cultivo2, etapa, "Nitrógeno (N)")
    p2 = ObtenerRequerimiento(cultivo2, etapa, "Fósforo (P2O5)")
    k2 = ObtenerRequerimiento(cultivo2, etapa, "Potasio (K2O)")
    ca2 = ObtenerRequerimiento(cultivo2, etapa, "Calcio (Ca)")
    mg2 = ObtenerRequerimiento(cultivo2, etapa, "Magnesio (Mg)")
    
    ' Mostrar resultados del Cultivo 1
    lblN1.Caption = "N: " & n1 & " kg/ha"
    lblP1.Caption = "P2O5: " & p1 & " kg/ha"
    lblK1.Caption = "K2O: " & k1 & " kg/ha"
    lblCa1.Caption = "Ca: " & ca1 & " kg/ha"
    lblMg1.Caption = "Mg: " & mg1 & " kg/ha"
    
    ' Mostrar resultados del Cultivo 2
    lblN2.Caption = "N: " & n2 & " kg/ha"
    lblP2.Caption = "P2O5: " & p2 & " kg/ha"
    lblK2.Caption = "K2O: " & k2 & " kg/ha"
    lblCa2.Caption = "Ca: " & ca2 & " kg/ha"
    lblMg2.Caption = "Mg: " & mg2 & " kg/ha"
    
    ' Calcular y mostrar diferencias
    lblDifN.Caption = "Δ N: " & Format(n2 - n1, "+0.0;-0.0") & " kg/ha"
    lblDifP.Caption = "Δ P2O5: " & Format(p2 - p1, "+0.0;-0.0") & " kg/ha"
    lblDifK.Caption = "Δ K2O: " & Format(k2 - k1, "+0.0;-0.0") & " kg/ha"
    lblDifCa.Caption = "Δ Ca: " & Format(ca2 - ca1, "+0.0;-0.0") & " kg/ha"
    lblDifMg.Caption = "Δ Mg: " & Format(mg2 - mg1, "+0.0;-0.0") & " kg/ha"
    
    ' Colorear las diferencias
    Call ColorearDiferencias(lblDifN, n2 - n1)
    Call ColorearDiferencias(lblDifP, p2 - p1)
    Call ColorearDiferencias(lblDifK, k2 - k1)
    Call ColorearDiferencias(lblDifCa, ca2 - ca1)
    Call ColorearDiferencias(lblDifMg, mg2 - mg1)
    
    ' Generar análisis comparativo
    Call GenerarAnalisisComparativo(cultivo1, cultivo2, etapa, n1, p1, k1, n2, p2, k2)
    
    ' Mostrar información adicional
    lblTipo1.Caption = "Tipo: " & ObtenerTipoCultivo(cultivo1)
    lblTipo2.Caption = "Tipo: " & ObtenerTipoCultivo(cultivo2)
    lblCiclo1.Caption = "Ciclo: " & ObtenerCicloVegetativo(cultivo1) & " días"
    lblCiclo2.Caption = "Ciclo: " & ObtenerCicloVegetativo(cultivo2) & " días"
    lblRendimiento1.Caption = "Rendimiento: " & ObtenerRendimientoPromedio(cultivo1) & " t/ha"
    lblRendimiento2.Caption = "Rendimiento: " & ObtenerRendimientoPromedio(cultivo2) & " t/ha"
    
    Exit Sub
    
ErrorHandler:
    MsgBox "Error en la comparación: " & Err.Description, vbCritical, "Error"
End Sub

Private Sub ColorearDiferencias(lbl As Object, diferencia As Double)
    ' Colorear las etiquetas según la diferencia
    If diferencia > 0 Then
        lbl.ForeColor = RGB(0, 150, 0) ' Verde para valores positivos
    ElseIf diferencia < 0 Then
        lbl.ForeColor = RGB(200, 0, 0) ' Rojo para valores negativos
    Else
        lbl.ForeColor = RGB(0, 0, 0) ' Negro para valores iguales
    End If
End Sub

Private Sub GenerarAnalisisComparativo(cultivo1 As String, cultivo2 As String, etapa As String, _
                                     n1 As Double, p1 As Double, k1 As Double, _
                                     n2 As Double, p2 As Double, k2 As Double)
    Dim analisis As String
    Dim totalReq1 As Double, totalReq2 As Double
    
    totalReq1 = n1 + p1 + k1
    totalReq2 = n2 + p2 + k2
    
    analisis = "ANÁLISIS COMPARATIVO" & vbCrLf & vbCrLf
    analisis = analisis & "Etapa: " & etapa & vbCrLf & vbCrLf
    
    ' Análisis de requerimientos totales
    If totalReq2 > totalReq1 Then
        analisis = analisis & "• " & cultivo2 & " requiere " & Format(((totalReq2 / totalReq1) - 1) * 100, "0.0") & _
                  "% más nutrientes que " & cultivo1 & vbCrLf
    ElseIf totalReq1 > totalReq2 Then
        analisis = analisis & "• " & cultivo1 & " requiere " & Format(((totalReq1 / totalReq2) - 1) * 100, "0.0") & _
                  "% más nutrientes que " & cultivo2 & vbCrLf
    Else
        analisis = analisis & "• Ambos cultivos tienen requerimientos similares" & vbCrLf
    End If
    
    ' Análisis por nutriente
    analisis = analisis & vbCrLf & "DIFERENCIAS PRINCIPALES:" & vbCrLf
    
    If Abs(n2 - n1) > 10 Then
        If n2 > n1 Then
            analisis = analisis & "• " & cultivo2 & " necesita " & Format(n2 - n1, "0.0") & " kg/ha más de Nitrógeno" & vbCrLf
        Else
            analisis = analisis & "• " & cultivo1 & " necesita " & Format(n1 - n2, "0.0") & " kg/ha más de Nitrógeno" & vbCrLf
        End If
    End If
    
    If Abs(p2 - p1) > 5 Then
        If p2 > p1 Then
            analisis = analisis & "• " & cultivo2 & " necesita " & Format(p2 - p1, "0.0") & " kg/ha más de Fósforo" & vbCrLf
        Else
            analisis = analisis & "• " & cultivo1 & " necesita " & Format(p1 - p2, "0.0") & " kg/ha más de Fósforo" & vbCrLf
        End If
    End If
    
    If Abs(k2 - k1) > 10 Then
        If k2 > k1 Then
            analisis = analisis & "• " & cultivo2 & " necesita " & Format(k2 - k1, "0.0") & " kg/ha más de Potasio" & vbCrLf
        Else
            analisis = analisis & "• " & cultivo1 & " necesita " & Format(k1 - k2, "0.0") & " kg/ha más de Potasio" & vbCrLf
        End If
    End If
    
    ' Recomendaciones
    analisis = analisis & vbCrLf & "RECOMENDACIONES:" & vbCrLf
    
    If ObtenerTipoCultivo(cultivo1) = ObtenerTipoCultivo(cultivo2) Then
        analisis = analisis & "• Ambos cultivos son del mismo tipo, pueden usar programas de fertilización similares" & vbCrLf
    Else
        analisis = analisis & "• Cultivos de diferentes tipos, requieren manejo nutricional específico" & vbCrLf
    End If
    
    If totalReq2 > totalReq1 * 1.5 Then
        analisis = analisis & "• " & cultivo2 & " es significativamente más exigente nutricionalmente" & vbCrLf
    ElseIf totalReq1 > totalReq2 * 1.5 Then
        analisis = analisis & "• " & cultivo1 & " es significativamente más exigente nutricionalmente" & vbCrLf
    End If
    
    txtAnalisis.Text = analisis
End Sub

Private Sub btnLimpiar_Click()
    Call LimpiarComparacion
End Sub

Private Sub LimpiarComparacion()
    ' Limpiar selecciones
    cmbCultivo1.Value = ""
    cmbCultivo2.Value = ""
    cmbEtapa.Value = ""
    
    ' Limpiar resultados Cultivo 1
    lblN1.Caption = "N: "
    lblP1.Caption = "P2O5: "
    lblK1.Caption = "K2O: "
    lblCa1.Caption = "Ca: "
    lblMg1.Caption = "Mg: "
    lblTipo1.Caption = "Tipo: "
    lblCiclo1.Caption = "Ciclo: "
    lblRendimiento1.Caption = "Rendimiento: "
    
    ' Limpiar resultados Cultivo 2
    lblN2.Caption = "N: "
    lblP2.Caption = "P2O5: "
    lblK2.Caption = "K2O: "
    lblCa2.Caption = "Ca: "
    lblMg2.Caption = "Mg: "
    lblTipo2.Caption = "Tipo: "
    lblCiclo2.Caption = "Ciclo: "
    lblRendimiento2.Caption = "Rendimiento: "
    
    ' Limpiar diferencias
    lblDifN.Caption = "Δ N: "
    lblDifP.Caption = "Δ P2O5: "
    lblDifK.Caption = "Δ K2O: "
    lblDifCa.Caption = "Δ Ca: "
    lblDifMg.Caption = "Δ Mg: "
    
    ' Resetear colores
    lblDifN.ForeColor = RGB(0, 0, 0)
    lblDifP.ForeColor = RGB(0, 0, 0)
    lblDifK.ForeColor = RGB(0, 0, 0)
    lblDifCa.ForeColor = RGB(0, 0, 0)
    lblDifMg.ForeColor = RGB(0, 0, 0)
    
    ' Limpiar análisis
    txtAnalisis.Text = ""
End Sub

Private Sub btnExportarComparacion_Click()
    On Error GoTo ErrorHandler
    
    ' Validar que se haya realizado una comparación
    If cmbCultivo1.Value = "" Or cmbCultivo2.Value = "" Or cmbEtapa.Value = "" Then
        MsgBox "Primero realiza una comparación antes de exportar.", vbExclamation, "Sin datos"
        Exit Sub
    End If
    
    Dim ws As Worksheet
    Dim ultimaFila As Long
    
    ' Crear o seleccionar hoja de comparaciones
    On Error Resume Next
    Set ws = ThisWorkbook.Worksheets("Comparaciones_Cultivos")
    On Error GoTo ErrorHandler
    
    If ws Is Nothing Then
        Set ws = ThisWorkbook.Worksheets.Add
        ws.Name = "Comparaciones_Cultivos"
        
        ' Crear encabezados
        With ws
            .Cells(1, 1).Value = "COMPARACIONES DE CULTIVOS"
            .Cells(1, 1).Font.Bold = True
            .Cells(1, 1).Font.Size = 14
            .Range("A1:M1").Merge
            
            .Cells(3, 1).Value = "Fecha"
            .Cells(3, 2).Value = "Cultivo 1"
            .Cells(3, 3).Value = "Cultivo 2"
            .Cells(3, 4).Value = "Etapa"
            .Cells(3, 5).Value = "N1 (kg/ha)"
            .Cells(3, 6).Value = "P1 (kg/ha)"
            .Cells(3, 7).Value = "K1 (kg/ha)"
            .Cells(3, 8).Value = "N2 (kg/ha)"
            .Cells(3, 9).Value = "P2 (kg/ha)"
            .Cells(3, 10).Value = "K2 (kg/ha)"
            .Cells(3, 11).Value = "Dif N"
            .Cells(3, 12).Value = "Dif P"
            .Cells(3, 13).Value = "Dif K"
            
            .Range("A3:M3").Font.Bold = True
            .Range("A3:M3").Interior.Color = RGB(200, 200, 200)
        End With
    End If
    
    ' Encontrar última fila
    ultimaFila = ws.Cells(ws.Rows.Count, 1).End(xlUp).Row + 1
    
    ' Extraer valores numéricos de las etiquetas
    Dim n1 As Double, p1 As Double, k1 As Double
    Dim n2 As Double, p2 As Double, k2 As Double
    
    n1 = Val(Replace(Replace(lblN1.Caption, "N: ", ""), " kg/ha", ""))
    p1 = Val(Replace(Replace(lblP1.Caption, "P2O5: ", ""), " kg/ha", ""))
    k1 = Val(Replace(Replace(lblK1.Caption, "K2O: ", ""), " kg/ha", ""))
    n2 = Val(Replace(Replace(lblN2.Caption, "N: ", ""), " kg/ha", ""))
    p2 = Val(Replace(Replace(lblP2.Caption, "P2O5: ", ""), " kg/ha", ""))
    k2 = Val(Replace(Replace(lblK2.Caption, "K2O: ", ""), " kg/ha", ""))
    
    ' Agregar datos
    With ws
        .Cells(ultimaFila, 1).Value = Now
        .Cells(ultimaFila, 2).Value = cmbCultivo1.Value
        .Cells(ultimaFila, 3).Value = cmbCultivo2.Value
        .Cells(ultimaFila, 4).Value = cmbEtapa.Value
        .Cells(ultimaFila, 5).Value = n1
        .Cells(ultimaFila, 6).Value = p1
        .Cells(ultimaFila, 7).Value = k1
        .Cells(ultimaFila, 8).Value = n2
        .Cells(ultimaFila, 9).Value = p2
        .Cells(ultimaFila, 10).Value = k2
        .Cells(ultimaFila, 11).Value = n2 - n1
        .Cells(ultimaFila, 12).Value = p2 - p1
        .Cells(ultimaFila, 13).Value = k2 - k1
        
        ' Colorear diferencias en la hoja
        If n2 - n1 > 0 Then .Cells(ultimaFila, 11).Font.Color = RGB(0, 150, 0)
        If n2 - n1 < 0 Then .Cells(ultimaFila, 11).Font.Color = RGB(200, 0, 0)
        If p2 - p1 > 0 Then .Cells(ultimaFila, 12).Font.Color = RGB(0, 150, 0)
        If p2 - p1 < 0 Then .Cells(ultimaFila, 12).Font.Color = RGB(200, 0, 0)
        If k2 - k1 > 0 Then .Cells(ultimaFila, 13).Font.Color = RGB(0, 150, 0)
        If k2 - k1 < 0 Then .Cells(ultimaFila, 13).Font.Color = RGB(200, 0, 0)
    End With
    
    ' Autoajustar columnas
    ws.Columns("A:M").AutoFit
    
    MsgBox "Comparación exportada exitosamente a la hoja 'Comparaciones_Cultivos'.", vbInformation
    
    Exit Sub
    
ErrorHandler:
    MsgBox "Error al exportar comparación: " & Err.Description, vbCritical, "Error"
End Sub

Private Sub btnGenerarGrafico_Click()
    On Error GoTo ErrorHandler
    
    ' Validar que se haya realizado una comparación
    If cmbCultivo1.Value = "" Or cmbCultivo2.Value = "" Or cmbEtapa.Value = "" Then
        MsgBox "Primero realiza una comparación antes de generar el gráfico.", vbExclamation, "Sin datos"
        Exit Sub
    End If
    
    ' Crear hoja temporal para datos del gráfico
    Dim wsTemp As Worksheet
    Set wsTemp = ThisWorkbook.Worksheets.Add
    wsTemp.Name = "Temp_Grafico_" & Format(Now, "hhmmss")
    
    ' Preparar datos para el gráfico
    With wsTemp
        .Cells(1, 1).Value = "Nutriente"
        .Cells(1, 2).Value = cmbCultivo1.Value
        .Cells(1, 3).Value = cmbCultivo2.Value
        
        .Cells(2, 1).Value = "Nitrógeno"
        .Cells(3, 1).Value = "Fósforo"
        .Cells(4, 1).Value = "Potasio"
        
        .Cells(2, 2).Value = Val(Replace(Replace(lblN1.Caption, "N: ", ""), " kg/ha", ""))
        .Cells(3, 2).Value = Val(Replace(Replace(lblP1.Caption, "P2O5: ", ""), " kg/ha", ""))
        .Cells(4, 2).Value = Val(Replace(Replace(lblK1.Caption, "K2O: ", ""), " kg/ha", ""))
        
        .Cells(2, 3).Value = Val(Replace(Replace(lblN2.Caption, "N: ", ""), " kg/ha", ""))
        .Cells(3, 3).Value = Val(Replace(Replace(lblP2.Caption, "P2O5: ", ""), " kg/ha", ""))
        .Cells(4, 3).Value = Val(Replace(Replace(lblK2.Caption, "K2O: ", ""), " kg/ha", ""))
    End With
    
    ' Crear gráfico
    Dim grafico As ChartObject
    Set grafico = wsTemp.ChartObjects.Add(Left:=100, Width:=400, Top:=100, Height:=300)
    
    With grafico.Chart
        .SetSourceData wsTemp.Range("A1:C4")
        .ChartType = xlColumnClustered
        .HasTitle = True
        .ChartTitle.Text = "Comparación Nutricional: " & cmbCultivo1.Value & " vs " & cmbCultivo2.Value & _
                          " (" & cmbEtapa.Value & ")"
        .Axes(xlCategory).HasTitle = True
        .Axes(xlCategory).AxisTitle.Text = "Nutrientes"
        .Axes(xlValue).HasTitle = True
        .Axes(xlValue).AxisTitle.Text = "Requerimiento (kg/ha)"
        .HasLegend = True
        .Legend.Position = xlLegendPositionBottom
    End With
    
    MsgBox "Gráfico generado exitosamente en la hoja '" & wsTemp.Name & "'.", vbInformation
    
    Exit Sub
    
ErrorHandler:
    MsgBox "Error al generar gráfico: " & Err.Description, vbCritical, "Error"
    If Not wsTemp Is Nothing Then
        Application.DisplayAlerts = False
        wsTemp.Delete
        Application.DisplayAlerts = True
    End If
End Sub

Private Sub cmbCultivo1_Change()
    If cmbCultivo1.Value <> "" Then
        lblTituloCultivo1.Caption = cmbCultivo1.Value
    End If
End Sub

Private Sub cmbCultivo2_Change()
    If cmbCultivo2.Value <> "" Then
        lblTituloCultivo2.Caption = cmbCultivo2.Value
    End If
End Sub

Private Sub btnIntercambiar_Click()
    ' Intercambiar los cultivos seleccionados
    Dim temp As String
    temp = cmbCultivo1.Value
    cmbCultivo1.Value = cmbCultivo2.Value
    cmbCultivo2.Value = temp
    
    ' Si hay datos, recalcular automáticamente
    If cmbEtapa.Value <> "" And cmbCultivo1.Value <> "" And cmbCultivo2.Value <> "" Then
        Call btnComparar_Click
    End If
End Sub

Private Sub cmdCerrar_Click()
    Unload Me
End Sub
