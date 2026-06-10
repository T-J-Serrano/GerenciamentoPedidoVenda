inherited FORM_FS_GERENCIAMENTO_PEDIDOVENDA: TFormScriptMegaManutencao
  Left = -8
  Top = -8
  BorderIcons = [biSystemMenu, biMaximize]
  Caption = ''
  ClientHeight = 801
  ClientWidth = 1536
  Menu = mgMainMenu1
  Position = poDesigned
  WindowState = wsMaximized
  ExplicitLeft = -8
  ExplicitTop = -8
  ExplicitWidth = 1552
  ExplicitHeight = 840
  PixelsPerInch = 96
  TextHeight = 15
  inherited shpLinhaBottom: TMgShape
    Top = 745
    Width = 1536
    ExplicitTop = 673
    ExplicitWidth = 1008
  end
  inherited Pn_Base: TmgPanel
    Top = 1
    Width = 1536
    Height = 741
    ExplicitTop = 47
    ExplicitWidth = 1008
    ExplicitHeight = 641
    inherited PageControl1: TmgPageControl
      Width = 1530
      Height = 735
      Properties.ActivePage = Ts_Filtros
      ActivePage = Ts_Filtros
      ExplicitLeft = 1
      ExplicitTop = -16
      ExplicitWidth = 1360
      ExplicitHeight = 593
      ClientRectBottom = 733
      ClientRectRight = 1528
      object Ts_Filtros: TcxTabSheet [0]
        Caption = 'Filtros'
        ExplicitLeft = 0
        ExplicitTop = 22
        ExplicitWidth = 1358
        ExplicitHeight = 615
        object Pn_Top: TmgPanel
          Left = 0
          Top = 0
          Width = 1526
          Height = 246
          Align = alTop
          BevelOuter = bvNone
          ParentColor = True
          TabOrder = 0
          ExplicitWidth = 1358
          object Gb_SubGrupos: TmgGroupBox
            Left = 750
            Top = 0
            Caption = 'Subgrupos'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 5
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 120
            object Ed_SubGruposInicial: TMgDBEditConsulta
              Left = 9
              Top = 36
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 95
            end
            object Ed_SubGruposFinal: TMgDBEditConsulta
              Left = 9
              Top = 76
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 95
            end
            object mgLabel5: TmgLabel
              Left = 9
              Top = 18
              Caption = 'C'#243'digo Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object mgLabel6: TmgLabel
              Left = 9
              Top = 58
              Caption = 'C'#243'digo Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
          end
          object Gb_Emissao: TmgGroupBox
            Left = 508
            Top = 0
            Caption = 'Data de Emiss'#227'o'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 3
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 120
            object mgLabel3: TmgLabel
              Left = 10
              Top = 18
              Caption = 'Data Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Ed_EmissaoInicial: TMgDBDateEdit
              Left = 10
              Top = 36
              AutoSize = False
              DataBinding.DataField = 'EMISSAO_INICIAL'
              Enabled = False
              ParentFont = False
              Properties.ButtonGlyph.SourceDPI = 96
              Properties.ButtonGlyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E000A4A0A0FF4060
                60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF406060FFA4A0A0FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFFA4A0A0FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FF8080
                80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF808080FF808080FF4020E0004020E000808080FFC0DC
                C0FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E000C0DCC0FF808080FF4020E0004020E000C0DCC0FF8080
                80FF808080FF4020E000808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                80FF4020E000808080FF808080FFC0DCC0FF4020E0004020E0004020E0004020
                E0004020E0004020E000808080FF4020E0004020E0004020E0004020E0008080
                80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E000}
              Properties.DisplayFormat = 'dd/MM/yyyy'
              Properties.EditFormat = 'dd/MM/yyyy'
              Properties.ImmediatePost = True
              Properties.PostPopupValueOnTab = True
              Properties.SaveTime = False
              Properties.ShowTime = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideUnselected
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              Value = -657435.000000000000000000
              DateValue = '31/12/0099'
              Height = 21
              Width = 95
            end
            object mgLabel4: TmgLabel
              Left = 10
              Top = 58
              Caption = 'Data Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Ed_EmissaoFinal: TMgDBDateEdit
              Left = 10
              Top = 76
              AutoSize = False
              DataBinding.DataField = 'EMISSAO_FINAL'
              Enabled = False
              ParentFont = False
              Properties.ButtonGlyph.SourceDPI = 96
              Properties.ButtonGlyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E000A4A0A0FF4060
                60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF406060FFA4A0A0FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFFA4A0A0FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FF8080
                80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF808080FF808080FF4020E0004020E000808080FFC0DC
                C0FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E000C0DCC0FF808080FF4020E0004020E000C0DCC0FF8080
                80FF808080FF4020E000808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                80FF4020E000808080FF808080FFC0DCC0FF4020E0004020E0004020E0004020
                E0004020E0004020E000808080FF4020E0004020E0004020E0004020E0008080
                80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E000}
              Properties.DisplayFormat = 'dd/MM/yyyy'
              Properties.EditFormat = 'dd/MM/yyyy'
              Properties.ImmediatePost = True
              Properties.PostPopupValueOnTab = True
              Properties.SaveTime = False
              Properties.ShowTime = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideUnselected
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 3
              Value = -657435.000000000000000000
              DateValue = '31/12/0099'
              Height = 21
              Width = 95
            end
          end
          object Gb_Entrega: TmgGroupBox
            Left = 266
            Top = 0
            Caption = 'Data de Entrega'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 1
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 120
            object Ed_EntregaInicial: TMgDBDateEdit
              Left = 10
              Top = 36
              AutoSize = False
              DataBinding.DataField = 'ENTREGA_INICIAL'
              Enabled = False
              ParentFont = False
              Properties.ButtonGlyph.SourceDPI = 96
              Properties.ButtonGlyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E000A4A0A0FF4060
                60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF406060FFA4A0A0FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFFA4A0A0FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FF8080
                80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF808080FF808080FF4020E0004020E000808080FFC0DC
                C0FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E000C0DCC0FF808080FF4020E0004020E000C0DCC0FF8080
                80FF808080FF4020E000808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                80FF4020E000808080FF808080FFC0DCC0FF4020E0004020E0004020E0004020
                E0004020E0004020E000808080FF4020E0004020E0004020E0004020E0008080
                80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E000}
              Properties.DisplayFormat = 'dd/MM/yyyy'
              Properties.EditFormat = 'dd/MM/yyyy'
              Properties.ImmediatePost = True
              Properties.PostPopupValueOnTab = True
              Properties.SaveTime = False
              Properties.ShowTime = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideUnselected
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              Value = -657435.000000000000000000
              DateValue = '31/12/0099'
              Height = 21
              Width = 95
            end
            object Ed_EntregaFinal: TMgDBDateEdit
              Left = 10
              Top = 76
              AutoSize = False
              DataBinding.DataField = 'ENTREGA_FINAL'
              Enabled = False
              ParentFont = False
              Properties.ButtonGlyph.SourceDPI = 96
              Properties.ButtonGlyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E000A4A0A0FF4060
                60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF406060FFA4A0A0FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFFA4A0A0FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FF8080
                80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF808080FF808080FF4020E0004020E000808080FFC0DC
                C0FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E000C0DCC0FF808080FF4020E0004020E000C0DCC0FF8080
                80FF808080FF4020E000808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                80FF4020E000808080FF808080FFC0DCC0FF4020E0004020E0004020E0004020
                E0004020E0004020E000808080FF4020E0004020E0004020E0004020E0008080
                80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E000}
              Properties.DisplayFormat = 'dd/MM/yyyy'
              Properties.EditFormat = 'dd/MM/yyyy'
              Properties.ImmediatePost = True
              Properties.PostPopupValueOnTab = True
              Properties.SaveTime = False
              Properties.ShowTime = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideUnselected
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              Value = -657435.000000000000000000
              DateValue = '31/12/0099'
              Height = 21
              Width = 95
            end
            object mgLabel1: TmgLabel
              Left = 10
              Top = 18
              Caption = 'Data Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object mgLabel2: TmgLabel
              Left = 10
              Top = 58
              Caption = 'Data Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
          end
          object Gb_Mercado: TmgGroupBox
            Left = 0
            Top = 0
            TabStop = False
            Caption = 'Mercado'
            CheckBox.Visible = False
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 0
            Checked = True
            Height = 110
            Width = 265
            object Ck_B2B: TMgDBCheckBox
              Left = 17
              Top = 27
              Caption = 'B2B'
              ParentBackground = False
              Properties.Alignment = taRightJustify
              Properties.ReadOnly = False
              Properties.ValueChecked = 'S'
              Properties.ValueUnchecked = 'N'
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = clWhite
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              Alignment = taRightJustify
              ValueChecked = 'S'
              ValueUnchecked = 'N'
            end
            object Ck_B2C: TMgDBCheckBox
              Left = 17
              Top = 51
              Caption = 'B2C'
              ParentBackground = False
              Properties.Alignment = taRightJustify
              Properties.ReadOnly = False
              Properties.ValueChecked = 'S'
              Properties.ValueUnchecked = 'N'
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = clWhite
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              Alignment = taRightJustify
              ValueChecked = 'S'
              ValueUnchecked = 'N'
            end
            object Ck_Exportacao: TMgDBCheckBox
              Left = 17
              Top = 75
              Caption = 'Exporta'#231#227'o'
              ParentBackground = False
              Properties.Alignment = taRightJustify
              Properties.ReadOnly = False
              Properties.ValueChecked = 'S'
              Properties.ValueUnchecked = 'N'
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = clWhite
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 2
              Alignment = taRightJustify
              ValueChecked = 'S'
              ValueUnchecked = 'N'
            end
            object Ck_HIBRIDO: TMgDBCheckBox
              Left = 114
              Top = 27
              Caption = 'H'#237'brido'
              ParentBackground = False
              Properties.Alignment = taRightJustify
              Properties.NullStyle = nssUnchecked
              Properties.ReadOnly = False
              Properties.ValueChecked = 'S'
              Properties.ValueUnchecked = 'N'
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = clWhite
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 3
              Alignment = taRightJustify
              ValueChecked = 'S'
              ValueUnchecked = 'N'
            end
            object Ck_OUTROS: TMgDBCheckBox
              Left = 114
              Top = 51
              Caption = 'Outros'
              ParentBackground = False
              Properties.Alignment = taRightJustify
              Properties.NullStyle = nssUnchecked
              Properties.ReadOnly = False
              Properties.ValueChecked = 'S'
              Properties.ValueUnchecked = 'N'
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = clWhite
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 4
              Alignment = taRightJustify
              ValueChecked = 'S'
              ValueUnchecked = 'N'
            end
            object Ck_Indefinido: TMgDBCheckBox
              Left = 114
              Top = 75
              Caption = 'Mercado n'#227'o definido'
              ParentBackground = False
              Properties.Alignment = taRightJustify
              Properties.NullStyle = nssUnchecked
              Properties.ReadOnly = False
              Properties.ValueChecked = 'S'
              Properties.ValueUnchecked = 'N'
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = clWhite
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 5
              Alignment = taRightJustify
              ValueChecked = 'S'
              ValueUnchecked = 'N'
            end
          end
          object Gb_Grupos: TmgGroupBox
            Left = 629
            Top = 0
            Caption = 'Grupos'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 4
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 120
            object Ed_GruposInicial: TMgDBEditConsulta
              Left = 9
              Top = 36
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 95
            end
            object Ed_GruposFinal: TMgDBEditConsulta
              Left = 9
              Top = 76
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 95
            end
            object mgLabel7: TmgLabel
              Left = 9
              Top = 18
              Caption = 'C'#243'digo Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object mgLabel8: TmgLabel
              Left = 9
              Top = 58
              Caption = 'C'#243'digo Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
          end
          object Gb_CodItem: TmgGroupBox
            Left = 871
            Top = 0
            Caption = 'C'#243'digo do Item'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 6
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 120
            object Ed_CodItemInicial: TMgDBEditConsulta
              Left = 10
              Top = 36
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 95
            end
            object Ed_CodItemFinal: TMgDBEditConsulta
              Left = 10
              Top = 76
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 95
            end
            object mgLabel9: TmgLabel
              Left = 10
              Top = 18
              Caption = 'C'#243'digo Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object mgLabel10: TmgLabel
              Left = 10
              Top = 58
              Caption = 'C'#243'digo Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
          end
          object Gb_ITP_ST_PEDIDOCLIENTE: TmgGroupBox
            Left = 992
            Top = 57
            Caption = 'OC do Cliente'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 13
            ExibeCheckBox = True
            Checked = False
            Height = 53
            Width = 350
            object Ed_ITP_ST_PEDIDOCLIENTE: TMgDBEdit
              Left = 10
              Top = 21
              AutoSize = False
              Enabled = False
              Properties.AlwaysShowBlanksAndLiterals = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              Password = False
              Height = 21
              Width = 330
            end
          end
          object Gb_TipoDoc: TmgGroupBox
            Left = 992
            Top = 0
            Caption = 'Tipo de Documento'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 7
            ExibeCheckBox = True
            Checked = False
            Height = 53
            Width = 350
            object Ed_TipoDoc: TMgDBEditConsulta
              Left = 10
              Top = 25
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 75
            end
            object Ed_TipoDocDesc: TMgDBEdit
              Left = 89
              Top = 25
              AutoSize = False
              Enabled = False
              Properties.AlwaysShowBlanksAndLiterals = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              Password = False
              Height = 21
              Width = 250
            end
          end
          object Gb_Cliente: TmgGroupBox
            Left = 0
            Top = 119
            Caption = 'C'#243'digo Cliente'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 8
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 132
            object Ed_ClienteInicial: TMgDBEditConsulta
              Left = 9
              Top = 36
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 100
            end
            object Ed_ClienteFinal: TMgDBEditConsulta
              Left = 9
              Top = 76
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 100
            end
            object mgLabel13: TmgLabel
              Left = 9
              Top = 18
              Caption = 'C'#243'digo Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object mgLabel14: TmgLabel
              Left = 9
              Top = 58
              Caption = 'C'#243'digo Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
          end
          object Gb_GrupoCliente: TmgGroupBox
            Left = 133
            Top = 119
            Caption = 'Grupo Cliente'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 9
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 132
            object cLb_CodInicial: TmgLabel
              Left = 9
              Top = 18
              Caption = 'Código Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object cLb_CodFinal: TmgLabel
              Left = 9
              Top = 58
              Caption = 'Código Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Ed_GrupoClienteInicial: TMgDBEditConsulta
              Left = 9
              Top = 36
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 100
            end
            object Ed_GrupoClienteFinal: TMgDBEditConsulta
              Left = 9
              Top = 76
              AutoSize = False
              Enabled = False
              ParentFont = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Font.Charset = DEFAULT_CHARSET
              Font.Color = clWindowText
              Font.Height = -11
              Font.Name = 'Tahoma'
              Font.Style = []
              Height = 21
              Width = 100
            end
          end
          object Gb_Pedido: TmgGroupBox
            Left = 266
            Top = 119
            Caption = 'N'#186' Pedido'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 9
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 132
            object mgLabel11: TmgLabel
              Left = 9
              Top = 18
              Caption = 'N'#186' Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object mgLabel12: TmgLabel
              Left = 9
              Top = 58
              Caption = 'N'#186' Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Ed_PedidoInicial: TMgDBEdit
              Left = 9
              Top = 36
              AutoSize = False
              DataBinding.DataField = 'PEDIDO_FINAL'
              Enabled = False
              Properties.AlwaysShowBlanksAndLiterals = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 2
              Password = False
              Height = 21
              Width = 91
            end
            object Ed_PedidoFinal: TMgDBEdit
              Left = 9
              Top = 76
              AutoSize = False
              DataBinding.DataField = 'PEDIDO_FINAL'
              Enabled = False
              Properties.AlwaysShowBlanksAndLiterals = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 3
              Password = False
              Height = 21
              Width = 91
            end
          end
          object Gb_NotaFiscal: TmgGroupBox
            Left = 907
            Top = 119
            Caption = 'Pedido Faturado'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 14
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 132
            object mgLabel16: TmgLabel
              Left = 10
              Top = 18
              Caption = 'N'#186' NF. Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object mgLabel17: TmgLabel
              Left = 10
              Top = 58
              Caption = 'N'#186' NF. Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Ed_NotaInicial: TMgDBEdit
              Left = 10
              Top = 36
              AutoSize = False
              DataBinding.DataField = 'NOTA_INICIAL'
              Enabled = False
              Properties.AlwaysShowBlanksAndLiterals = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 2
              Password = False
              Height = 21
              Width = 91
            end
            object Ed_NotaFinal: TMgDBEdit
              Left = 10
              Top = 76
              AutoSize = False
              DataBinding.DataField = 'NOTA_FINAL'
              Enabled = False
              Properties.AlwaysShowBlanksAndLiterals = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 3
              Password = False
              Height = 21
              Width = 91
            end
          end
          object Gb_Status: TmgGroupBox
            Left = 399
            Top = 119
            Caption = 'Status do Pedido'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 10
            ExibeCheckBox = True
            Checked = False
            Height = 53
            Width = 362
            object Cb_StatusPedido: TmgComboBox
              Left = 9
              Top = 24
              AutoSize = False
              Enabled = False
              ItemIndex = -1
              ParentColor = True
              Properties.DropDownListStyle = lsEditFixedList
              Properties.Items.Strings = (
                'Pedido em Aberto'
                'Pedido Bloqueado'
                'Pedido Faturado Totalmente'
                'Pedido Faturado Parcialmente'
                'Pedido Cancelado')
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.ButtonTransparency = ebtHideInactive
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              Height = 23
              Width = 345
            end
          end
          object Gb_StatusEntrega: TmgGroupBox
            Left = 399
            Top = 176
            Caption = 'Status da Entrega'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 11
            ExibeCheckBox = True
            Checked = False
            Height = 53
            Width = 149
            object Cb_EntregaStatus: TmgComboBox
              Left = 9
              Top = 24
              AutoSize = False
              Enabled = False
              ItemIndex = -1
              ParentColor = True
              Properties.DropDownListStyle = lsEditFixedList
              Properties.Items.Strings = (
                'Liberado'
                'Bloqueado')
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.ButtonTransparency = ebtHideInactive
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              Height = 23
              Width = 125
            end
          end
          object Gb_Prioridade: TmgGroupBox
            Left = 557
            Top = 176
            Caption = 'Prioridade de Entrega'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 12
            ExibeCheckBox = True
            Checked = False
            Height = 53
            Width = 204
            object Cb_Prioridade: TmgComboBox
              Left = 10
              Top = 24
              AutoSize = False
              Enabled = False
              ItemIndex = -1
              ParentColor = True
              Properties.DropDownListStyle = lsEditFixedList
              Properties.Items.Strings = (
                '0-Prioridade N'#227'o definida'
                '1-Prioridade Baixa'
                '2-Prioridade M'#233'dia'
                '3-Prioridade Alta'
                '9-Exporta'#231#227'o')
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.ButtonTransparency = ebtHideInactive
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              Height = 23
              Width = 181
            end
          end
          object Gb_PedidoParcial: TmgRadioGroup
            Left = 762
            Top = 119
            Caption = 'Aceita Pedido Parcial ?'
            Properties.Items = <>
            Style.BorderColor = 6579300
            Style.BorderStyle = ebsUltraFlat
            Style.Edges = [bLeft, bTop, bRight, bBottom]
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            StyleDisabled.BorderColor = 10526880
            StyleDisabled.BorderStyle = ebsUltraFlat
            StyleDisabled.Color = clWhite
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            StyleDisabled.TextColor = 6710886
            TabOrder = 17
            SemMoldura = False
            Height = 110
            Width = 144
            object Op_Sim: TmgRadioButton
              Left = 15
              Top = 32
              Width = 113
              Height = 17
              Caption = 'Sim'
              TabOrder = 0
              LookAndFeel.NativeStyle = False
              LookAndFeel.SkinName = ''
            end
            object Op_Todos: TmgRadioButton
              Left = 15
              Top = 72
              Width = 113
              Height = 17
              Caption = 'Todos'
              Checked = True
              TabOrder = 1
              TabStop = True
              LookAndFeel.NativeStyle = False
              LookAndFeel.SkinName = ''
            end
            object Op_Nao: TmgRadioButton
              Left = 15
              Top = 52
              Width = 113
              Height = 17
              Caption = 'N'#227'o'
              TabOrder = 2
              LookAndFeel.NativeStyle = False
              LookAndFeel.SkinName = ''
            end
          end
          object Gb_StatusOE: TmgGroupBox
            Left = 1041
            Top = 119
            Caption = 'Status da OE'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 15
            ExibeCheckBox = True
            Checked = False
            Height = 53
            Width = 380
            object Cb_StatusOE: TmgComboBox
              Left = 10
              Top = 24
              AutoSize = False
              Enabled = False
              ItemIndex = -1
              ParentColor = True
              Properties.DropDownListStyle = lsEditFixedList
              Properties.Items.Strings = (
                'Aguardando Separa'#231#227'o'
                'Bloqueado'
                'Liberadas para faturamento'
                'Faturado'
                'Cancelado')
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.ButtonTransparency = ebtHideInactive
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              Height = 23
              Width = 348
            end
          end
          object Gb_Representante: TmgGroupBox
            Left = 1041
            Top = 176
            Caption = 'Representante'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 16
            ExibeCheckBox = True
            Checked = False
            Height = 53
            Width = 380
            object Ed_REP_IN_CODIGO: TMgDBEditConsulta
              Left = 10
              Top = 24
              AutoSize = False
              Enabled = False
              Properties.Buttons = <
                item
                  Default = True
                  Kind = bkEllipsis
                end>
              Properties.ReadOnly = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideInactive
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              CharCase = ecNormal
              LookupFormID = 0
              Opcoes.FiltroDefault = sQueInicie
              Opcoes.ExibirSintetico = True
              PasswordChar = #0
              ReadOnly = False
              TabOnDropDown = True
              TestaFK = True
              UsaLkPrioridade = False
              Height = 21
              Width = 75
            end
            object Ed_REP_ST_NOME: TMgDBEdit
              Left = 89
              Top = 24
              AutoSize = False
              Enabled = False
              Properties.AlwaysShowBlanksAndLiterals = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              Password = False
              Height = 21
              Width = 269
            end
          end
          object Gb_DataCliente: TmgGroupBox
            Left = 387
            Top = 0
            Caption = 'Data do Cliente'
            CheckBox.CheckAction = cbaToggleChildrenEnabledState
            CheckBox.Checked = False
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TextStyle = [fsBold]
            Style.IsFontAssigned = True
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 2
            ExibeCheckBox = True
            Checked = False
            Height = 110
            Width = 120
            object Ed_DataClienteInicial: TMgDBDateEdit
              Left = 10
              Top = 36
              AutoSize = False
              DataBinding.DataField = 'DATA_CLIENTE_INICIAL'
              Enabled = False
              ParentFont = False
              Properties.ButtonGlyph.SourceDPI = 96
              Properties.ButtonGlyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E000A4A0A0FF4060
                60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF406060FFA4A0A0FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFFA4A0A0FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FF8080
                80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF808080FF808080FF4020E0004020E000808080FFC0DC
                C0FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E000C0DCC0FF808080FF4020E0004020E000C0DCC0FF8080
                80FF808080FF4020E000808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                80FF4020E000808080FF808080FFC0DCC0FF4020E0004020E0004020E0004020
                E0004020E0004020E000808080FF4020E0004020E0004020E0004020E0008080
                80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E000}
              Properties.DisplayFormat = 'dd/MM/yyyy'
              Properties.EditFormat = 'dd/MM/yyyy'
              Properties.ImmediatePost = True
              Properties.PostPopupValueOnTab = True
              Properties.SaveTime = False
              Properties.ShowTime = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideUnselected
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              Value = -657435.000000000000000000
              DateValue = '31/12/0099'
              Height = 21
              Width = 95
            end
            object Ed_DataClienteFinal: TMgDBDateEdit
              Left = 10
              Top = 76
              AutoSize = False
              DataBinding.DataField = 'DATA_CLIENTE_FINAL'
              Enabled = False
              ParentFont = False
              Properties.ButtonGlyph.SourceDPI = 96
              Properties.ButtonGlyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E000A4A0A0FF4060
                60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF406060FFA4A0A0FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFFA4A0A0FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF808080FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF4020E0004020E000808080FF8080
                80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF808080FF808080FF4020E0004020E000808080FFC0DC
                C0FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E000C0DCC0FF808080FF4020E0004020E000C0DCC0FF8080
                80FF808080FF4020E000808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                80FF4020E000808080FF808080FFC0DCC0FF4020E0004020E0004020E0004020
                E0004020E0004020E000808080FF4020E0004020E0004020E0004020E0008080
                80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E000}
              Properties.DisplayFormat = 'dd/MM/yyyy'
              Properties.EditFormat = 'dd/MM/yyyy'
              Properties.ImmediatePost = True
              Properties.PostPopupValueOnTab = True
              Properties.SaveTime = False
              Properties.ShowTime = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtHideUnselected
              Style.IsFontAssigned = True
              StyleDisabled.BorderColor = 10526880
              StyleDisabled.BorderStyle = ebsUltraFlat
              StyleDisabled.Color = 15790320
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleDisabled.TextColor = 6710886
              StyleFocused.BorderColor = 6579300
              StyleFocused.BorderStyle = ebsUltraFlat
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.BorderColor = 6579300
              StyleHot.BorderStyle = ebsUltraFlat
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 1
              Value = -657435.000000000000000000
              DateValue = '31/12/0099'
              Height = 21
              Width = 95
            end
            object mgLabel15: TmgLabel
              Left = 10
              Top = 18
              Caption = 'Data Inicial'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object mgLabel18: TmgLabel
              Left = 10
              Top = 58
              Caption = 'Data Final'
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clWindowText
              Style.Font.Height = -11
              Style.Font.Name = 'Tahoma'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = True
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = True
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = True
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = True
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
          end
        end
        object mgPanel1: TmgPanel
          Left = 0
          Top = 246
          Width = 269
          Height = 457
          Align = alLeft
          BevelOuter = bvNone
          ParentColor = True
          TabOrder = 1
          ExplicitHeight = 389
          object Bt_Filtrar: TMgSpeedButton
            Left = 0
            Top = 0
            Width = 269
            Height = 28
            Cursor = crHandPoint
            Glyph.SourceDPI = 96
            Glyph.Data = {
              424D360400000000000036000000280000001000000010000000010020000000
              000000000000C40E0000C40E000000000000000000004020E0004020E0004020
              E0004020E0004020E000A4A0A0FF404040FF404040FF404040FF404040FFA4A0
              A0FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
              E0004020E0004020E000808080FFC0C0C0FFF0FBFFFFF0FBFFFFC0C0C0FF8080
              80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
              E0004020E0004020E000808080FFF0FBFFFFFFFFFFFFFFFFFFFFF0FBFFFF8080
              80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
              E0004020E0004020E000808080FFF0FBFFFFFFFFFFFFFFFFFFFFF0FBFFFF8080
              80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
              E0004020E0004020E000808080FFF0FBFFFFFFFFFFFFFFFFFFFFF0FBFFFF8080
              80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
              E0004020E0004020E000808080FFF0FBFFFFFFFFFFFFFFFFFFFFF0FBFFFF8080
              80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
              E0004020E0004020E000808080FFF0FBFFFFFFFFFFFFFFFFFFFFF0FBFFFF8080
              80FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
              E0004020E0004020E000406060FFF0FBFFFFFFFFFFFFFFFFFFFFF0FBFFFF4060
              60FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
              E0004020E000A4A0A0FFA4A0A0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC0C0
              C0FF808080FF4020E0004020E0004020E0004020E0004020E0004020E0004020
              E0004020E000406060FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
              FFFF806060FF4020E0004020E0004020E0004020E0004020E0004020E0004020
              E000808080FFC0C0C0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
              FFFFC0DCC0FF806060FF4020E0004020E0004020E0004020E0004020E0004020
              E000808080FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
              FFFFFFFFFFFFA4A0A0FFA4A0A0FF4020E0004020E0004020E0004020E0004060
              60FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
              FFFFFFFFFFFFFFFFFFFF406060FF4020E0004020E0004020E000A4A0A0FFA4A0
              A0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
              FFFFFFFFFFFFFFFFFFFFC0C0C0FF808080FF4020E0004020E000406060FFF0FB
              FFFFF0FBFFFFF0FBFFFFF0FBFFFFF0FBFFFFF0FBFFFFF0FBFFFFF0FBFFFFF0FB
              FFFFF0FBFFFFF0FBFFFFF0FBFFFF806060FF4020E000A4A0A0FF806060FF8060
              60FF806060FF806060FF806060FF806060FF806060FF806060FF806060FF8060
              60FF806060FF806060FF806060FF806060FF808080FF}
            Align = alTop
            Caption = '&Filtrar'
            LookAndFeel.NativeStyle = False
            LookAndFeel.SkinName = ''
            ParentShowHint = True
            SpeedButtonOptions.Flat = True
            DropdownArrow = False
            DropdownArrowWidth = 7
            Flat = False
            HighlightWhenDown = False
            ImageIndex = 0
            Opaque = False
            RepeatDelay = 0
            RepeatInterval = 0
            MgImagem = siFilter
          end
        end
      end
      inherited Ts_Geral: TcxTabSheet
        Caption = 'PEDIDO'
        ExplicitTop = 22
        ExplicitWidth = 1358
        ExplicitHeight = 615
        object mgPanel3: TmgPanel
          Left = 0
          Top = 23
          Width = 1526
          Height = 680
          Align = alClient
          BevelOuter = bvNone
          Caption = 'mgPanel3'
          ParentColor = True
          TabOrder = 0
          ExplicitWidth = 1358
          ExplicitHeight = 592
          object mgPanel14: TmgPanel
            Left = 1421
            Top = 0
            Width = 105
            Height = 680
            Align = alRight
            BevelOuter = bvNone
            Caption = 'mgPanel14'
            ParentColor = True
            TabOrder = 0
            Visible = False
            ExplicitLeft = 1251
            ExplicitHeight = 584
            object Pn_Direito: TmgPanel
              Left = 5
              Top = 0
              Width = 100
              Height = 680
              Align = alRight
              BevelOuter = bvNone
              ParentColor = True
              TabOrder = 0
              Visible = False
              ExplicitHeight = 584
              object Bt_ClassCliente: TMgSpeedButton
                Left = 3
                Top = 4
                Width = 95
                Height = 50
                Cursor = crHandPoint
                Glyph.SourceDPI = 96
                Glyph.Data = {
                  424D360400000000000036000000280000001000000010000000010020000000
                  000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E000C0C0C0FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E000C0C0C0FF404040FFC0C0C0FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E000C0DC
                  C0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020
                  E000806060FF404040FF406060FF404040FF404040FFC0C0C0FFF0FBFFFF4060
                  60FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020E0004040
                  40FFC0C0C0FFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF406060FF404040FFA4A0
                  A0FF4020E0004020E0004020E0004020E0004020E0004020E000404040FFC0DC
                  C0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFF406060FFC0C0
                  C0FF4020E0004020E0004020E0004020E0004020E000806060FFC0C0C0FFFFFF
                  FFFFFFFFFFFFFFFFFFFF806060FFF0FBFFFFFFFFFFFFFFFFFFFFC0DCC0FF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000406060FFFFFFFFFFFFFF
                  FFFF000000FF000000FF000000FF000000FF404040FFFFFFFFFFFFFFFFFF4060
                  60FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFF0FBFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFC0DCC0FFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFC0C0C0FF8060
                  60FF4020E0004020E0004020E0004020E0004020E0004020E000406060FFF0FB
                  FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF404040FF4020
                  E0004020E0004020E0004020E0004020E0004020E0004020E000404040FF4060
                  60FFC0DCC0FFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FF404040FF4020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000404040FF404040FF406060FF404040FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E000}
                Layout = blGlyphTop
                Spacing = 0
                Caption = 'Clientes'
                LookAndFeel.NativeStyle = False
                LookAndFeel.SkinName = ''
                ParentShowHint = True
                SpeedButtonOptions.Flat = True
                WordWrap = True
                DropdownArrow = False
                DropdownArrowWidth = 7
                Flat = False
                HighlightWhenDown = False
                ImageIndex = 0
                Opaque = False
                RepeatDelay = 0
                RepeatInterval = 0
                MgImagem = siZoom
              end
              object Bt_ClassItens: TMgSpeedButton
                Left = 3
                Top = 57
                Width = 95
                Height = 50
                Cursor = crHandPoint
                Glyph.SourceDPI = 96
                Glyph.Data = {
                  424D360400000000000036000000280000001000000010000000010020000000
                  000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E000C0C0C0FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E000C0C0C0FF404040FFC0C0C0FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E000C0DC
                  C0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020
                  E000806060FF404040FF406060FF404040FF404040FFC0C0C0FFF0FBFFFF4060
                  60FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020E0004040
                  40FFC0C0C0FFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF406060FF404040FFA4A0
                  A0FF4020E0004020E0004020E0004020E0004020E0004020E000404040FFC0DC
                  C0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFF406060FFC0C0
                  C0FF4020E0004020E0004020E0004020E0004020E000806060FFC0C0C0FFFFFF
                  FFFFFFFFFFFFFFFFFFFF806060FFF0FBFFFFFFFFFFFFFFFFFFFFC0DCC0FF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000406060FFFFFFFFFFFFFF
                  FFFF000000FF000000FF000000FF000000FF404040FFFFFFFFFFFFFFFFFF4060
                  60FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFF0FBFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFC0DCC0FFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFC0C0C0FF8060
                  60FF4020E0004020E0004020E0004020E0004020E0004020E000406060FFF0FB
                  FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF404040FF4020
                  E0004020E0004020E0004020E0004020E0004020E0004020E000404040FF4060
                  60FFC0DCC0FFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FF404040FF4020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000404040FF404040FF406060FF404040FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E000}
                Layout = blGlyphTop
                Caption = ' Itens'
                LookAndFeel.NativeStyle = False
                LookAndFeel.SkinName = ''
                ParentShowHint = True
                SpeedButtonOptions.Flat = True
                TabOrder = 1
                WordWrap = True
                DropdownArrow = False
                DropdownArrowWidth = 7
                Flat = False
                HighlightWhenDown = False
                ImageIndex = 0
                Opaque = False
                RepeatDelay = 0
                RepeatInterval = 0
                MgImagem = siZoom
              end
              object Bt_ClassClientesItens: TMgSpeedButton
                Left = 3
                Top = 110
                Width = 95
                Height = 50
                Cursor = crHandPoint
                Glyph.SourceDPI = 96
                Glyph.Data = {
                  424D360400000000000036000000280000001000000010000000010020000000
                  000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E000C0C0C0FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E000C0C0C0FF404040FFC0C0C0FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E000C0DC
                  C0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020
                  E000806060FF404040FF406060FF404040FF404040FFC0C0C0FFF0FBFFFF4060
                  60FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020E0004040
                  40FFC0C0C0FFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF406060FF404040FFA4A0
                  A0FF4020E0004020E0004020E0004020E0004020E0004020E000404040FFC0DC
                  C0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFF406060FFC0C0
                  C0FF4020E0004020E0004020E0004020E0004020E000806060FFC0C0C0FFFFFF
                  FFFFFFFFFFFFFFFFFFFF806060FFF0FBFFFFFFFFFFFFFFFFFFFFC0DCC0FF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000406060FFFFFFFFFFFFFF
                  FFFF000000FF000000FF000000FF000000FF404040FFFFFFFFFFFFFFFFFF4060
                  60FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFF0FBFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFC0DCC0FFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFC0C0C0FF8060
                  60FF4020E0004020E0004020E0004020E0004020E0004020E000406060FFF0FB
                  FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF404040FF4020
                  E0004020E0004020E0004020E0004020E0004020E0004020E000404040FF4060
                  60FFC0DCC0FFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FF404040FF4020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000404040FF404040FF406060FF404040FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E000}
                Layout = blGlyphTop
                Spacing = 0
                Caption = 'Clientes / Itens'
                LookAndFeel.NativeStyle = False
                LookAndFeel.SkinName = ''
                ParentShowHint = True
                SpeedButtonOptions.Flat = True
                TabOrder = 2
                WordWrap = True
                DropdownArrow = False
                DropdownArrowWidth = 7
                Flat = False
                HighlightWhenDown = False
                ImageIndex = 0
                Opaque = False
                RepeatDelay = 0
                RepeatInterval = 0
                MgImagem = siZoom
              end
              object Bt_SaldosGrupo: TMgSpeedButton
                Left = 3
                Top = 216
                Width = 95
                Height = 50
                Cursor = crHandPoint
                Glyph.SourceDPI = 96
                Glyph.Data = {
                  424D360400000000000036000000280000001000000010000000010020000000
                  000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E000C0C0C0FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E000C0C0C0FF404040FFC0C0C0FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E000C0DC
                  C0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020
                  E000806060FF404040FF406060FF404040FF404040FFC0C0C0FFF0FBFFFF4060
                  60FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020E0004040
                  40FFC0C0C0FFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF406060FF404040FFA4A0
                  A0FF4020E0004020E0004020E0004020E0004020E0004020E000404040FFC0DC
                  C0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFF406060FFC0C0
                  C0FF4020E0004020E0004020E0004020E0004020E000806060FFC0C0C0FFFFFF
                  FFFFFFFFFFFFFFFFFFFF806060FFF0FBFFFFFFFFFFFFFFFFFFFFC0DCC0FF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000406060FFFFFFFFFFFFFF
                  FFFF000000FF000000FF000000FF000000FF404040FFFFFFFFFFFFFFFFFF4060
                  60FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFF0FBFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFC0DCC0FFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFC0C0C0FF8060
                  60FF4020E0004020E0004020E0004020E0004020E0004020E000406060FFF0FB
                  FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF404040FF4020
                  E0004020E0004020E0004020E0004020E0004020E0004020E000404040FF4060
                  60FFC0DCC0FFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FF404040FF4020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000404040FF404040FF406060FF404040FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E000}
                Layout = blGlyphTop
                Spacing = 0
                Caption = 'Saldos do Grupo'
                LookAndFeel.NativeStyle = False
                LookAndFeel.SkinName = ''
                ParentShowHint = True
                SpeedButtonOptions.Flat = True
                TabOrder = 3
                WordWrap = True
                DropdownArrow = False
                DropdownArrowWidth = 7
                Flat = False
                HighlightWhenDown = False
                ImageIndex = 0
                Opaque = False
                RepeatDelay = 0
                RepeatInterval = 0
                MgImagem = siZoom
              end
              object Bt_OcorrenciaFin: TMgSpeedButton
                Left = 3
                Top = 322
                Width = 95
                Height = 50
                Cursor = crHandPoint
                Glyph.SourceDPI = 96
                Glyph.Data = {
                  424D360400000000000036000000280000001000000010000000010020000000
                  000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E000C0C0C0FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E0004020E000C0C0C0FF404040FFC0C0C0FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E0004020E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000C0DCC0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E000C0DC
                  C0FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020
                  E000806060FF404040FF406060FF404040FF404040FFC0C0C0FFF0FBFFFF4060
                  60FFC0C0C0FF4020E0004020E0004020E0004020E0004020E0004020E0004040
                  40FFC0C0C0FFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF406060FF404040FFA4A0
                  A0FF4020E0004020E0004020E0004020E0004020E0004020E000404040FFC0DC
                  C0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFF406060FFC0C0
                  C0FF4020E0004020E0004020E0004020E0004020E000806060FFC0C0C0FFFFFF
                  FFFFFFFFFFFFFFFFFFFF806060FFF0FBFFFFFFFFFFFFFFFFFFFFC0DCC0FF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000406060FFFFFFFFFFFFFF
                  FFFF000000FF000000FF000000FF000000FF404040FFFFFFFFFFFFFFFFFF4060
                  60FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                  FFFFF0FBFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFF4040
                  40FF4020E0004020E0004020E0004020E0004020E000404040FFC0DCC0FFFFFF
                  FFFFFFFFFFFFF0FBFFFF000000FFF0FBFFFFFFFFFFFFFFFFFFFFC0C0C0FF8060
                  60FF4020E0004020E0004020E0004020E0004020E0004020E000406060FFF0FB
                  FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF404040FF4020
                  E0004020E0004020E0004020E0004020E0004020E0004020E000404040FF4060
                  60FFC0DCC0FFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FF404040FF4020E0004020
                  E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                  E000404040FF404040FF406060FF404040FF806060FF4020E0004020E0004020
                  E0004020E0004020E0004020E0004020E0004020E000}
                Layout = blGlyphTop
                Spacing = 0
                Caption = 'Ocorr'#234'ncias Financeiro'
                LookAndFeel.NativeStyle = False
                LookAndFeel.SkinName = ''
                ParentShowHint = True
                SpeedButtonOptions.Flat = True
                TabOrder = 4
                WordWrap = True
                DropdownArrow = False
                DropdownArrowWidth = 7
                Flat = False
                HighlightWhenDown = False
                ImageIndex = 0
                Opaque = False
                RepeatDelay = 0
                RepeatInterval = 0
                MgImagem = siZoom
              end
              object Bt_ExcluirOePedido: TMgSpeedButton
                Left = 3
                Top = 481
                Width = 95
                Height = 50
                Cursor = crHandPoint
                Caption = '&Excluir OEs do Pedido'
                LookAndFeel.NativeStyle = False
                LookAndFeel.SkinName = ''
                PaintStyle = bpsCaption
                ParentShowHint = True
                SpeedButtonOptions.Flat = True
                TabOrder = 6
                WordWrap = True
                DropdownArrow = False
                DropdownArrowWidth = 7
                Flat = False
                HighlightWhenDown = False
                ImageIndex = 0
                Opaque = False
                RepeatDelay = 0
                RepeatInterval = 0
                MgImagem = siApply
              end
              object cBt_HistAltProgEntrega: TMgSpeedButton
                Left = 3
                Top = 375
                Width = 95
                Height = 50
                Cursor = crHandPoint
                Caption = 'Hist'#243'rico Altera'#231#245'es Prog. Entrega'
                LookAndFeel.NativeStyle = False
                LookAndFeel.SkinName = ''
                PaintStyle = bpsCaption
                ParentShowHint = True
                SpeedButtonOptions.Flat = True
                TabOrder = 5
                WordWrap = True
                DropdownArrow = False
                DropdownArrowWidth = 7
                Flat = False
                HighlightWhenDown = False
                ImageIndex = 0
                Opaque = False
                RepeatDelay = 0
                RepeatInterval = 0
                MgImagem = siApply
              end
              object Bt_Comissao: TMgSpeedButton
                Left = 3
                Top = 534
                Width = 95
                Height = 50
                Cursor = crHandPoint
                Caption = 'Comiss'#245'es'
                LookAndFeel.NativeStyle = False
                LookAndFeel.SkinName = ''
                PaintStyle = bpsCaption
                ParentShowHint = True
                SpeedButtonOptions.Flat = True
                TabOrder = 7
                WordWrap = True
                DropdownArrow = False
                DropdownArrowWidth = 7
                Flat = False
                HighlightWhenDown = False
                ImageIndex = 0
                Opaque = False
                RepeatDelay = 0
                RepeatInterval = 0
                MgImagem = siApply
              end
              object Bt_LogCriacaoRomaneio: TMgSpeedButton
                Left = 3
                Top = 587
                Width = 95
                Height = 50
                Cursor = crHandPoint
                Caption = 'Log de Cria'#231#227'o de Romaneio'
                LookAndFeel.NativeStyle = False
                LookAndFeel.SkinName = ''
                PaintStyle = bpsCaption
                ParentShowHint = True
                SpeedButtonOptions.Flat = True
                TabOrder = 8
                WordWrap = True
                DropdownArrow = False
                DropdownArrowWidth = 7
                Flat = False
                HighlightWhenDown = False
                ImageIndex = 0
                Opaque = False
                RepeatDelay = 0
                RepeatInterval = 0
                MgImagem = siApply
              end
            end
          end
          object cPn_GridPedido: TmgPanel
            Left = 0
            Top = 0
            Width = 1421
            Height = 680
            Align = alClient
            BevelOuter = bvNone
            Caption = 'cPn_GridPedido'
            ParentColor = True
            TabOrder = 1
            ExplicitWidth = 1358
            ExplicitHeight = 592
            object mgPanel15: TmgPanel
              Left = 0
              Top = 497
              Width = 1421
              Height = 183
              Align = alBottom
              BevelOuter = bvNone
              Caption = 'mgPanel15'
              ParentColor = True
              TabOrder = 0
              ExplicitTop = 409
              ExplicitWidth = 1358
              object mgPanel12: TmgPanel
                Left = 0
                Top = 7
                Width = 1421
                Height = 176
                Align = alBottom
                BevelOuter = bvNone
                Caption = 'mgPanel12'
                ParentColor = True
                TabOrder = 0
                ExplicitWidth = 1358
                object Pn_NotaFiscal: TmgPanel
                  Left = 953
                  Top = 0
                  Width = 468
                  Height = 176
                  Align = alClient
                  BevelOuter = bvNone
                  ParentColor = True
                  TabOrder = 0
                  ExplicitWidth = 405
                  object MgShape1: TMgShape
                    Left = 0
                    Top = 19
                    Width = 468
                    Height = 157
                    Align = alClient
                    Pen.Color = clSilver
                    ExplicitTop = 18
                    ExplicitWidth = 1184
                    ExplicitHeight = 174
                  end
                  object Lb_NotaFiscal: TmgLabel
                    Left = 0
                    Top = 0
                    Align = alTop
                    Caption = 'Nota Fiscal'
                    Style.LookAndFeel.NativeStyle = True
                    Style.LookAndFeel.SkinName = ''
                    Style.TextStyle = [fsBold]
                    StyleDisabled.LookAndFeel.NativeStyle = True
                    StyleDisabled.LookAndFeel.SkinName = ''
                    StyleFocused.LookAndFeel.NativeStyle = True
                    StyleFocused.LookAndFeel.SkinName = ''
                    StyleHot.LookAndFeel.NativeStyle = True
                    StyleHot.LookAndFeel.SkinName = ''
                    Transparent = True
                    Visible = True
                    ExplicitWidth = 405
                  end
                end
                object Pn_OE_Geradas: TmgPanel
                  Left = 0
                  Top = 0
                  Width = 953
                  Height = 176
                  Align = alLeft
                  BevelOuter = bvNone
                  ParentColor = True
                  TabOrder = 1
                  object MgShape4: TMgShape
                    Left = 0
                    Top = 19
                    Width = 852
                    Height = 157
                    Align = alClient
                    Pen.Color = clSilver
                    ExplicitLeft = 262
                    ExplicitTop = 95
                    ExplicitWidth = 65
                    ExplicitHeight = 65
                  end
                  object Lb_OrdemExpedicao: TmgLabel
                    Left = 0
                    Top = 0
                    Align = alTop
                    Caption = 'Ordem de Expedi'#231#227'o'
                    Style.LookAndFeel.NativeStyle = True
                    Style.LookAndFeel.SkinName = ''
                    Style.TextStyle = [fsBold]
                    StyleDisabled.LookAndFeel.NativeStyle = True
                    StyleDisabled.LookAndFeel.SkinName = ''
                    StyleFocused.LookAndFeel.NativeStyle = True
                    StyleFocused.LookAndFeel.SkinName = ''
                    StyleHot.LookAndFeel.NativeStyle = True
                    StyleHot.LookAndFeel.SkinName = ''
                    Transparent = True
                    Visible = True
                  end
                  object mgPanel8: TmgPanel
                    Left = 852
                    Top = 19
                    Width = 101
                    Height = 157
                    Align = alRight
                    BevelOuter = bvNone
                    ParentColor = True
                    TabOrder = 1
                    object Bt_GerarOE: TMgSpeedButton
                      Left = 3
                      Top = 0
                      Width = 92
                      Height = 38
                      Cursor = crHandPoint
                      Glyph.SourceDPI = 96
                      Glyph.Data = {
                        424D360400000000000036000000280000001000000010000000010020000000
                        000000000000C40E0000C40E000000000000000000004020E0004020E0008080
                        80FF404040FF404040FF404040FF404040FF404040FF404040FF404040FF4040
                        40FF404040FF404040FF406060FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFFFFFFFFFFC0DCC0FF406060FFC0DCC0FFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFFC0DCC0FF404040FF808080FF404040FFC0DCC0FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFF406060FFC0C0C0FFFFFFFFFFA4A0A0FF404040FFC0DCC0FFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFA4A0A0FF404040FFC0DC
                        C0FFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFA4A0A0FF4040
                        40FFC0DCC0FFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFA4A0
                        A0FF406060FFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFF0FBFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004040
                        40FFA4A0A0FFA4A0A0FFA4A0A0FFC0C0C0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0008080
                        80FF404040FFA4A0A0FF806060FFA4A0A0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004020
                        E000808080FF806060FFA4A0A0FFA4A0A0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004020
                        E0004020E000808080FF404040FFA4A0A0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004020
                        E0004020E0004020E000808080FF404040FF404040FF404040FF404040FF4040
                        40FF404040FF404040FF808080FF4020E0004020E000}
                      Caption = '&Gerar OE'
                      LookAndFeel.NativeStyle = False
                      LookAndFeel.SkinName = ''
                      ParentShowHint = True
                      SpeedButtonOptions.Flat = True
                      DropdownArrow = False
                      DropdownArrowWidth = 7
                      Flat = False
                      HighlightWhenDown = False
                      ImageIndex = 0
                      Opaque = False
                      RepeatDelay = 0
                      RepeatInterval = 0
                      MgImagem = siSave
                    end
                    object Bt_ExcluirOE: TMgSpeedButton
                      Left = 3
                      Top = 39
                      Width = 92
                      Height = 38
                      Cursor = crHandPoint
                      Glyph.SourceDPI = 96
                      Glyph.Data = {
                        424D360400000000000036000000280000001000000010000000010020000000
                        000000000000C40E0000C40E000000000000000000004020E0004020E0004020
                        E000C0C0C0FF404040FF404040FF404040FF404040FF404040FF404040FF4040
                        40FF404040FF404040FFC0C0C0FF4020E0004020E0004020E0004020E0004020
                        E000A4A0A0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFA4A0A0FF808080FF4020E0004020E0004020E0004020E0004020
                        E000A4A0A0FFA4A0A0FFC0C0C0FFC0C0C0FFC0C0C0FFC0C0C0FFC0C0C0FFC0C0
                        C0FFC0C0C0FFA4A0A0FF808080FF4020E0004020E0004020E0004020E0004020
                        E000808080FFC0C0C0FFA4A0A0FFA4A0A0FFA4A0A0FFA4A0A0FFA4A0A0FFA4A0
                        A0FFA4A0A0FFC0C0C0FF806060FF4020E0004020E0004020E0004020E0004020
                        E000806060FFC0C0C0FFA4A0A0FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFF
                        FFFFA4A0A0FFC0C0C0FF406060FF4020E0004020E0004020E0004020E0004020
                        E000806060FFC0C0C0FFA4A0A0FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFF
                        FFFFA4A0A0FFC0C0C0FF404040FF4020E0004020E0004020E0004020E0004020
                        E000404040FFF0FBFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFF
                        FFFFA4A0A0FFFFFFFFFF404040FF4020E0004020E0004020E0004020E0004020
                        E000404040FFF0FBFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFF
                        FFFFA4A0A0FFFFFFFFFF404040FFF0FBFFFF4020E0004020E0004020E0004020
                        E000404040FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFF
                        FFFFA4A0A0FFFFFFFFFF404040FFF0FBFFFF4020E0004020E0004020E000F0FB
                        FFFF404040FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFF
                        FFFFA4A0A0FFFFFFFFFF806060FFC0DCC0FF4020E0004020E0004020E000F0FB
                        FFFF404040FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFF
                        FFFFA4A0A0FFFFFFFFFF806060FFC0C0C0FF4020E0004020E0004020E000C0C0
                        C0FF806060FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFFFFFFA4A0A0FFFFFF
                        FFFFA4A0A0FFFFFFFFFF808080FFC0C0C0FF4020E0004020E0004020E000C0C0
                        C0FF808080FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFF808080FFA4A0A0FF4020E0004020E0004020E0008080
                        80FF406060FFA4A0A0FFA4A0A0FFA4A0A0FFA4A0A0FFA4A0A0FFA4A0A0FFA4A0
                        A0FFA4A0A0FFA4A0A0FF806060FF806060FF4020E0004020E0004020E000A4A0
                        A0FFA4A0A0FFA4A0A0FFA4A0A0FF404040FFA4A0A0FFA4A0A0FF404040FFA4A0
                        A0FFA4A0A0FFA4A0A0FFA4A0A0FFA4A0A0FF4020E0004020E0004020E0004020
                        E0004020E0004020E0004020E000A4A0A0FF404040FF404040FF808080FF4020
                        E0004020E0004020E0004020E0004020E0004020E000}
                      Caption = '&Excluir OE'
                      LookAndFeel.NativeStyle = False
                      LookAndFeel.SkinName = ''
                      ParentShowHint = True
                      SpeedButtonOptions.Flat = True
                      TabOrder = 1
                      DropdownArrow = False
                      DropdownArrowWidth = 7
                      Flat = False
                      HighlightWhenDown = False
                      ImageIndex = 0
                      Opaque = False
                      RepeatDelay = 0
                      RepeatInterval = 0
                      MgImagem = siDelete
                    end
                    object Bt_DistribuirReserva: TMgSpeedButton
                      Left = 3
                      Top = 78
                      Width = 92
                      Height = 38
                      Cursor = crHandPoint
                      Glyph.SourceDPI = 96
                      Glyph.Data = {
                        424D360400000000000036000000280000001000000010000000010020000000
                        000000000000C40E0000C40E000000000000000000004020E000404040FF4040
                        40FF404040FF404040FF404040FF404040FFFFFFFFFF406060FF404040FF8080
                        80FFC0C0C0FF4020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF808080FF4040
                        40FF404040FF808080FF4020E0004020E0004020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC0DCC0FF404040FF8060
                        60FFF0FBFFFF406060FF808080FF4020E0004020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FF8060
                        60FFF0FBFFFFF0FBFFFF806060FF808080FF4020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF8080
                        80FF806060FFF0FBFFFFF0FBFFFF806060FF808080FF404040FFFFFFFFFFC0C0
                        C0FF404040FF404040FF404040FF806060FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFF808080FF806060FFF0FBFFFF808080FF806060FF404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFFFFFFFFFF808080FF404040FF806060FF4020E000404040FFFFFFFFFFC0C0
                        C0FF404040FF404040FF404040FF404040FF806060FFFFFFFFFFFFFFFFFFFFFF
                        FFFF404040FF4020E000C0C0C0FF4020E0004020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFF404040FF4020E0004020E0004020E0004020E000404040FFFFFFFFFFC0C0
                        C0FF404040FF404040FF404040FF404040FF404040FF404040FFC0C0C0FFFFFF
                        FFFF404040FF4020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        FFFF404040FF4020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FFA4A0A0FFA4A0A0FFA4A0
                        A0FF404040FF4020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFA4A0A0FF806060FFA4A0A0FF4040
                        40FF808080FF4020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFA4A0A0FFA4A0A0FF808080FF8080
                        80FF4020E0004020E0004020E0004020E0004020E000404040FFFFFFFFFFFFFF
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFA4A0A0FF404040FF808080FF4020
                        E0004020E0004020E0004020E0004020E0004020E000808080FF404040FF4040
                        40FF404040FF404040FF404040FF404040FF404040FF808080FF4020E0004020
                        E0004020E0004020E0004020E0004020E0004020E000}
                      Caption = '&Distribuir Reserva'
                      LookAndFeel.NativeStyle = False
                      LookAndFeel.SkinName = ''
                      ParentShowHint = True
                      SpeedButtonOptions.Flat = True
                      TabOrder = 2
                      WordWrap = True
                      DropdownArrow = False
                      DropdownArrowWidth = 7
                      Flat = False
                      HighlightWhenDown = False
                      ImageIndex = 0
                      Opaque = False
                      RepeatDelay = 0
                      RepeatInterval = 0
                      MgImagem = siEdit
                    end
                    object Bt_Reserva: TMgSpeedButton
                      Left = 3
                      Top = 117
                      Width = 92
                      Height = 38
                      Cursor = crHandPoint
                      Glyph.SourceDPI = 96
                      Glyph.Data = {
                        424D360400000000000036000000280000001000000010000000010020000000
                        000000000000C40E0000C40E00000000000000000000FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00C0C0C0FFA4A0A0FF808080FF808080FFA4A0A0FFC0C0
                        C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00808080FF806060FF808080FF808080FF806060FF8060
                        60FFA4A0A0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00A4A0
                        A0FF806060FFA4A0A0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00A4A0
                        A0FFC0C0C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00A4A0A0FF806060FFC0C0C0FFFFFFFF00FFFFFF00FFFFFF00A4A0A0FF8060
                        60FF806060FFC0C0C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00806060FFA4A0A0FFFFFFFF00FFFFFF00A4A0A0FF806060FF8060
                        60FF806060FF806060FFC0C0C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00808080FF808080FFFFFFFF00FFFFFF00FFFFFF00FFFFFF008080
                        80FF808080FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00C0C0
                        C0FF806060FF806060FF806060FF806060FFA4A0A0FFFFFFFF00FFFFFF00A4A0
                        A0FF806060FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00C0C0C0FF806060FF806060FFA4A0A0FFFFFFFF00FFFFFF00FFFFFF00C0C0
                        C0FF806060FFA4A0A0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00C0C0C0FFA4A0A0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00A4A0A0FF806060FFA4A0A0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00A4A0A0FF806060FF806060FF808080FF808080FF806060FF8080
                        80FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00C0C0C0FFA4A0A0FF808080FF808080FFA4A0A0FFC0C0
                        C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                        FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00}
                      Caption = '&Reserva Autom'#225'tica'
                      LookAndFeel.NativeStyle = False
                      LookAndFeel.SkinName = ''
                      ParentShowHint = True
                      SpeedButtonOptions.Flat = True
                      TabOrder = 3
                      WordWrap = True
                      DropdownArrow = False
                      DropdownArrowWidth = 7
                      Flat = False
                      HighlightWhenDown = False
                      ImageIndex = 0
                      Opaque = False
                      RepeatDelay = 0
                      RepeatInterval = 0
                      MgImagem = siRefresh
                    end
                  end
                end
              end
            end
          end
        end
        object pnPedidosTop: TmgPanel
          Left = 0
          Top = 0
          Width = 1526
          Height = 23
          Align = alTop
          BevelOuter = bvNone
          ParentColor = True
          TabOrder = 1
          object Pn_Top_Bottons: TmgPanel
            Left = 805
            Top = 0
            Width = 721
            Height = 23
            Align = alRight
            BevelOuter = bvNone
            ParentColor = True
            TabOrder = 0
            object Bt_Acoes: TMgSpeedButton
              Left = 590
              Top = 0
              Width = 125
              Height = 23
              Cursor = crHandPoint
              Caption = 'A'#231#245'es'
              LookAndFeel.NativeStyle = False
              LookAndFeel.SkinName = ''
              ParentShowHint = True
              SpeedButtonOptions.Flat = True
              DropdownArrow = False
              DropdownArrowWidth = 7
              Flat = False
              HighlightWhenDown = False
              ImageIndex = 0
              Opaque = False
              RepeatDelay = 0
              RepeatInterval = 0
            end
            object Bt_AlteraEmbalagem: TMgSpeedButton
              Left = 330
              Top = 0
              Width = 125
              Height = 23
              Cursor = crHandPoint
              Caption = '&Alterar Embalagem'
              LookAndFeel.NativeStyle = False
              LookAndFeel.SkinName = ''
              PaintStyle = bpsCaption
              ParentShowHint = True
              SpeedButtonOptions.Flat = True
              TabOrder = 1
              WordWrap = True
              DropdownArrow = False
              DropdownArrowWidth = 7
              Flat = False
              HighlightWhenDown = False
              ImageIndex = 0
              Opaque = False
              RepeatDelay = 0
              RepeatInterval = 0
              MgImagem = siApply
            end
            object Bt_Historico: TMgSpeedButton
              Left = 200
              Top = 0
              Width = 125
              Height = 23
              Cursor = crHandPoint
              Glyph.SourceDPI = 96
              Glyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E000000000000000000004020E000C0C0C0FF4020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E000C0C0C0FF404040FFC0C0
                C0FF4020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E000C0C0C0FF4040
                40FFC0DCC0FF4020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E000C0C0
                C0FF404040FFC0DCC0FF4020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E000C0C0C0FF404040FFC0DCC0FF4020E0004020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E0004020E0004020
                E0004020E000C0C0C0FF406060FFF0FBFFFFC0C0C0FF404040FF404040FF4060
                60FF404040FF806060FF4020E0004020E0004020E0004020E0004020E0004020
                E0004020E0004020E000A4A0A0FF404040FF406060FFC0DCC0FFFFFFFFFFFFFF
                FFFFFFFFFFFFC0C0C0FF404040FF4020E0004020E0004020E0004020E0004020
                E0004020E0004020E000C0C0C0FF406060FFF0FBFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFC0DCC0FF404040FF4020E0004020E0004020E0004020
                E0004020E0004020E000404040FFC0DCC0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFA4A0A0FF4020E0004020E0004020E0004020
                E0004020E0004020E000404040FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FF806060FF4020E0004020E0004020
                E0004020E0004020E000406060FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFF0FBFFFF404040FF4020E0004020E0004020
                E0004020E0004020E000404040FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FF808080FF4020E0004020E0004020
                E0004020E0004020E000806060FFC0C0C0FFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFF808080FFA4A0A0FF4020E0004020E0004020
                E0004020E0004020E0004020E000404040FFC0DCC0FFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFA4A0A0FF406060FF4020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E000404040FFA4A0A0FFC0C0C0FFF0FB
                FFFFC0C0C0FF808080FF406060FF404040FF4020E0004020E0004020E0004020
                E0004020E0004020E0004020E0004020E0004020E0004020E000806060FF4040
                40FF808080FFA4A0A0FF4020E0004020E0004020E000}
              Layout = blGlyphTop
              Spacing = 0
              Caption = 'Hist'#243'rico'
              LookAndFeel.NativeStyle = False
              LookAndFeel.SkinName = ''
              PaintStyle = bpsCaption
              ParentShowHint = True
              SpeedButtonOptions.Flat = True
              TabOrder = 2
              DropdownArrow = False
              DropdownArrowWidth = 7
              Flat = False
              HighlightWhenDown = False
              ImageIndex = 0
              Opaque = False
              RepeatDelay = 0
              RepeatInterval = 0
              MgImagem = siFind
            end
            object Bt_Saldos: TMgSpeedButton
              Left = 70
              Top = 0
              Width = 125
              Height = 23
              Cursor = crHandPoint
              Layout = blGlyphTop
              Spacing = 0
              Caption = 'Saldos'
              LookAndFeel.NativeStyle = False
              LookAndFeel.SkinName = ''
              PaintStyle = bpsCaption
              ParentShowHint = True
              SpeedButtonOptions.Flat = True
              TabOrder = 3
              DropdownArrow = False
              DropdownArrowWidth = 7
              Flat = False
              HighlightWhenDown = False
              ImageIndex = 0
              Opaque = False
              RepeatDelay = 0
              RepeatInterval = 0
            end
            object Bt_Simular: TMgSpeedButton
              Left = 460
              Top = 0
              Width = 125
              Height = 25
              Cursor = crHandPoint
              Glyph.SourceDPI = 96
              Glyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E000000000000000000004020E000000000FF0000
                00FF000000FF000000FF000000FF000000FF000000FF000000FF000000FF0000
                00FF000000FF000000FF000000FF000000FF4020E000000000FFC0C0C0FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FF000000FF000000FFFFFFFFFFF0FB
                FFFFC0C0C0FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000FF000000FFFFFFFFFFA4A0
                A0FF000000FFC0C0C0FFFFFFFFFF000000FF000000FF000000FF000000FF0000
                00FF000000FF000000FF000000FFFFFFFFFF000000FF000000FFFFFFFFFFF0FB
                FFFFC0C0C0FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000FF000000FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000FF000000FFFFFFFFFFF0FB
                FFFFC0C0C0FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000FF000000FFFFFFFFFFA4A0
                A0FF000000FFC0C0C0FFFFFFFFFF000000FF000000FF000000FF000000FF0000
                00FF000000FF000000FF000000FFFFFFFFFF000000FF000000FFFFFFFFFFF0FB
                FFFFC0C0C0FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000FF000000FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000FF000000FFFFFFFFFFF0FB
                FFFFC0C0C0FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000FF000000FFFFFFFFFFA4A0
                A0FF000000FFC0C0C0FFFFFFFFFF000000FF000000FF000000FF000000FF0000
                00FF000000FF000000FF000000FFFFFFFFFF000000FF000000FFFFFFFFFFF0FB
                FFFFC0C0C0FFF0FBFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000FF000000FFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000FF000000FFC0C0C0FFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                FFFFFFFFFFFFFFFFFFFFFFFFFFFFC0C0C0FF000000FF4020E000000000FF0000
                00FF000000FF000000FF000000FF000000FF000000FF000000FF000000FF0000
                00FF000000FF000000FF000000FF000000FF4020E000}
              Caption = 'Simular'
              LookAndFeel.NativeStyle = False
              LookAndFeel.SkinName = ''
              ParentShowHint = True
              SpeedButtonOptions.Flat = True
              TabOrder = 4
              DropdownArrow = False
              DropdownArrowWidth = 7
              Flat = False
              HighlightWhenDown = False
              ImageIndex = 0
              Opaque = False
              RepeatDelay = 0
              RepeatInterval = 0
              MgImagem = siOthers
            end
          end
        end
      end
    end
  end
  inherited Pn_ToolBar: TmgPanel
    Top = 770
    Width = 1536
    ExplicitTop = 674
    ExplicitWidth = 1366
    inherited Pn_Aux_Left: TmgPanel
      Width = 1536
      ExplicitWidth = 1366
      inherited Pn_BaseBotoesAux: TmgPanel
        Left = 1238
        ExplicitLeft = 1068
        inherited Bo_Cancela: TMgBitBtn
          Left = 201
          LookAndFeel.SkinName = ''
          ExplicitLeft = 201
        end
        inherited Bo_OK: TMgBitBtn
          LookAndFeel.SkinName = ''
        end
        inherited Pn_Base_Fechar: TmgPanel
          Left = 99
          ExplicitLeft = 99
          inherited Bo_Fechar: TMgBitBtn
            LookAndFeel.SkinName = ''
          end
        end
      end
      inherited pn_aux_right2: TmgPanel
        Left = 1534
        ExplicitLeft = 1364
      end
      inherited Pn_Aux_Left_Base: TmgPanel
        Width = 1236
        ExplicitWidth = 1362
      end
    end
  end
  inherited StatusBar1: TStatusBar
    Top = 751
    Width = 1536
    ExplicitTop = 751
    ExplicitWidth = 1536
  end
  inherited Pn_SpaceBottom: TmgPanel
    Top = 746
    Width = 1536
    ExplicitTop = 746
    ExplicitWidth = 1536
  end
  inherited Pn_ToolBarEdicao: TmgPanel
    Width = 1536
    Height = 1
    Visible = True
    ExplicitWidth = 1366
    ExplicitHeight = 1
  end
  inherited Pn_BasePesquisa: TmgPanel
    Left = 1214
    Top = -23
    ExplicitLeft = 1214
    ExplicitTop = -23
    inherited Ed_Pesq_Campo: TMgEdit
      Style.LookAndFeel.SkinName = ''
      StyleDisabled.LookAndFeel.SkinName = ''
      StyleFocused.LookAndFeel.SkinName = ''
      StyleHot.LookAndFeel.SkinName = ''
    end
    inherited Pn_BaseBotoesPesquisa: TmgPanel
      inherited Bt_FechaPesquisa: TMgSpeedButton
        LookAndFeel.SkinName = ''
      end
      inherited Bt_Pesq_Anterior: TMgSpeedButton
        LookAndFeel.SkinName = ''
      end
      inherited Bt_Pesq_Proximo: TMgSpeedButton
        LookAndFeel.SkinName = ''
      end
    end
  end
  inherited CL_CampoEncontrado_: TMgClientDataSet
    Active = False
  end
  inherited CL_HerancaDoCampoEncontrado_: TMgClientDataSet
    Active = False
    IndexDefs = <
      item
        Name = 'DEFAULT_ORDER'
      end
      item
        Name = 'CHANGEINDEX'
      end>
  end
  object Ds_Parametros: TMgDataSource [12]
    Left = 217
    Top = 1
  end
  object Cl_Parametros: TMgClientDataSet [13]
    Aggregates = <>
    Params = <>
    RemoteServer = DM_Customizador.Rs_Customizador
    TableName = 'DUAL'
    FormID = 0
    Left = 252
    Top = 3
  end
  object Cl_Dados: TMgClientDataSet [14]
    Aggregates = <>
    Params = <>
    RemoteServer = DM_Customizador.Rs_Customizador
    TableName = 'DUAL'
    FormID = 0
    Left = 183
    Top = 1
  end
  object Ds_Dados: TMgDataSource [15]
    DataSet = Cl_Dados
    Left = 149
  end
  object mgMainMenu1: TmgMainMenu [16]
    Left = 1136
    Top = 32744
  end
end