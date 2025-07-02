' UserForm2 - Calculadora por Área
Option Explicit

Private Sub UserForm_Initialize()
    Me.Caption = "Calculadora de Fertilizantes por Área"
    
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
    
    ' Cargar etapas
    With cmbEtapa
        .Clear
        .AddItem "Crecimiento"
        .AddItem "Floración"
        .AddItem "Desarrollo del fruto"
    End With
    
    Call LimpiarFormulario
End Sub

Private Sub btnCalcular_Click()
    On Error GoTo ErrorHandler
    
    ' Validar área
    If Not IsNumeric(txtArea.Text) Or Val(txtArea.Text) <= 0 Then
        MsgBox "Ingresa un valor de área válido (mayor a 0).", vbExclamation, "Valor inválido"
        txtArea.SetFocus
        Exit Sub
    End If
    
    ' Validar que se hayan seleccionado cultivo y etapa
    If cmbCultivo.Value = "" Then
        MsgBox "Selecciona un cultivo.", vbExclamation, "Campo requerido"
        cmbCultivo.SetFocus
        Exit Sub
    End If
    
    If cmbEtapa.Value = "" Then
        MsgBox "Selecciona una etapa.", vbExclamation, "Campo requerido"
        cmbEtapa.SetFocus
        Exit Sub
    End If
    
    Dim area As Double
    Dim n As Double, p As Double, k As Double
    Dim urea As Double, dap As Double, kcl As Double
    
    area = CDbl(txtArea.Text)
    n = CDbl(lblNreq.Tag)
    p = CDbl(lblPreq.Tag)
    k = CDbl(lblKreq.Tag)
    
    ' Calcular fertilizantes necesarios
    urea = (area * n) / 0.46  ' Urea 46% N
    dap = (area * p) / 0.46   ' DAP 46% P2O5
    kcl = (area * k) / 0.6    ' KCl 60% K2O
    
    ' Mostrar resultados
    lblUrea.Caption = "Urea necesaria: " & Format(urea, "0.00") & " kg"
    lblDAP.Caption = "DAP necesario: " & Format(dap, "0.00") & " kg"
    lblKCL.Caption = "KCl necesario: " & Format(kcl, "0.00") & " kg"
    
    ' Calcular costo estimado (opcional)
    Dim costoTotal As Double
    costoTotal = (urea * 0.5) + (dap * 0.8) + (kcl * 0.6) ' Precios ejemplo por kg
    lblCosto.Caption = "Costo estimado: $" & Format(costoTotal, "0.00")
    
    Exit Sub
    
ErrorHandler:
    MsgBox "Error en el cálculo: " & Err.Description, vbCritical, "Error"
End Sub

Private Sub btnLimpiar_Click()
    Call LimpiarFormulario
End Sub

Private Sub LimpiarFormulario()
    txtArea.Text = ""
    cmbCultivo.ListIndex = -1
    cmbEtapa.ListIndex = -1
    
    lblNreq.Caption = "N: "
    lblPreq.Caption = "P2O5: "
    lblKreq.Caption = "K2O: "
    lblNreq.Tag = ""
    lblPreq.Tag = ""
    lblKreq.Tag = ""
    
    lblUrea.Caption = "Urea necesaria: "
    lblDAP.Caption = "DAP necesario: "
    lblKCL.Caption = "KCl necesario: "
    lblCosto.Caption = "Costo estimado: "
End Sub

Private Sub cmbCultivo_Change()
    Call ActualizarRequerimientos
End Sub

Private Sub cmbEtapa_Change()
    Call ActualizarRequerimientos
End Sub

Private Sub ActualizarRequerimientos()
    If cmbCultivo.Value = "" Or cmbEtapa.Value = "" Then Exit Sub
    
    Dim cultivo As String, etapa As String
    Dim n As Double, p As Double, k As Double
    
    cultivo = cmbCultivo.Value
    etapa = cmbEtapa.Value
    
    ' Obtener requerimientos usando la función del módulo
    n = ObtenerRequerimiento(cultivo, etapa, "Nitrógeno (N)")
    p = ObtenerRequerimiento(cultivo, etapa, "Fósforo (P2O5)")
    k = ObtenerRequerimiento(cultivo, etapa, "Potasio (K2O)")
    
    ' Actualizar etiquetas
    lblNreq.Caption = "N: " & n & " kg/ha"
    lblPreq.Caption = "P2O5: " & p & " kg/ha"
    lblKreq.Caption = "K2O: " & k & " kg/ha"
    
    ' Guardar valores en Tag para usar en cálculos
    lblNreq.Tag = n
    lblPreq.Tag = p
    lblKreq.Tag = k
End Sub

Private Sub cmdCerrar_Click()
    Unload Me
End Sub
