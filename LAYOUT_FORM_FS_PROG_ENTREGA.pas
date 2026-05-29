inherited FORM_FS_PROG_ENTREGA: TFormScriptMegaManutencao
  Left = 54
  Top = 37
  BorderIcons = [biSystemMenu, biMaximize]
  Caption = ''
  ClientHeight = 561
  ClientWidth = 1184
  Constraints.MinHeight = 600
  Constraints.MinWidth = 1200
  Position = poDesigned
  ExplicitLeft = 54
  ExplicitTop = 37
  ExplicitWidth = 1200
  ExplicitHeight = 600
  PixelsPerInch = 96
  TextHeight = 15
  inherited shpLinhaBottom: TMgShape
    Top = 505
    Width = 1184
    ExplicitTop = 427
    ExplicitWidth = 745
  end
  inherited MinMax: TmgMinMax
    MinTrackSize.X = 1200
    MinTrackSize.Y = 600
  end
  inherited Pn_Base: TmgPanel
    Top = 29
    Width = 1184
    Height = 473
    ExplicitWidth = 1184
    ExplicitHeight = 473
    inherited PageControl1: TmgPageControl
      Width = 1178
      Height = 467
      ExplicitWidth = 1178
      ExplicitHeight = 467
      ClientRectBottom = 465
      ClientRectRight = 1176
      inherited Ts_Geral: TcxTabSheet
        Caption = 'Programa'#231#227'o de Entrega'
        ExplicitWidth = 1176
        ExplicitHeight = 439
        object Pn_EdicaoProg: TmgPanel
          Left = 0
          Top = 0
          Width = 1174
          Height = 435
          Align = alClient
          BevelOuter = bvNone
          ParentBackground = False
          ParentColor = True
          TabOrder = 0
          ExplicitWidth = 1176
          ExplicitHeight = 439
          object Gr_CondicoesEntrega: TmgGroupBox
            Left = 3
            Top = 242
            TabStop = False
            CheckBox.Visible = False
            Style.Edges = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 3
            Checked = True
            Height = 128
            Width = 861
            object Lb_ITP_DT_DATAENTREGA: TmgLabel
              Left = 147
              Top = 47
              Caption = 'Data de entrega'
              FocusControl = Ed_IPE_DT_DATAENTREGA
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Lb_ITP_CH_TIPODATAENTREGA: TmgLabel
              Left = 286
              Top = 47
              Caption = 'Per'#237'odo de entrega'
              FocusControl = ED_IPE_CH_TIPOENTREGA
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Lb_IPE_CH_TIPODATA: TmgLabel
              Left = 426
              Top = 47
              Caption = 'Tipo da data de entrega'
              FocusControl = Ed_IPE_CH_TIPODATA
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Lb_IPE_DT_DATAEXPEDICAO: TmgLabel
              Left = 7
              Top = 45
              Caption = 'Data de expedi'#231#227'o'
              FocusControl = Ed_IPE_DT_DATAEXPEDICAO
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Ed_IPE_DT_DATAENTREGA: TMgDBDateEdit
              Left = 147
              Top = 66
              Hint = #9'Data que o produto precisa ser faturado/entregue no cliente.'
              AutoSize = False
              DataBinding.DataField = 'IPE_DT_DATAENTREGA'
              Properties.ButtonGlyph.SourceDPI = 96
              Properties.ButtonGlyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E00000000000000000000FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00A4A0A0FF4060
                60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF406060FFA4A0A0FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00F0FBFFFFA4A0A0FF808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FF808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FF8080
                80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF808080FF808080FFFFFFFF00FFFFFF00808080FFC0DC
                C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00C0DCC0FF808080FFFFFFFF00FFFFFF00C0DCC0FF8080
                80FF808080FFFFFFFF00808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                80FFFFFFFF00808080FF808080FFC0DCC0FFFFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00FFFFFF00FFFFFF008080
                80FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00}
              Properties.DisplayFormat = 'dd/MM/yyyy'
              Properties.EditFormat = 'dd/MM/yyyy'
              Properties.ImmediatePost = True
              Properties.PostPopupValueOnTab = True
              Properties.SaveTime = False
              Properties.ShowTime = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
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
              TabOrder = 2
              Value = -657435.000000000000000000
              DateValue = '31/12/0099'
              Height = 21
              Width = 130
            end
            object ED_IPE_CH_TIPOENTREGA: TMgDBComboBox
              Left = 286
              Top = 66
              AutoSize = False
              DataBinding.DataField = 'IPE_CH_TIPOENTREGA'
              Properties.DropDownListStyle = lsEditFixedList
              Properties.ImmediateUpdateText = True
              Properties.Items.Strings = (
                'Apos a Data'
                'At'#233' a Data'
                'Somente na Data')
              Properties.Sorted = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtNone
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
              MapList = True
              ItemHeight = 0
              Items.Strings = (
                'Apos a Data'#9'P'
                'At'#233' a Data'#9'A'
                'Somente na Data'#9'S')
              ItemIndex = -1
              Height = 21
              Width = 130
            end
            object Ed_IPE_CH_ENTREGAPARCIAL: TMgDBCheckBox
              Left = 6
              Top = 25
              Caption = 'Permite entrega parcial'
              DataBinding.DataField = 'IPE_CH_ENTREGAPARCIAL'
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
              DataField = 'IPE_CH_ENTREGAPARCIAL'
              Alignment = taRightJustify
              ValueChecked = 'S'
              ValueUnchecked = 'N'
              BidiMode = bdLeftToRight
              ParentBidiMode = False
            end
            object Ed_IPE_CH_TIPODATA: TMgDBComboBox
              Left = 426
              Top = 66
              Hint = 
                'Tipo da data de entrega~Este tipo define qual o campo (data Orig' +
                'inal ou Planejada) ir'#225' receber o valor informado na data de entr' +
                'ega.'
              AutoSize = False
              DataBinding.DataField = 'IPE_CH_TIPODATA'
              Properties.DropDownListStyle = lsEditFixedList
              Properties.ImmediateUpdateText = True
              Properties.Items.Strings = (
                'Original'
                'Planejado')
              Properties.Sorted = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
              Style.ButtonTransparency = ebtNone
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
              TabOrder = 4
              MapList = True
              ItemHeight = 0
              Items.Strings = (
                'Original'#9'O'
                'Planejado'#9'P')
              ItemIndex = -1
              Height = 21
              Width = 130
            end
            object Pn_DataOri: TmgPanel
              Left = 565
              Top = 50
              Width = 136
              Height = 38
              Hint = 
                'Data original e planejada~As datas Original e Planejada podem se' +
                'rvir de controle para hist'#243'rico da programa'#231#227'o, registrando a da' +
                'ta de entrega no campo correspondente, conforme o tipo seleciona' +
                'do.'#13#10#13#10'Estas datas n'#227'o s'#227'o utilizadas nos processos de expedi'#231#227'o' +
                ' ou faturamento.'
              BevelOuter = bvNone
              Enabled = False
              ParentBackground = False
              ParentColor = True
              TabOrder = 5
              object Lb_IPE_DT_DATAORIGINAL: TmgLabel
                Left = 0
                Top = -3
                Caption = 'Data original'
                Enabled = False
                FocusControl = Ed_IPE_DT_DATAORIGINAL
                Style.LookAndFeel.NativeStyle = False
                Style.LookAndFeel.SkinName = ''
                StyleDisabled.LookAndFeel.NativeStyle = False
                StyleDisabled.LookAndFeel.SkinName = ''
                StyleFocused.LookAndFeel.NativeStyle = False
                StyleFocused.LookAndFeel.SkinName = ''
                StyleHot.LookAndFeel.NativeStyle = False
                StyleHot.LookAndFeel.SkinName = ''
                Transparent = True
                Visible = True
              end
              object Ed_IPE_DT_DATAORIGINAL: TMgDBDateEdit
                Left = 2
                Top = 16
                AutoSize = False
                DataBinding.DataField = 'IPE_DT_DATAORIGINAL'
                Enabled = False
                ParentFont = False
                Properties.ButtonGlyph.SourceDPI = 96
                Properties.ButtonGlyph.Data = {
                  424D360400000000000036000000280000001000000010000000010020000000
                  000000000000C40E0000C40E00000000000000000000FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00A4A0A0FF4060
                  60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                  80FF808080FF808080FF406060FFA4A0A0FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00F0FBFFFFA4A0A0FF808080FFFFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FF808080FFFFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FF8080
                  80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                  80FF808080FF808080FF808080FF808080FFFFFFFF00FFFFFF00808080FFC0DC
                  C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00C0DCC0FF808080FFFFFFFF00FFFFFF00C0DCC0FF8080
                  80FF808080FFFFFFFF00808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                  80FFFFFFFF00808080FF808080FFC0DCC0FFFFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00FFFFFF00FFFFFF008080
                  80FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00}
                Properties.DisplayFormat = 'dd/MM/yyyy'
                Properties.EditFormat = 'dd/MM/yyyy'
                Properties.ImmediatePost = True
                Properties.PostPopupValueOnTab = True
                Properties.SaveTime = False
                Properties.ShowTime = False
                Style.BorderColor = 6579300
                Style.BorderStyle = ebsUltraFlat
                Style.Color = cl3DLight
                Style.Font.Charset = DEFAULT_CHARSET
                Style.Font.Color = clGrayText
                Style.Font.Height = -13
                Style.Font.Name = 'Calibri'
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
                Width = 130
              end
            end
            object Ed_IPE_DT_DATAEXPEDICAO: TMgDBDateEdit
              Left = 7
              Top = 64
              Hint = 
                'Data que a f'#225'brica (MRP) tem como Meta para disponibilizar o pro' +
                'duto para expedi'#231#227'o.'
              AutoSize = False
              DataBinding.DataField = 'IPE_DT_DATAEXPEDICAO'
              Properties.ButtonGlyph.SourceDPI = 96
              Properties.ButtonGlyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E00000000000000000000FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00A4A0A0FF4060
                60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF406060FFA4A0A0FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00F0FBFFFFA4A0A0FF808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FF808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FF8080
                80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF808080FF808080FFFFFFFF00FFFFFF00808080FFC0DC
                C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00C0DCC0FF808080FFFFFFFF00FFFFFF00C0DCC0FF8080
                80FF808080FFFFFFFF00808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                80FFFFFFFF00808080FF808080FFC0DCC0FFFFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00FFFFFF00FFFFFF008080
                80FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00}
              Properties.DisplayFormat = 'dd/MM/yyyy'
              Properties.EditFormat = 'dd/MM/yyyy'
              Properties.ImmediatePost = True
              Properties.PostPopupValueOnTab = True
              Properties.SaveTime = False
              Properties.ShowTime = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
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
              Width = 130
            end
            object mgLabel5: TmgLabel
              Left = 6
              Top = 0
              Caption = 'CONDI'#199#213'ES DE ENTREGA'
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clBlack
              Style.Font.Height = -13
              Style.Font.Name = 'Calibri'
              Style.Font.Style = [fsBold]
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
              LabelTitle = True
            end
            object Pn_DataPlan: TmgPanel
              Left = 707
              Top = 50
              Width = 149
              Height = 38
              Hint = 
                'Data original e planejada~As datas Original e Planejada podem se' +
                'rvir de controle para hist'#243'rico da programa'#231#227'o, registrando a da' +
                'ta de entrega no campo correspondente, conforme o tipo seleciona' +
                'do.'#13#10#13#10'Estas datas n'#227'o s'#227'o utilizadas nos processos de expedi'#231#227'o' +
                ' ou faturamento.'
              BevelOuter = bvNone
              Enabled = False
              ParentBackground = False
              ParentColor = True
              TabOrder = 6
              object Lb_IPE_DT_DATAPLANEJADA: TmgLabel
                Left = 0
                Top = -3
                Caption = 'Data planejada'
                Enabled = False
                FocusControl = Ed_IPE_DT_DATAPLANEJADA
                Style.LookAndFeel.NativeStyle = False
                Style.LookAndFeel.SkinName = ''
                StyleDisabled.LookAndFeel.NativeStyle = False
                StyleDisabled.LookAndFeel.SkinName = ''
                StyleFocused.LookAndFeel.NativeStyle = False
                StyleFocused.LookAndFeel.SkinName = ''
                StyleHot.LookAndFeel.NativeStyle = False
                StyleHot.LookAndFeel.SkinName = ''
                Transparent = True
                Visible = True
              end
              object Ed_IPE_DT_DATAPLANEJADA: TMgDBDateEdit
                Left = 0
                Top = 17
                AutoSize = False
                DataBinding.DataField = 'IPE_DT_DATAPLANEJADA'
                Enabled = False
                ParentFont = False
                Properties.ButtonGlyph.SourceDPI = 96
                Properties.ButtonGlyph.Data = {
                  424D360400000000000036000000280000001000000010000000010020000000
                  000000000000C40E0000C40E00000000000000000000FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00A4A0A0FF4060
                  60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                  80FF808080FF808080FF406060FFA4A0A0FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00F0FBFFFFA4A0A0FF808080FFFFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FF808080FFFFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FF8080
                  80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                  80FF808080FF808080FF808080FF808080FFFFFFFF00FFFFFF00808080FFC0DC
                  C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00C0DCC0FF808080FFFFFFFF00FFFFFF00C0DCC0FF8080
                  80FF808080FFFFFFFF00808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                  80FFFFFFFF00808080FF808080FFC0DCC0FFFFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00FFFFFF00FFFFFF008080
                  80FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                  FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00}
                Properties.DisplayFormat = 'dd/MM/yyyy'
                Properties.EditFormat = 'dd/MM/yyyy'
                Properties.ImmediatePost = True
                Properties.PostPopupValueOnTab = True
                Properties.SaveTime = False
                Properties.ShowTime = False
                Style.BorderColor = 6579300
                Style.BorderStyle = ebsUltraFlat
                Style.Color = cl3DLight
                Style.Font.Charset = DEFAULT_CHARSET
                Style.Font.Color = clGrayText
                Style.Font.Height = -13
                Style.Font.Name = 'Calibri'
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
                Width = 139
              end
            end
          end
          object Gb_Ordem: TmgGroupBox
            Left = 859
            Top = 23
            TabStop = False
            CheckBox.Visible = False
            Style.Edges = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 1
            Checked = True
            Height = 71
            Width = 290
            object Lb_IPE_ST_NUMEROORDEM: TmgLabel
              Left = 7
              Top = 27
              Caption = 'N'#250'mero da ordem'
              FocusControl = Ed_IPE_ST_NUMEROORDEM
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Lb_IPE_DT_DATAEMISSAO: TmgLabel
              Left = 152
              Top = 27
              Caption = 'Data de emiss'#227'o'
              FocusControl = Ed_IPE_DT_DATAEMISSAO
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Ed_IPE_ST_NUMEROORDEM: TMgDBEdit
              Left = 12
              Top = 45
              Hint = 'N'#250'mero da Ordem de Entrega.'
              AutoSize = False
              DataBinding.DataField = 'IPE_ST_NUMEROORDEM'
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
              Width = 130
            end
            object Ed_IPE_DT_DATAEMISSAO: TMgDBDateEdit
              Left = 152
              Top = 45
              Hint = 'Data da Emiss'#227'o da Ordem de Entrega.'
              AutoSize = False
              DataBinding.DataField = 'IPE_DT_DATAEMISSAO'
              Properties.ButtonGlyph.SourceDPI = 96
              Properties.ButtonGlyph.Data = {
                424D360400000000000036000000280000001000000010000000010020000000
                000000000000C40E0000C40E00000000000000000000FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00A4A0A0FF4060
                60FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF406060FFA4A0A0FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00F0FBFFFFA4A0A0FF808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00808080FF808080FFFFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FFFFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00808080FF8080
                80FF808080FF808080FF808080FF808080FF808080FF808080FF808080FF8080
                80FF808080FF808080FF808080FF808080FFFFFFFF00FFFFFF00808080FFC0DC
                C0FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00C0DCC0FF808080FFFFFFFF00FFFFFF00C0DCC0FF8080
                80FF808080FFFFFFFF00808080FFC0C0C0FF808080FF808080FFC0C0C0FF8080
                80FFFFFFFF00808080FF808080FFC0DCC0FFFFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00808080FFFFFFFF00FFFFFF00FFFFFF00FFFFFF008080
                80FFFFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
                FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00}
              Properties.DisplayFormat = 'dd/MM/yyyy'
              Properties.EditFormat = 'dd/MM/yyyy'
              Properties.ImmediatePost = True
              Properties.PostPopupValueOnTab = True
              Properties.SaveTime = False
              Properties.ShowTime = False
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
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
              Width = 130
            end
            object mgLabel4: TmgLabel
              Left = 7
              Top = 0
              Caption = 'ORDEM DE CARREGAMENTO'
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clBlack
              Style.Font.Height = -13
              Style.Font.Name = 'Calibri'
              Style.Font.Style = [fsBold]
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
              LabelTitle = True
            end
          end
          object Gb_Situacao: TmgGroupBox
            Left = 859
            Top = 114
            TabStop = False
            CheckBox.Visible = False
            Enabled = False
            Style.Edges = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 2
            Checked = True
            Height = 71
            Width = 290
            object Lb_IPE_RE_QTDEENTREGUE: TmgLabel
              Left = 12
              Top = 27
              Caption = 'Quantidade entregue'
              Enabled = False
              FocusControl = Ed_IPE_RE_QTDEENTREGUE
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Lb_IPE_RE_QTDEFATURADA: TmgLabel
              Left = 152
              Top = 27
              Caption = 'Quantidade faturada'
              Enabled = False
              FocusControl = Ed_IPE_RE_QTDEFATURADA
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
            end
            object Lb_SituacaoEntrega: TmgLabel
              Left = 65
              Top = 0
              Caption = ' LIBERADO '
              Enabled = False
              FocusControl = Ed_IPE_RE_QTDEENTREGUE
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clBlack
              Style.Font.Height = -13
              Style.Font.Name = 'Calibri'
              Style.Font.Style = [fsBold]
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.IsFontAssigned = True
              StyleDisabled.LookAndFeel.NativeStyle = False
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.NativeStyle = False
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.NativeStyle = False
              StyleHot.LookAndFeel.SkinName = ''
              Transparent = True
              Visible = True
              LabelTitle = True
            end
            object Ed_IPE_RE_QTDEENTREGUE: TMgDBNumEdit
              Left = 12
              Top = 45
              AutoSize = False
              DataBinding.DataField = 'IPE_RE_QTDEENTREGUE'
              Enabled = False
              ParentFont = False
              Properties.Alignment.Horz = taRightJustify
              Properties.DecimalPlaces = 2
              Properties.DisplayFormat = ',0.00;-,0.00'
              Properties.UseDisplayFormatWhenEditing = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Color = cl3DLight
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clGrayText
              Style.Font.Height = -13
              Style.Font.Name = 'Calibri'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
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
              AllowNegativeNumber = True
              ButtonVisible = True
              ButtonEnabled = True
              NegativeColor = clRed
              NumericFormat = nfComma
              OutOfRangeErrorMessage = 'Number out of range'
              PositiveColor = clBlack
              ThousandSeparator = '.'
              Height = 21
              Width = 130
            end
            object Ed_IPE_RE_QTDEFATURADA: TMgDBNumEdit
              Left = 152
              Top = 45
              AutoSize = False
              DataBinding.DataField = 'IPE_RE_QTDEFATURADA'
              Enabled = False
              ParentFont = False
              Properties.Alignment.Horz = taRightJustify
              Properties.DecimalPlaces = 2
              Properties.DisplayFormat = ',0.00;-,0.00'
              Properties.UseDisplayFormatWhenEditing = True
              Style.BorderColor = 6579300
              Style.BorderStyle = ebsUltraFlat
              Style.Color = cl3DLight
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clBlack
              Style.Font.Height = -13
              Style.Font.Name = 'Calibri'
              Style.Font.Style = []
              Style.LookAndFeel.NativeStyle = False
              Style.LookAndFeel.SkinName = ''
              Style.TransparentBorder = False
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
              AllowNegativeNumber = True
              ButtonVisible = True
              ButtonEnabled = True
              NegativeColor = clRed
              NumericFormat = nfComma
              OutOfRangeErrorMessage = 'Number out of range'
              PositiveColor = clBlack
              ThousandSeparator = '.'
              Height = 21
              Width = 130
            end
            object Lb_Situacao: TmgLabel
              Left = 0
              Top = 0
              Caption = 'SITUA'#199#195'O - '
              Enabled = False
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clBlack
              Style.Font.Height = -13
              Style.Font.Name = 'Calibri'
              Style.Font.Style = [fsBold]
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
              LabelTitle = True
            end
          end
          object Gr_Motivo: TmgGroupBox
            Left = -1
            Top = 343
            TabStop = False
            CheckBox.Visible = False
            Style.Edges = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            TabOrder = 4
            Checked = True
            Height = 102
            Width = 857
            object ED_IPH_ST_OBSERVACAO: TMgDBMemo
              AlignWithMargins = True
              Left = 6
              Top = 20
              Hint = 
                'Motivo da altera'#231#227'o~Motivo pelo qual a data de entrega foi alter' +
                'ada ap'#243's o documento ter sido gravado.'#13#10#13#10'Esta informa'#231#227'o tamb'#233'm' +
                ' fica dispon'#237'vel na aba "Hist'#243'rico de altera'#231#245'es".'
              Margins.Left = 4
              Margins.Top = 0
              Margins.Right = 5
              Align = alClient
              DataBinding.DataField = 'IPH_ST_OBSERVACAO'
              Properties.ReadOnly = False
              Properties.ScrollBars = ssVertical
              Style.BorderStyle = ebsUltraFlat
              Style.LookAndFeel.SkinName = ''
              StyleDisabled.LookAndFeel.SkinName = ''
              StyleFocused.LookAndFeel.SkinName = ''
              StyleHot.LookAndFeel.SkinName = ''
              TabOrder = 0
              DataField = 'IPH_ST_OBSERVACAO'
              ScrollBars = ssVertical
              Height = 77
              Width = 844
            end
            object Lb_IPH_ST_OBSERVACAO: TmgLabel
              Left = 10
              Top = 0
              Caption = 'Motivo da altera'#231#227'o'
              ParentFont = False
              Style.Font.Charset = DEFAULT_CHARSET
              Style.Font.Color = clBlack
              Style.Font.Height = -13
              Style.Font.Name = 'Calibri'
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
          object Lb_CLI_IN_CODIGO: TmgLabel
            Left = 9
            Top = 4
            Caption = 'Cliente a faturar'
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            StyleFocused.LookAndFeel.NativeStyle = False
            StyleFocused.LookAndFeel.SkinName = ''
            StyleHot.LookAndFeel.NativeStyle = False
            StyleHot.LookAndFeel.SkinName = ''
            Transparent = True
            Visible = True
          end
          object Lb_ENA_IN_CODIGO: TmgLabel
            Left = 9
            Top = 50
            Caption = 'Endere'#231'o de entrega'
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            StyleFocused.LookAndFeel.NativeStyle = False
            StyleFocused.LookAndFeel.SkinName = ''
            StyleHot.LookAndFeel.NativeStyle = False
            StyleHot.LookAndFeel.SkinName = ''
            Transparent = True
            Visible = True
          end
          object Lb_IPE_RE_QUANTIDADE: TmgLabel
            Left = 9
            Top = 141
            Caption = 'Quantidade'
            FocusControl = Ed_IPE_RE_QUANTIDADE
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            StyleFocused.LookAndFeel.NativeStyle = False
            StyleFocused.LookAndFeel.SkinName = ''
            StyleHot.LookAndFeel.NativeStyle = False
            StyleHot.LookAndFeel.SkinName = ''
            Transparent = True
            Visible = True
          end
          object Lb_UNI_ST_UNIDADE: TmgLabel
            Left = 9
            Top = 182
            Caption = 'Unidade'
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            StyleFocused.LookAndFeel.NativeStyle = False
            StyleFocused.LookAndFeel.SkinName = ''
            StyleHot.LookAndFeel.NativeStyle = False
            StyleHot.LookAndFeel.SkinName = ''
            Transparent = True
            Visible = True
          end
          object Lb_IPE_RE_QTDECONVERTIDA: TmgLabel
            Left = 149
            Top = 182
            Caption = 'Qtde. convertida'
            FocusControl = Ed_IPE_RE_QTDECONVERTIDA
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            StyleFocused.LookAndFeel.NativeStyle = False
            StyleFocused.LookAndFeel.SkinName = ''
            StyleHot.LookAndFeel.NativeStyle = False
            StyleHot.LookAndFeel.SkinName = ''
            Transparent = True
            Visible = True
          end
          object Lb_EMB_IN_CODIGO: TmgLabel
            Left = 149
            Top = 141
            Caption = 'Embalagem'
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            StyleFocused.LookAndFeel.NativeStyle = False
            StyleFocused.LookAndFeel.SkinName = ''
            StyleHot.LookAndFeel.NativeStyle = False
            StyleHot.LookAndFeel.SkinName = ''
            Transparent = True
            Visible = True
          end
          object Lb_PRO_ST_ALTERNATIVO: TmgLabel
            Left = 9
            Top = 95
            Caption = 'C'#243'digo'
            FocusControl = Ed_PRO_ST_ALTERNATIVO
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.NativeStyle = False
            StyleDisabled.LookAndFeel.SkinName = ''
            StyleFocused.LookAndFeel.NativeStyle = False
            StyleFocused.LookAndFeel.SkinName = ''
            StyleHot.LookAndFeel.NativeStyle = False
            StyleHot.LookAndFeel.SkinName = ''
            Transparent = True
            Visible = True
          end
          object Ed_IPE_RE_QUANTIDADE: TMgDBNumEdit
            Left = 9
            Top = 159
            AutoSize = False
            DataBinding.DataField = 'IPE_RE_QUANTIDADE'
            Properties.Alignment.Horz = taRightJustify
            Properties.DecimalPlaces = 2
            Properties.DisplayFormat = ',0.00;-,0.00'
            Properties.UseDisplayFormatWhenEditing = True
            Style.BorderColor = 6579300
            Style.BorderStyle = ebsUltraFlat
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TransparentBorder = False
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
            AllowNegativeNumber = True
            ButtonVisible = True
            ButtonEnabled = True
            NegativeColor = clRed
            NumericFormat = nfComma
            OutOfRangeErrorMessage = 'Number out of range'
            PositiveColor = clBlack
            ThousandSeparator = '.'
            Height = 21
            Width = 130
          end
          object Lb_ENA_ST_LOGRADOURO: TMgDBText
            Left = 149
            Top = 68
            Width = 469
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            DataField = 'ENA_ST_LOGRADOURO'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object Lx_CLI_IN_CODIGO: TMgDBText
            Left = 149
            Top = 23
            Width = 700
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            DataField = 'AGN_ST_NOME'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object Lb_ENA_ST_MUNICIPIO: TMgDBText
            Left = 628
            Top = 68
            Width = 221
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            DataField = 'ENA_ST_MUNICIPIO'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object Ed_IPE_RE_QTDECONVERTIDA: TMgDBNumEdit
            Left = 149
            Top = 200
            Hint = 'Quantidade do Produto / Material'
            AutoSize = False
            DataBinding.DataField = 'IPE_RE_QTDECONVERTIDA'
            Enabled = False
            ParentFont = False
            Properties.Alignment.Horz = taRightJustify
            Properties.DecimalPlaces = 2
            Properties.DisplayFormat = ',0.00;-,0.00'
            Properties.UseDisplayFormatWhenEditing = True
            Style.BorderColor = 6579300
            Style.BorderStyle = ebsUltraFlat
            Style.Color = clBtnFace
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlue
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
            Style.Font.Style = []
            Style.LookAndFeel.NativeStyle = False
            Style.LookAndFeel.SkinName = ''
            Style.TransparentBorder = False
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
            TabOrder = 15
            AllowNegativeNumber = True
            ButtonVisible = False
            ButtonEnabled = False
            NegativeColor = clRed
            NumericFormat = nfComma
            OutOfRangeErrorMessage = 'Number out of range'
            PositiveColor = clBlue
            ThousandSeparator = '.'
            Height = 21
            Width = 130
          end
          object Lx_EMB_IN_CODIGO: TMgDBText
            Left = 289
            Top = 159
            Width = 560
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            DataField = 'EMB_ST_DESCRICAO'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object Ed_PRO_ST_UNIDADE: TMgDBText
            Left = 289
            Top = 200
            Width = 560
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            DataField = 'PRO_ST_UNIDADE'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object ED_IPE_IN_SEQUENCIA: TMgDBEdit
            Left = 797
            Top = 141
            AutoSize = False
            DataBinding.DataField = 'IPE_IN_SEQUENCIA'
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
            TabOrder = 18
            Visible = False
            Password = False
            Height = 21
            Width = 52
          end
          object Ed_ITP_ST_DESCRICAO: TMgDBText
            Left = 149
            Top = 114
            Width = 700
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            DataField = 'ITP_ST_DESCRICAO'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object Ed_PRO_ST_ALTERNATIVO: TMgDBText
            Left = 9
            Top = 114
            Width = 130
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            DataField = 'PRO_ST_ALTERNATIVO'
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object Ed_Cli_IN_CODIGO: TMgDBText
            Left = 9
            Top = 23
            Width = 130
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object Ed_ENA_IN_CODIGO: TMgDBText
            Left = 9
            Top = 68
            Width = 130
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object Ed_EMB_IN_CODIGO: TMgDBText
            Left = 150
            Top = 159
            Width = 130
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
          object Ed_UNI_ST_UNIDADE: TMgDBText
            Left = 9
            Top = 200
            Width = 130
            Height = 21
            BorderStyle = sbsSingle
            Color = 15790320
            Font.Charset = DEFAULT_CHARSET
            Font.Color = 6710886
            Font.Height = -13
            Font.Name = 'Calibri'
            Font.Style = []
            ParentColor = False
            ParentFont = False
          end
        end
      end
      object TS_Historico: TcxTabSheet
        Caption = 'Hist'#243'rico de Altera'#231#245'es'
        ImageIndex = 1
        ExplicitLeft = 0
        ExplicitTop = 26
        ExplicitWidth = 1176
        ExplicitHeight = 439
        object Gd_ProgEntregaHist: TMgDBGrid
          AlignWithMargins = True
          Left = 6
          Top = 6
          Width = 1162
          Height = 313
          Margins.Left = 6
          Margins.Top = 6
          Margins.Right = 6
          Margins.Bottom = 6
          Selected.Strings = (
            'IPH_DT_DATAENTREGANOVA'#9'18'#9'Nova Data de Entrega'
            'IPH_DT_DATAENTREGAANT'#9'18'#9'Data de Entrega Anterior'
            'IPH_DT_ALTERACAO'#9'18'#9'Data Altera'#231#227'o'
            'USU_IN_CODIGO'#9'10'#9'Usu'#225'rio'
            'GRU_ST_NOME'#9'25'#9'Nome Usu'#225'rio'
            'IPH_CH_TIPODATA'#9'1'#9'Tipo Data Entrega')
          MemoAttributes = [mSizeable, mWordWrap, mDisableDialog]
          IniAttributes.Delimiter = ';;'
          TitleColor = clMenuBar
          FixedCols = 0
          ShowHorzScrollBar = True
          EditControlOptions = [ecoCheckboxSingleClick, ecoSearchOwnerForm]
          Align = alClient
          BorderStyle = bsNone
          Ctl3D = False
          KeyOptions = []
          MultiSelectOptions = [msoShiftSelect]
          Options = [dgTitles, dgColumnResize, dgColLines, dgRowLines, dgTabs, dgRowSelect, dgCancelOnExit, dgWordWrap]
          ParentCtl3D = False
          ParentFont = True
          TabOrder = 0
          TitleAlignment = taLeftJustify
          TitleFont.Charset = DEFAULT_CHARSET
          TitleFont.Color = clBlack
          TitleFont.Height = -13
          TitleFont.Name = 'Calibri'
          TitleFont.Style = []
          TitleLines = 1
          TitleButtons = False
          IndicatorColor = icBlack
          mgOrderColor = 10526880
          mgOrderFont.Charset = DEFAULT_CHARSET
          mgOrderFont.Color = clWhite
          mgOrderFont.Height = -13
          mgOrderFont.Name = 'Calibri'
          mgOrderFont.Style = []
          OrderByEnabled = True
          ExplicitHeight = 341
        end
        object mgGroupBox1: TmgGroupBox
          Left = 0
          Top = 325
          TabStop = False
          Align = alBottom
          CheckBox.Visible = False
          PanelStyle.Active = True
          Style.Edges = []
          Style.LookAndFeel.NativeStyle = False
          Style.LookAndFeel.SkinName = ''
          StyleDisabled.LookAndFeel.NativeStyle = False
          StyleDisabled.LookAndFeel.SkinName = ''
          TabOrder = 1
          Checked = True
          ExplicitTop = 329
          ExplicitWidth = 1176
          Height = 110
          Width = 1174
          object Ed_Historico: TMgDBMemo
            AlignWithMargins = True
            Left = 6
            Top = 30
            Margins.Left = 4
            Margins.Right = 4
            Align = alClient
            DataBinding.DataField = 'IPH_ST_OBSERVACAO'
            Properties.ReadOnly = True
            Properties.ScrollBars = ssVertical
            Style.BorderStyle = ebsUltraFlat
            Style.LookAndFeel.SkinName = ''
            StyleDisabled.LookAndFeel.SkinName = ''
            StyleFocused.LookAndFeel.SkinName = ''
            StyleHot.LookAndFeel.SkinName = ''
            TabOrder = 0
            DataField = 'IPH_ST_OBSERVACAO'
            ReadOnly = True
            ScrollBars = ssVertical
            Height = 75
            Width = 1162
          end
          object mgLabel7: TmgLabel
            AlignWithMargins = True
            Left = 6
            Top = 8
            Margins.Left = 4
            Margins.Top = 6
            Margins.Right = 4
            Margins.Bottom = 0
            Align = alTop
            Caption = 'Motivo da altera'#231#227'o'
            ParentFont = False
            Style.Font.Charset = DEFAULT_CHARSET
            Style.Font.Color = clBlack
            Style.Font.Height = -13
            Style.Font.Name = 'Calibri'
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
            ExplicitWidth = 1164
          end
        end
      end
    end
  end
  inherited Pn_ToolBar: TmgPanel
    Top = 511
    Width = 1184
    TabOrder = 4
    ExplicitTop = 530
    ExplicitWidth = 1184
    inherited Pn_Aux_Left: TmgPanel
      Width = 1184
      ExplicitWidth = 1184
      inherited Pn_BaseBotoesAux: TmgPanel
        Left = 888
        Visible = True
        ExplicitLeft = 1083
        inherited Bo_Cancela: TMgBitBtn
          Left = 201
          Glyph.Data = {
            424D360400000000000036000000280000001000000010000000010020000000
            000000000000C40E0000C40E00000000000000000000FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00}
          LookAndFeel.SkinName = ''
          ExplicitLeft = 201
        end
        inherited Bo_OK: TMgBitBtn
          Left = 102
          Glyph.Data = {
            424D360400000000000036000000280000001000000010000000010020000000
            000000000000C40E0000C40E00000000000000000000FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
            FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00}
          LookAndFeel.SkinName = ''
          ModalResult = 0
          Visible = True
          ExplicitLeft = 102
        end
        inherited Pn_Base_Fechar: TmgPanel
          Left = 0
          ExplicitLeft = 0
          inherited Bo_Fechar: TMgBitBtn
            Glyph.Data = {
              424D360400000000000036000000280000001000000010000000010020000000
              000000000000C40E0000C40E00000000000000000000FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFF
              FF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00FFFFFF00}
            LookAndFeel.SkinName = ''
          end
        end
      end
      inherited pn_aux_right2: TmgPanel
        Left = 886
        ExplicitLeft = 1182
      end
      inherited Pn_Aux_Left_Base: TmgPanel
        Width = 884
        ExplicitWidth = 1081
        object Pn_BotoesItens: TmgPanel
          Left = 0
          Top = 0
          Width = 884
          Height = 31
          Align = alClient
          BevelOuter = bvNone
          ParentBackground = False
          ParentColor = True
          TabOrder = 0
          ExplicitWidth = 1081
        end
      end
    end
  end
  inherited StatusBar1: TStatusBar
    Top = 542
    Width = 1184
    ExplicitTop = 542
    ExplicitWidth = 1184
  end
  inherited Pn_SpaceBottom: TmgPanel
    Top = 506
    Width = 1184
    ExplicitTop = 506
    ExplicitWidth = 1184
  end
  inherited Pn_ToolBarEdicao: TmgPanel
    Width = 1184
    TabOrder = 5
    Visible = True
    ExplicitWidth = 1184
  end
  inherited Pn_BasePesquisa: TmgPanel
    Left = 862
    Top = -23
    ExplicitLeft = 862
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
  inherited mgPopupImpressao: TmgPopupMenu
    Left = 90
  end
  inherited CL_CampoEncontrado_: TMgClientDataSet
    Active = False
    Left = 339
    Top = 6
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
    Left = 379
    Top = 6
  end
end