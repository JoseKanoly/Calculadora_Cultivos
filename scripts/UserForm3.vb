' UserForm3 - Calculadora Manual de Nutrientes
Option Explicit

Private Sub UserForm_Initialize()
    Me.Caption = "Calculadora Manual de Nutrientes"
    
    ' Cargar 20 cultivos
    With cmbCultivo
        .Clear
        .AddItem "Cacao"
        .AddItem "Café"
        .AddItem "Maíz"
        .AddItem "Arroz"
        .AddItem "Plátano"
        .AddItem "Tomate"
        .AddItem "Papa"
        .AddItem "Frijol"
        .AddItem "Soja"
        .AddItem "Trigo"
        .AddItem "Cebolla"
        .AddItem "Lechuga"
        .AddItem "Zanahoria"
        .AddItem "Algodón"
        .AddItem "Caña de azúcar"
        .AddItem "Yuca"
        .AddItem "Ñame"
        .AddItem "Aguacate"
        .AddItem "Mango"
        .AddItem "Cítricos"
    End With
    
    ' Cargar nutrientes
    With cmbNutriente
        .Clear
        .AddItem "Nitrógeno (N)"
        .AddItem "Fósforo (P2O5)"
        .AddItem "Potasio (K2O)"
        .AddItem "Calcio (Ca)"
        .AddItem "Magnesio (Mg)"
    End With
    
    Call LimpiarFormulario
End Sub

Private Sub btnCalcular_Click()
    On Error GoTo ErrorHandler
    
    ' Validar campos
    If cmbCultivo.Value = "" Or cmbEtapa.Value = "" Or cmbNutriente.Value = "" Or _
       cmbFertilizante.Value = "" Or txtArea.Value = "" Then
        MsgBox "Completa todos los campos antes de calcular.", vbExclamation, "Campos incompletos"
        Exit Sub
    End If
    
    If Not IsNumeric(txtArea.Value) Or Val(txtArea.Value) <= 0 Then
        MsgBox "Ingresa un área válida (mayor a 0).", vbExclamation, "Valor inválido"
        txtArea.SetFocus
        Exit Sub
    End If
    
    Dim requerimiento As Double
    Dim area As Double
    Dim concentracion As Double
    Dim dosis As Double
    
    requerimiento = ObtenerRequerimiento(cmbCultivo.Value, cmbEtapa.Value, cmbNutriente.Value)
    area = Val(txtArea.Value)
    concentracion = Val(Replace(lblConcentracion.Caption, "%", ""))
    
    If concentracion = 0 Then
        MsgBox "Concentración inválida. Verifica el fertilizante seleccionado.", vbCritical, "Error"
        Exit Sub
    End If
    
    If requerimiento = 0 Then
        MsgBox "No se encontraron datos para la combinación seleccionada.", vbExclamation, "Datos no encontrados"
        Exit Sub
    End If
    
    ' Calcular dosis de fertilizante
    dosis = (requerimiento * area) / (concentracion / 100)
    
    lblDosisResultado.Caption = Format(dosis, "0.00") & " kg"
    
    ' Mostrar información adicional
    lblInfo.Caption = "Para " & area & " ha de " & cmbCultivo.Value & " en etapa de " & _
                     cmbEtapa.Value & ", necesitas " & Format(dosis, "0.00") & " kg de " & _
                     cmbFertilizante.Value & " para aportar " & requerimiento & " kg/ha de " & cmbNutriente.Value
    
    Exit Sub
    
ErrorHandler:
    MsgBox "Error en el cálculo: " & Err.Description, vbCritical, "Error"
End Sub

Private Sub btnLimpiar_Click()
    Call LimpiarFormulario
End Sub

Private Sub LimpiarFormulario()
    cmbCultivo.Value = ""
    cmbEtapa.Clear
    cmbNutriente.Value = ""
    cmbFertilizante.Clear
    lblConcentracion.Caption = ""
    txtArea.Value = ""
    lblDosisResultado.Caption = ""
    lblRequerimiento.Caption = ""
    lblInfo.Caption = ""
End Sub

Private Sub cmbCultivo_Change()
    If cmbCultivo.Value <> "" Then
        With cmbEtapa
            .Clear
            .AddItem "Crecimiento"
            .AddItem "Floración"
            .AddItem "Desarrollo del fruto"
        End With
    End If
    Call ActualizarRequerimiento
End Sub

Private Sub cmbEtapa_Change()
    Call ActualizarRequerimiento
End Sub

Private Sub cmbNutriente_Change()
    ' Limpiar fertilizantes y concentración
    cmbFertilizante.Clear
    lblConcentracion.Caption = ""
    
    ' Cargar fertilizantes según el nutriente seleccionado
    Select Case LCase(cmbNutriente.Value)
        Case "nitrógeno (n)"
            With cmbFertilizante
                .AddItem "Urea"
                .AddItem "Nitrato de amonio"
                .AddItem "Sulfato de amonio"
            End With
        Case "fósforo (p2o5)"
            With cmbFertilizante
                .AddItem "DAP"
                .AddItem "MAP"
                .AddItem "Superfosfato triple"
            End With
        Case "potasio (k2o)"
            With cmbFertilizante
                .AddItem "Cloruro de potasio"
                .AddItem "Sulfato de potasio"
            End With
        Case "calcio (ca)"
            With cmbFertilizante
                .AddItem "Nitrato de calcio"
                .AddItem "Yeso agrícola"
                .AddItem "Dolomita"
            End With
        Case "magnesio (mg)"
            With cmbFertilizante
                .AddItem "Sulfato de magnesio"
                .AddItem "Dolomita"
            End With
    End Select
    
    Call ActualizarRequerimiento
End Sub

Private Sub cmbFertilizante_Change()
    ' Obtener concentración del fertilizante
    Dim concentracion As Double
    concentracion = ObtenerConcentracionFertilizante(cmbFertilizante.Value, cmbNutriente.Value)
    
    If concentracion > 0 Then
        lblConcentracion.Caption = concentracion & "%"
    Else
        lblConcentracion.Caption = "N/A"
    End If
End Sub

Private Sub ActualizarRequerimiento()
    If cmbCultivo.Value <> "" And cmbEtapa.Value <> "" And cmbNutriente.Value <> "" Then
        Dim req As Double
        req = ObtenerRequerimiento(cmbCultivo.Value, cmbEtapa.Value, cmbNutriente.Value)
        
        If req > 0 Then
            lblRequerimiento.Caption = req & " kg/ha"
        Else
            lblRequerimiento.Caption = "No disponible"
        End If
    Else
        lblRequerimiento.Caption = ""
    End If
End Sub

Private Sub cmdCerrar_Click()
    Unload Me
End Sub
