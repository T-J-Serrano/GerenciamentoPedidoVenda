Dim cDs_Owner_Dados
Dim cCl_PedProg, cCL_LogPedProg
Dim cDs_PedProg, cDs_LogPedProg

Dim cCl_ValidaData

Dim cCl_AtualizaProg

'//Luiz T.I. - Chamado 2188 | 10/06/2026 09:09 Parte 1 - Início (Alterar programação de entrega para todos os itens dos pedidos de venda do grid)
Dim Ed_AlterarData
'//Luiz T.I. - Chamado 2188 | 10/06/2026 09:09 Parte 1 - Fim

Sub OnFormCreate
  With FORM_FS_PROG_ENTREGA

    cDs_Owner_Dados = FormAtivo.Owner.FindComponent("Ds_Dados")

    cCl_PedProg       = New TmgClientDataset(FormAtivo)
    cCL_LogPedProg    = New TmgClientDataset(FormAtivo)
    cCl_ValidaData    = New TmgClientDataset(FormAtivo)
    cCl_AtualizaProg  = New TmgClientDataset(FormAtivo)

    cDs_PedProg     = New TmgDataSource(FormAtivo)
    cDs_LogPedProg  = New TmgDataSource(FormAtivo)

    BO_Ok.OnBeforeClick = AddressOf BO_Ok_OnAfterClick

    With cCl_PedProg
      OnBeforeOpen  = AddressOf cCl_PedProg_OnBeforeOpen
      Name = "cCl_PedProg"
      TableName = "VEN_PEDPROGENTREGA"
      IndexFieldNames = "ORG_TAB_IN_CODIGO;ORG_PAD_IN_CODIGO;ORG_IN_CODIGO;ORG_TAU_ST_CODIGO;PED_IN_CODIGO;ITP_IN_SEQUENCIA;IPE_IN_SEQUENCIA"
      PkFields = IndexFieldNames
      '// MasterSource = cDs_Owner_Dados
      '// MasterFields = IndexFieldNames
      Sql.Add(" select IPE.ORG_TAB_IN_CODIGO,")
      Sql.Add("        IPE.ORG_PAD_IN_CODIGO,")
      Sql.Add("        IPE.ORG_IN_CODIGO,")
      Sql.Add("        IPE.ORG_TAU_ST_CODIGO,")
      Sql.Add("        IPE.SER_ST_CODIGO,")
      Sql.Add("        IPE.PED_IN_CODIGO,")
      Sql.Add("        IPE.ITP_IN_SEQUENCIA,")
      Sql.Add("        IPE.IPE_IN_SEQUENCIA,")
      Sql.Add("        IPE.IPE_RE_QUANTIDADE,")
      Sql.Add("        IPE.IPE_RE_QTDECONVERTIDA,")
      Sql.Add("        IPE.UNI_ST_UNIDADE,")
      Sql.Add("        AGN.AGN_IN_CODIGO,")
      Sql.Add("        AGN.AGN_ST_NOME,")
      Sql.Add("        PRO.PRO_ST_ALTERNATIVO,")
      Sql.Add("        PRO.PRO_ST_DESCRICAO,")
      Sql.Add("        PRO.UNI_ST_UNIDADE PRO_ST_UNIDADE,")
      Sql.Add("        IPE.IPE_ST_NUMEROORDEM,")
      Sql.Add("        IPE.IPE_DT_DATAEMISSAO,")
      Sql.Add("        IPE.IPE_RE_QTDEENTREGUE,")
      Sql.Add("        IPE.IPE_RE_QTDEFATURADA,")
      Sql.Add("        IPE.IPE_CH_ENTREGAPARCIAL,")
      Sql.Add("        IPE.IPE_CH_TIPOENTREGA,")
      Sql.Add("        IPE.EMB_TAB_IN_CODIGO,")
      Sql.Add("        IPE.EMB_PAD_IN_CODIGO,")
      Sql.Add("        IPE.EMB_IN_CODIGO,")
      Sql.Add("        EMB.PRO_ST_DESCRICAO,")
      Sql.Add("        DECODE(IPE.IPE_CH_TIPOENTREGA,")
      Sql.Add("               'P',")
      Sql.Add("               'Após Data',")
      Sql.Add("               'A',")
      Sql.Add("               'Até a Data',")
      Sql.Add("               'S',")
      Sql.Add("               'Somente na data',")
      Sql.Add("               'Outro') IPE_ST_TIPOENTREGA,")
      Sql.Add("         IPE.ENA_IN_CODIGO,")
      Sql.Add("         ENA.ENA_ST_LOGRADOURO,")
      Sql.Add("         ENA.ENA_ST_MUNICIPIO,")
      Sql.Add("         IPE.IPE_DT_DATAEXPEDICAO,")
      Sql.Add("         IPE.IPE_DT_DATAEMISSAO,")
      Sql.Add("         IPE.IPE_DT_DATAORIGINAL,")
      Sql.Add("         IPE.IPE_DT_DATAPLANEJADA,")
      Sql.Add("         IPE.IPE_CH_TIPOENTREGA,")
      Sql.Add("         IPE.IPE_CH_TIPODATA,")
      Sql.Add("         IPE.IPE_DT_DATAENTREGA,")
      Sql.Add("         ITP.ITP_ST_DESCRICAO,")
      Sql.Add("         cast(null as VARCHAR2(4000)) IPH_ST_OBSERVACAO,")
      Sql.Add("         IPE.IPE_CH_SITUACAO,")
      Sql.Add("        (select count(1)")
      Sql.Add("           from VEN_PEDPROGENTREGA I")
      Sql.Add("          where I.ORG_TAB_IN_CODIGO = IPE.ORG_TAB_IN_CODIGO")
      Sql.Add("            and I.ORG_PAD_IN_CODIGO = IPE.ORG_PAD_IN_CODIGO")
      Sql.Add("            and I.ORG_IN_CODIGO     = IPE.ORG_IN_CODIGO")
      Sql.Add("            and I.ORG_TAU_ST_CODIGO = IPE.ORG_TAU_ST_CODIGO")
      Sql.Add("            and I.SER_ST_CODIGO     = IPE.SER_ST_CODIGO")
      Sql.Add("            and I.PED_IN_CODIGO     = IPE.PED_IN_CODIGO")
      Sql.Add("            and I.IPE_CH_SITUACAO   = 'A') IPE_IN_SITUACAO_AB ")
      Sql.Add("   from VEN_PEDIDOVENDA PED")
      Sql.Add("   join VEN_ITEMPEDIDOVENDA ITP")
      Sql.Add("     on ITP.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
      Sql.Add("    and ITP.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
      Sql.Add("    and ITP.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
      Sql.Add("    and ITP.ORG_TAU_ST_CODIGO = PED.ORG_TAU_ST_CODIGO")
      Sql.Add("    and ITP.SER_ST_CODIGO = PED.SER_ST_CODIGO")
      Sql.Add("    and ITP.PED_IN_CODIGO = PED.PED_IN_CODIGO")
      Sql.Add("   join VEN_PEDPROGENTREGA IPE")
      Sql.Add("     on IPE.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
      Sql.Add("    and IPE.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
      Sql.Add("    and IPE.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
      Sql.Add("    and IPE.ORG_TAU_ST_CODIGO = PED.ORG_TAU_ST_CODIGO")
      Sql.Add("    and IPE.SER_ST_CODIGO = PED.SER_ST_CODIGO")
      Sql.Add("    and IPE.PED_IN_CODIGO = PED.PED_IN_CODIGO")
      Sql.Add("    and IPE.ITP_IN_SEQUENCIA = ITP.ITP_IN_SEQUENCIA")
      Sql.Add("   join GLO_AGENTES AGN")
      Sql.Add("     on AGN.AGN_TAB_IN_CODIGO = PED.CLI_TAB_IN_CODIGO")
      Sql.Add("    and AGN.AGN_PAD_IN_CODIGO = PED.CLI_PAD_IN_CODIGO")
      Sql.Add("    and AGN.AGN_IN_CODIGO = PED.CLI_IN_CODIGO")
      Sql.Add("   left join GLO_ENDAGENTES ENA")
      Sql.Add("     on ENA.AGN_TAB_IN_CODIGO = PED.CLI_TAB_IN_CODIGO")
      Sql.Add("    and ENA.AGN_PAD_IN_CODIGO = PED.CLI_PAD_IN_CODIGO")
      Sql.Add("    and ENA.AGN_IN_CODIGO     = PED.CLI_IN_CODIGO")
      Sql.Add("    and ENA.ENA_IN_CODIGO     = PED.ENA_IN_CODIGO")
      Sql.Add("   join EST_PRODUTOS PRO")
      Sql.Add("     on PRO.PRO_TAB_IN_CODIGO = ITP.PRO_TAB_IN_CODIGO")
      Sql.Add("    and PRO.PRO_PAD_IN_CODIGO = ITP.PRO_PAD_IN_CODIGO")
      Sql.Add("    and PRO.PRO_IN_CODIGO = ITP.PRO_IN_CODIGO")
      Sql.Add("   left join EST_PRODUTOS EMB")
      Sql.Add("     on IPE.EMB_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
      Sql.Add("    and IPE.EMB_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
      Sql.Add("    and IPE.EMB_IN_CODIGO = PRO.PRO_IN_CODIGO")
      Sql.Add("   where IPE.ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO")
      Sql.Add("     and IPE.ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO")
      Sql.Add("     and IPE.ORG_IN_CODIGO = :pORG_IN_CODIGO")
      Sql.Add("     and IPE.ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO")
      Sql.Add("     and IPE.PED_IN_CODIGO = :pPED_IN_CODIGO")
      Sql.Add("     and IPE.ITP_IN_SEQUENCIA = :pITP_IN_SEQUENCIA")
      Sql.Add("     and IPE.IPE_IN_SEQUENCIA  = :pIPE_IN_SEQUENCIA")
    End With

    With cDs_PedProg
      Name = "cDs_PedProg"
      Dataset =  cCl_PedProg
    End With

    cCl_PedProg.Open

    With Ed_Cli_IN_CODIGO
      DataSource = cDs_PedProg
      DataField = "AGN_IN_CODIGO"
    End With

    With Lx_CLI_IN_CODIGO
      DataSource = cDs_PedProg
      DataField = "AGN_ST_NOME"
    End With

    '// Endereço

    With Ed_ENA_IN_CODIGO
      DataSource = cDs_PedProg
      DataField = "ENA_IN_CODIGO"
      Enabled = False
    End With

    With Lb_ENA_ST_LOGRADOURO
      DataSource = cDs_PedProg
      DataField = "ENA_ST_LOGRADOURO"
      Enabled = False
    End With

    With Lb_ENA_ST_MUNICIPIO
      DataSource = cDs_PedProg
      DataField = "ENA_ST_MUNICIPIO"
      Enabled = False
    End With

    With Ed_IPE_ST_NUMEROORDEM
      DataSource = cDs_PedProg
      DataField = "IPE_ST_NUMEROORDEM"
      Enabled = False
    End With

    With Ed_IPE_DT_DATAEMISSAO
      DataSource = cDs_PedProg
      DataField = "IPE_DT_DATAEMISSAO"
      Enabled = False
    End With

    '// Produto

    With Ed_PRO_ST_ALTERNATIVO
      DataSource = cDs_PedProg
      DataField = "PRO_ST_ALTERNATIVO"
      Enabled = False
    End With

    With Ed_ITP_ST_DESCRICAO
      DataSource = cDs_PedProg
      Enabled = False
    End With
    '//

    '// Linha qtde
    With Ed_IPE_RE_QUANTIDADE
      DataSource = cDs_PedProg
      Enabled = False
    End With

    With Ed_IPE_RE_QTDEENTREGUE
      DataSource = cDs_PedProg
      Enabled = False
    End With

    With Ed_IPE_RE_QTDEFATURADA
      DataSource = cDs_PedProg
      Enabled = False
    End With

    '//
    With Ed_UNI_ST_UNIDADE
      DataSource = cDs_PedProg
      DataField = "UNI_ST_UNIDADE"
      Enabled = False
    End With

    With Ed_IPE_RE_QTDECONVERTIDA
      DataSource = cDs_PedProg
      Enabled = False
    End With

    With Ed_PRO_ST_UNIDADE
      DataSource = cDs_PedProg
      Enabled = False
    End With

    '// Condições de Entrega
    With Ed_IPE_CH_ENTREGAPARCIAL
      DataSource = cDs_PedProg
      Enabled = False
    End With

    '//

    Dim vAberto = cCl_PedProg.FieldByName("IPE_CH_SITUACAO").AsString = "A"

    With Ed_IPE_DT_DATAEXPEDICAO
      DataSource = cDs_PedProg
      Enabled = vAberto
      OnAfterExit = AddressOf ValidaData_OnBeforeExit
    End With

    With Ed_IPE_DT_DATAENTREGA
      DataSource = cDs_PedProg
      Enabled = vAberto
      OnBeforeExit = AddressOf ValidaData_OnBeforeExit
    End With

    With ED_IPE_CH_TIPOENTREGA
      DataSource = cDs_PedProg
      Enabled = vAberto
    End With

    With Ed_IPE_CH_TIPODATA
      DataSource = cDs_PedProg
      Enabled = vAberto
    End With

    With Ed_IPE_DT_DATAORIGINAL
      DataSource = cDs_PedProg
      Enabled = vAberto
    End With

    With Ed_IPE_DT_DATAPLANEJADA
      DataSource = cDs_PedProg
      Enabled = vAberto
    End With

    With ED_IPH_ST_OBSERVACAO
      DataSource = cDs_PedProg
      Enabled = vAberto
    End With

    '//Luiz T.I. - Chamado 2188 | 10/06/2026 09:09 Parte 2 - Início
    Ed_AlterarData = New TMgCheckBox(FormAtivo)
    With Ed_AlterarData
      '//DataSource = cDs_PedProg
      Name       = "Lx_AlterarData"
      Caption    = "Replicar data de entrega para todos os itens do grid"
      Parent     = FormAtivo.Gr_CondicoesEntrega
      Top        = FormAtivo.Ed_IPE_CH_ENTREGAPARCIAL.Top
      Left       = FormAtivo.Ed_IPE_CH_ENTREGAPARCIAL.Left + 155
      Height     = FormAtivo.Ed_IPE_CH_ENTREGAPARCIAL.Height
      Enabled    = vAberto
      Checked    = False
    End With
    '//Luiz T.I. - Chamado 2188 | 10/06/2026 09:09 Parte 2 - Fim

    With cCL_LogPedProg
      OnBeforeOpen  = AddressOf cCl_PedProg_OnBeforeOpen
      Name = "cCL_LogPedProg"
      TableName = "VEN_PEDPROGENTREGAHIST"
      IndexFieldNames = "ORG_TAB_IN_CODIGO;ORG_PAD_IN_CODIGO;ORG_IN_CODIGO;ORG_TAU_ST_CODIGO;PED_IN_CODIGO;ITP_IN_SEQUENCIA;IPE_IN_SEQUENCIA"
      PkFields = IndexFieldNames
      '// MasterSource = cDs_PedProg
      '// MasterFields = IndexFieldNames
      Sql.Add(" select IPH.ORG_TAB_IN_CODIGO,")
      Sql.Add("         IPH.ORG_PAD_IN_CODIGO,")
      Sql.Add("         IPH.ORG_IN_CODIGO,")
      Sql.Add("         IPH.ORG_TAU_ST_CODIGO,")
      Sql.Add("         IPH.SER_ST_CODIGO,")
      Sql.Add("         IPH.PED_IN_CODIGO,")
      Sql.Add("         IPH.ITP_IN_SEQUENCIA,")
      Sql.Add("         IPH.IPE_IN_SEQUENCIA,")
      Sql.Add("         IPH.IPH_IN_SEQUENCIA,")
      Sql.Add("         IPH.IPH_DT_DATAENTREGANOVA,")
      Sql.Add("         IPH.IPH_DT_DATAENTREGAANT,")
      Sql.Add("         IPH.IPH_DT_ALTERACAO,")
      '// Sql.Add("         IPH.IPH_CH_TIPODATA,")
      Sql.Add("         IPH.IPH_ST_OBSERVACAO,")
      Sql.Add("         GRU.GRU_IN_CODIGO,")
      Sql.Add("         GRU.GRU_ST_NOME,")
      Sql.Add("         decode(IPH.IPH_CH_TIPODATA, 'P', 'Planejado', 'Original') IPH_CH_TIPODATA")
      Sql.Add("  from VEN_PEDPROGENTREGAHIST IPH")
      Sql.Add("  join GLO_GRUPO_USUARIO GRU")
      Sql.Add("    on IPH.USU_IN_CODIGO = GRU.GRU_IN_CODIGO")
      Sql.Add("   where IPH.ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO")
      Sql.Add("     and IPH.ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO")
      Sql.Add("     and IPH.ORG_IN_CODIGO = :pORG_IN_CODIGO")
      Sql.Add("     and IPH.ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO")
      Sql.Add("     and IPH.PED_IN_CODIGO = :pPED_IN_CODIGO")
      Sql.Add("     and IPH.ITP_IN_SEQUENCIA = :pITP_IN_SEQUENCIA")
      Sql.Add("     and IPH.IPE_IN_SEQUENCIA  = :pIPE_IN_SEQUENCIA")
      Sql.Add("   order by IPH.IPH_DT_ALTERACAO")
    End With


    With cDs_LogPedProg
      Name = "cDs_LogPedProg"
      Dataset = cCL_LogPedProg
    End With

    cCL_LogPedProg.Open

    '// Grid Histórico
    With Gd_ProgEntregaHist
      DataSource = cDs_LogPedProg
    End With


    With Ed_Historico
      DataSource = cDs_LogPedProg
    End With

    With cCl_ValidaData
      Name =  "cCl_ValidaData"
      TableName = "dual"
      Sql.Add(" select 'A data não pode ser um feriado: ' || FER.FER_ST_NOME FER_ST_NOME")
      Sql.Add("   from GLO_FERIADO FER")
      Sql.Add("  where FER.FER_DT_FERIADO = TO_DATE(:PFER_DT_FERIADO, 'DD/MM/RRRR')")
      Sql.Add(" union")
      Sql.Add(" select DECODE(TO_CHAR(TO_DATE(:PFER_DT_FERIADO, 'DD/MM/RRRR'), 'D'),")
      Sql.Add("               1,")
      Sql.Add("               'A data não pode ser um domingo!',")
      Sql.Add("               7,")
      Sql.Add("               'A data não pode ser um sábado!',")
      Sql.Add("               '') as FER_ST_NOME")
      Sql.Add("   from DUAL")
    End With

    With cCl_AtualizaProg
      Name = "cCl_AtualizaProg"
      TableName = "DUAL"
      Sql.Add(" begin")
      Sql.Add("   FS_PCK_PEDIDOVENDA.PRC_ALTERA_PROGRAMACAO(PORG_TAB_IN_CODIGO => :PORG_TAB_IN_CODIGO,")
      Sql.Add("                                             PORG_PAD_IN_CODIGO => :PORG_PAD_IN_CODIGO,")
      Sql.Add("                                             PORG_IN_CODIGO => :PORG_IN_CODIGO,")
      Sql.Add("                                             PORG_TAU_ST_CODIGO => :PORG_TAU_ST_CODIGO,")
      Sql.Add("                                             PSER_ST_CODIGO => :PSER_ST_CODIGO,")
      Sql.Add("                                             PPED_IN_CODIGO => :PPED_IN_CODIGO,")
      Sql.Add("                                             PITP_IN_SEQUENCIA => :PITP_IN_SEQUENCIA,")
      Sql.Add("                                             PIPE_IN_SEQUENCIA => :PIPE_IN_SEQUENCIA,")
      Sql.Add("                                             PHISTORICO => :PHISTORICO,")
      Sql.Add("                                             PUSU_IN_CODIGO => :PUSU_IN_CODIGO,")
      Sql.Add("                                             PIPE_DT_DATAENTREGA => :PIPE_DT_DATAENTREGA,")
      Sql.Add("                                             PIPE_DT_DATAEXPEDICAO => :PIPE_DT_DATAEXPEDICAO,")
      Sql.Add("                                             PIPE_CH_TIPOENTREGA => :PIPE_CH_TIPOENTREGA,")
      Sql.Add("                                             PIPE_CH_TIPODATA => :PIPE_CH_TIPODATA,")
      Sql.Add("                                             PALTERA_PROG => :PALTERA_PROG);")
      Sql.Add(" end;")
    End With

  End with
End Sub

Sub ValidaData_OnBeforeExit(Sender)
  Dim Value = Sender.DateValue

  With cCl_ValidaData
    Close
    ParamByName("PFER_DT_FERIADO").Value =  Value
    Open

    '// showmessage(FieldByName("FER_ST_NOME").AsString)


    If FieldByName("FER_ST_NOME").AsString <> "" Then

      MgMessageDlg(cCl_ValidaData.FieldByName("FER_ST_NOME").AsString, mtError, mbOk, 0)
      Sender.SetFocus
      RaiseException("")
    End If
  End With

End Sub

Sub cCl_PedProg_OnBeforeOpen(Sender)
  With Sender
    ParamByName("pORG_TAB_IN_CODIGO").Value = cDs_Owner_Dados.DataSet.FieldByName("ORG_TAB_IN_CODIGO").Value
    ParamByName("pORG_PAD_IN_CODIGO").Value = cDs_Owner_Dados.DataSet.FieldByName("ORG_PAD_IN_CODIGO").Value
    ParamByName("pORG_IN_CODIGO").Value = cDs_Owner_Dados.DataSet.FieldByName("ORG_IN_CODIGO").Value
    ParamByName("pORG_TAU_ST_CODIGO").Value = cDs_Owner_Dados.DataSet.FieldByName("ORG_TAU_ST_CODIGO").Value
    ParamByName("pPED_IN_CODIGO").Value = cDs_Owner_Dados.DataSet.FieldByName("PED_IN_CODIGO").Value
    ParamByName("pITP_IN_SEQUENCIA").Value = cDs_Owner_Dados.DataSet.FieldByName("ITP_IN_SEQUENCIA").Value
    ParamByName("pIPE_IN_SEQUENCIA").Value = cDs_Owner_Dados.DataSet.FieldByName("IPE_IN_SEQUENCIA").Value
  End With
End Sub

Sub BO_Ok_OnAfterClick
  With FormAtivo

    Dim vAlteraProgs = "N"

    If cCl_PedProg.FieldByName("IPH_ST_OBSERVACAO").AsString = "" Then
      MgMessageDlg("O Motivo da Alteração não foi preenchido!", mtError, mbOk, 0)
      ED_IPH_ST_OBSERVACAO.SetFocus
      RaiseException("")
    End If

    '//Luiz T.I. - Chamado 2188 | 10/06/2026 09:09 Parte 3 - Início
    Dim Cl_DadosAux = FormAtivo.Owner.FindComponent("Cl_Dados") '//Pega o grid da tela principal

    If Ed_AlterarData.Checked Then
      If MgMessageDlg("A opção de replicar a data de entrega para todos os itens do grid está selecionada, deseja continuar ?", mtConfirmation, mbYes+mbNo, 0) = mrYes Then
        Dim PedAtual = Cl_DadosAux.FieldByName("PED_IN_CODIGO").Value
        Dim ItpAtual = Cl_DadosAux.FieldByName("ITP_IN_SEQUENCIA").Value
        Dim IpeAtual = Cl_DadosAux.FieldByName("IPE_IN_SEQUENCIA").Value

        Cl_DadosAux.DisableControls
        Cl_DadosAux.First
        
        While Not Cl_DadosAux.EOF
          With cCl_AtualizaProg
            ParamByName("PORG_TAB_IN_CODIGO").Value    = Cl_DadosAux.FieldByName("ORG_TAB_IN_CODIGO").Value
            ParamByName("PORG_PAD_IN_CODIGO").Value    = Cl_DadosAux.FieldByName("ORG_PAD_IN_CODIGO").Value
            ParamByName("PORG_IN_CODIGO").Value        = Cl_DadosAux.FieldByName("ORG_IN_CODIGO").Value
            ParamByName("PORG_TAU_ST_CODIGO").Value    = Cl_DadosAux.FieldByName("ORG_TAU_ST_CODIGO").Value
            ParamByName("PSER_ST_CODIGO").Value        = Cl_DadosAux.FieldByName("SER_ST_CODIGO").Value
            ParamByName("PPED_IN_CODIGO").Value        = Cl_DadosAux.FieldByName("PED_IN_CODIGO").Value
            ParamByName("PITP_IN_SEQUENCIA").Value     = Cl_DadosAux.FieldByName("ITP_IN_SEQUENCIA").Value
            ParamByName("PIPE_IN_SEQUENCIA").Value     = Cl_DadosAux.FieldByName("IPE_IN_SEQUENCIA").Value
            
            ParamByName("PHISTORICO").Value            = cCl_PedProg.FieldByName("IPH_ST_OBSERVACAO").Value
            ParamByName("PUSU_IN_CODIGO").Value        = DMMega.Usuario
            ParamByName("PIPE_DT_DATAENTREGA").Value   = cCl_PedProg.FieldByName("IPE_DT_DATAENTREGA").Value
            ParamByName("PIPE_DT_DATAEXPEDICAO").Value = cCl_PedProg.FieldByName("IPE_DT_DATAEXPEDICAO").Value
            ParamByName("PIPE_CH_TIPOENTREGA").Value   = cCl_PedProg.FieldByName("IPE_CH_TIPOENTREGA").Value
            ParamByName("PIPE_CH_TIPODATA").Value      = cCl_PedProg.FieldByName("IPE_CH_TIPODATA").Value
            
            ParamByName("PALTERA_PROG").Value          = "N"
            
            ExecSql
          End With
          
          Cl_DadosAux.Next
        Wend

        Cl_DadosAux.Close
        Cl_DadosAux.Open

        Try
          Dim chavesLocate
          chavesLocate = VarArrayCreate([0, 2], varVariant)
          
          chavesLocate[0] = PedAtual
          chavesLocate[1] = ItpAtual
          chavesLocate[2] = IpeAtual

          Cl_DadosAux.Locate("PED_IN_CODIGO;ITP_IN_SEQUENCIA;IPE_IN_SEQUENCIA", chavesLocate, 0)
        Catch
          ShowMessage("Erro ao reposicionar o cursor: " & ExceptionMessage)
        End Try

        Cl_DadosAux.EnableControls
      Else
        MgMessageDlg("A alteração foi cancelada.", mtInformation, mbOk, 0)
      End If

    Else
    '//Luiz T.I. - Chamado 2188 | 10/06/2026 09:09 Parte 3 - Fim

    If cCl_PedProg.FieldByName("IPE_IN_SITUACAO_AB").AsInteger > 0 Then

      vAlteraProgs =  MgMessageDlg("Deseja alterar as outras programações em aberto para as datas informada?", mtConfirmation, mbYes+mbNo, 0) = mrYes

      If vAlteraProgs Then
        vAlteraProgs = "S"
      Else
        vAlteraProgs = "N"
      End If

    End If

    With cCl_AtualizaProg
      ParamByName("PORG_TAB_IN_CODIGO").Value = cCl_PedProg.FieldByName("ORG_TAB_IN_CODIGO").Value
      ParamByName("PORG_PAD_IN_CODIGO").Value = cCl_PedProg.FieldByName("ORG_PAD_IN_CODIGO").Value
      ParamByName("PORG_IN_CODIGO").Value = cCl_PedProg.FieldByName("ORG_IN_CODIGO").Value
      ParamByName("PORG_TAU_ST_CODIGO").Value = cCl_PedProg.FieldByName("ORG_TAU_ST_CODIGO").Value
      ParamByName("PSER_ST_CODIGO").Value = cCl_PedProg.FieldByName("SER_ST_CODIGO").Value
      ParamByName("PPED_IN_CODIGO").Value = cCl_PedProg.FieldByName("PED_IN_CODIGO").Value
      ParamByName("PITP_IN_SEQUENCIA").Value = cCl_PedProg.FieldByName("ITP_IN_SEQUENCIA").Value
      ParamByName("PIPE_IN_SEQUENCIA").Value = cCl_PedProg.FieldByName("IPE_IN_SEQUENCIA").Value
      ParamByName("PHISTORICO").Value = cCl_PedProg.FieldByName("IPH_ST_OBSERVACAO").Value
      ParamByName("PUSU_IN_CODIGO").Value = DMMega.Usuario
      ParamByName("PIPE_DT_DATAENTREGA").Value = cCl_PedProg.FieldByName("IPE_DT_DATAENTREGA").Value
      ParamByName("PIPE_DT_DATAEXPEDICAO").Value = cCl_PedProg.FieldByName("IPE_DT_DATAEXPEDICAO").Value
      ParamByName("PIPE_CH_TIPOENTREGA").Value = cCl_PedProg.FieldByName("IPE_CH_TIPOENTREGA").Value
      ParamByName("PIPE_CH_TIPODATA").Value = cCl_PedProg.FieldByName("IPE_CH_TIPODATA").Value
      ParamByName("PALTERA_PROG").Value = vAlteraProgs
      ExecSql

      Dim Cl_Dados = TmgBitBtn(FormAtivo.Owner.FindComponent("Cl_Dados"))

      Cl_Dados.DisableControls
      Cl_Dados.Close
      Cl_Dados.Open
      Cl_Dados.EnableControls

    End With

    '//Luiz T.I. - Chamado 2188 | 10/06/2026 09:09 Parte 4 - Início
    End If
    '//Luiz T.I. - Chamado 2188 | 10/06/2026 09:09 Parte 4 - Fim
  End With
End Sub