' Módulo con funciones de cálculo de requerimientos nutricionales
Option Explicit

Public Function ObtenerRequerimiento(cultivo As String, etapa As String, nutriente As String) As Double
    ' Función expandida para 20 cultivos con requerimientos nutricionales completos
    
    Select Case LCase(Trim(cultivo))
        ' --- MAÍZ ---
        Case "maíz", "maiz"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 40
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 15
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 8
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 100
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 40
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 70
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 20
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 80
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 90
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 10
                    End Select
            End Select
            
        ' --- CACAO ---
        Case "cacao"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 30
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 15
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 40
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 20
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 10
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 50
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 50
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 40
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 20
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 70
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
            End Select
            
        ' --- CAFÉ ---
        Case "café", "cafe"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 35
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 20
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 50
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 18
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 10
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 60
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 22
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 55
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 80
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 26
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
            End Select
            
        ' --- ARROZ ---
        Case "arroz"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 50
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 20
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 30
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 12
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 7
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 80
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 60
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 18
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 9
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 70
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 70
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 20
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 10
                    End Select
            End Select
            
        ' --- PLÁTANO ---
        Case "plátano", "platano"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 40
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 15
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 60
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 22
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 14
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 20
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 80
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 26
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 16
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 70
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 100
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 18
                    End Select
            End Select

        ' --- TOMATE ---
        Case "tomate"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 80
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 40
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 60
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 120
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 60
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 100
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 45
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 20
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 100
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 50
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 140
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 50
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 25
                    End Select
            End Select

        ' --- PAPA ---
        Case "papa"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 70
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 80
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 90
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 45
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 120
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 80
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 40
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 150
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 18
                    End Select
            End Select

        ' --- FRIJOL ---
        Case "frijol", "fréjol"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 25
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 40
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 20
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 10
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 35
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 40
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 50
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 30
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 60
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
            End Select

        ' --- SOJA ---
        Case "soja", "soya"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 30
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 45
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 40
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 45
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 60
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 50
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 40
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 80
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 18
                    End Select
            End Select

        ' --- TRIGO ---
        Case "trigo"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 35
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 15
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 8
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 90
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 50
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 20
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 10
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 80
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 45
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 18
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
            End Select

        ' --- CEBOLLA ---
        Case "cebolla"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 70
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 80
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 40
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 90
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 70
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 100
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 18
                    End Select
            End Select

        ' --- LECHUGA ---
        Case "lechuga"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 50
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 60
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 70
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 80
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 40
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 18
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 70
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 20
                    End Select
            End Select

        ' --- ZANAHORIA ---
        Case "zanahoria"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 45
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 80
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 40
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 100
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 50
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 120
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 18
                    End Select
            End Select

        ' --- ALGODÓN ---
        Case "algodón", "algodon"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 70
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 60
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 100
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 45
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 80
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 40
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 20
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 90
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 40
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 100
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 45
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 25
                    End Select
            End Select

        ' --- CAÑA DE AZÚCAR ---
        Case "caña de azúcar", "cana de azucar"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 80
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 90
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 120
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 40
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 130
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 20
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 100
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 150
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 40
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 25
                    End Select
            End Select

        ' --- YUCA ---
        Case "yuca"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 40
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 60
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 20
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 12
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 50
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 80
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 45
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 28
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 100
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 18
                    End Select
            End Select

        ' --- ÑAME ---
        Case "ñame", "name"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 45
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 70
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 25
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 15
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 90
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 18
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 55
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 32
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 110
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 20
                    End Select
            End Select

        ' --- AGUACATE ---
        Case "aguacate", "palta"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 80
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 20
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 80
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 100
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 40
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 25
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 70
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 120
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 45
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 30
                    End Select
            End Select

        ' --- MANGO ---
        Case "mango"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 50
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 20
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 70
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 30
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 18
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 70
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 90
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 35
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 22
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 60
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 110
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 40
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 25
                    End Select
            End Select

        ' --- CÍTRICOS ---
        Case "cítricos", "citricos", "naranja", "limón", "limon", "mandarina"
            Select Case LCase(Trim(etapa))
                Case "crecimiento"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 55
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 25
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 75
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 40
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 20
                    End Select
                Case "floración", "floracion"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 75
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 35
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 95
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 45
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 25
                    End Select
                Case "desarrollo del fruto"
                    Select Case LCase(Trim(nutriente))
                        Case "nitrógeno (n)", "nitrogeno (n)", "n": ObtenerRequerimiento = 65
                        Case "fósforo (p2o5)", "fosforo (p2o5)", "p2o5", "p": ObtenerRequerimiento = 30
                        Case "potasio (k2o)", "k2o", "k": ObtenerRequerimiento = 115
                        Case "calcio (ca)", "ca": ObtenerRequerimiento = 50
                        Case "magnesio (mg)", "mg": ObtenerRequerimiento = 28
                    End Select
            End Select
            
        Case Else
            ObtenerRequerimiento = 0
    End Select
End Function

Public Function ObtenerConcentracionFertilizante(fertilizante As String, nutriente As String) As Double
    ' Función para obtener la concentración de nutrientes en fertilizantes
    
    Select Case LCase(Trim(fertilizante))
        Case "urea", "urea (46-00-00)"
            If LCase(Trim(nutriente)) = "nitrógeno (n)" Or LCase(Trim(nutriente)) = "n" Then
                ObtenerConcentracionFertilizante = 46
            End If
        Case "sulfato de amonio", "sulfato de amonio (21-00-00)"
            If LCase(Trim(nutriente)) = "nitrógeno (n)" Or LCase(Trim(nutriente)) = "n" Then
                ObtenerConcentracionFertilizante = 21
            End If
        Case "nitrato de amonio"
            If LCase(Trim(nutriente)) = "nitrógeno (n)" Or LCase(Trim(nutriente)) = "n" Then
                ObtenerConcentracionFertilizante = 34
            End If
        Case "dap", "dap (18-46-00)"
            Select Case LCase(Trim(nutriente))
                Case "nitrógeno (n)", "n": ObtenerConcentracionFertilizante = 18
                Case "fósforo (p2o5)", "p2o5", "p": ObtenerConcentracionFertilizante = 46
            End Select
        Case "map", "map (11-52-00)"
            Select Case LCase(Trim(nutriente))
                Case "nitrógeno (n)", "n": ObtenerConcentracionFertilizante = 11
                Case "fósforo (p2o5)", "p2o5", "p": ObtenerConcentracionFertilizante = 52
            End Select
        Case "superfosfato triple"
            If LCase(Trim(nutriente)) = "fósforo (p2o5)" Or LCase(Trim(nutriente)) = "p2o5" Or LCase(Trim(nutriente)) = "p" Then
                ObtenerConcentracionFertilizante = 46
            End If
        Case "kcl", "kcl (00-00-60)", "cloruro de potasio"
            If LCase(Trim(nutriente)) = "potasio (k2o)" Or LCase(Trim(nutriente)) = "k2o" Or LCase(Trim(nutriente)) = "k" Then
                ObtenerConcentracionFertilizante = 60
            End If
        Case "sulfato de potasio"
            If LCase(Trim(nutriente)) = "potasio (k2o)" Or LCase(Trim(nutriente)) = "k2o" Or LCase(Trim(nutriente)) = "k" Then
                ObtenerConcentracionFertilizante = 50
            End If
        Case "npk 15-15-15"
            Select Case LCase(Trim(nutriente))
                Case "nitrógeno (n)", "n": ObtenerConcentracionFertilizante = 15
                Case "fósforo (p2o5)", "p2o5", "p": ObtenerConcentracionFertilizante = 15
                Case "potasio (k2o)", "k2o", "k": ObtenerConcentracionFertilizante = 15
            End Select
        Case "nitrato de calcio"
            Select Case LCase(Trim(nutriente))
                Case "nitrógeno (n)", "n": ObtenerConcentracionFertilizante = 15
                Case "calcio (ca)", "ca": ObtenerConcentracionFertilizante = 19
            End Select
        Case "yeso agrícola", "yeso agricola"
            If LCase(Trim(nutriente)) = "calcio (ca)" Or LCase(Trim(nutriente)) = "ca" Then
                ObtenerConcentracionFertilizante = 23
            End If
        Case "sulfato de magnesio"
            If LCase(Trim(nutriente)) = "magnesio (mg)" Or LCase(Trim(nutriente)) = "mg" Then
                ObtenerConcentracionFertilizante = 10
            End If
        Case "dolomita"
            Select Case LCase(Trim(nutriente))
                Case "calcio (ca)", "ca": ObtenerConcentracionFertilizante = 22
                Case "magnesio (mg)", "mg": ObtenerConcentracionFertilizante = 15
            End Select
        Case Else
            ObtenerConcentracionFertilizante = 0
    End Select
End Function
