'// Objetos para Popular a Guia de Pedido
Dim Tv_Dados, Gd_Dados, Pn_Grid

'// Lookups para os campos de filtro
Dim Lk_Cliente         , Lk_Itens   , Lk_Grupos   , Lk_SubGrupos
Dim Cl_Lk_Clientes     , Cl_Lk_Itens, Cl_Lk_Grupos, Cl_Lk_SubGrupos
Dim Ds_Lk_Cliente      , Ds_Lk_Itens, Ds_Lk_Grupos, Ds_Lk_SubGrupos
Dim Cl_Lk_Representante, Ds_Lk_Representante, Lk_Representante
Dim Cl_Lk_TipoDoc      , Ds_Lk_TipoDoc, Lk_TipoDoc

'//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 1 - Início (Chamado 2188 - Alterar programação de entrega para todos os itens dos pedidos de venda do grid)
Dim cCl_GrupoCliente, cDs_GrupoCliente, cLk_GrupoCliente
'//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 1 - Fim

'//DataSet's das Tabelas Customizadas
Dim Cl_Fs_PedidoVendaGer, _
    Cl_FS_PedProgEntregaOco, _
    Cl_FS_PedProgEntrega, _
    Cl_Fs_PedidoVenda,_
    Cl_FS_PRC_PEDPROENTREGA,_
    Cl_FS_PRC_PEDPROENTREGADATA, _
    Cl_FS_PRC_PEDPROENTREGADATACLIENTE, _
    Cl_FS_PRC_PEDPROGDATAEXP, _
    Cl_FS_RESERVAAUTO, _
    Cl_FS_SEQ_RESERVAAUTO, _
    Cl_FS_RESERVAAUTO_Update

'// DataSet para Atualizar dados da Programação e Expedição (Tabela Padrão)
Dim Cl_Expedicao     , Cl_Programacao   , Cl_ProgramacaoInsere, Cl_DadosProgramadas
Dim Cl_OrdemExpedicao, Ds_OrdemExpedicao, Tv_OrdemExpedicao, Gd_OrdemExpedicao
Dim Cl_NotaFiscal    , Ds_NotaFiscal    , Tv_NotaFiscal    , Gd_NotaFiscal
Dim Cl_PedProgEntregaItem

'// Exibição do Usuário Logado
Dim Cl_Usuario
Dim Pn_Usuario       , Lb_Usuario
'// Lista para popular as combobox dentro do grid
Dim Sl_Prioridade    AS TStringList '//--- Coluna de Prioridade
Dim Sl_StatusEntrega AS TStringList '//--- Coluna Status da Entrega
Dim Cl_TipoOcorrencias, _
    Cl_IntegraOe,_
    vSeleciona

Dim TipoOcorrencias, _
    ProcessaOnAfterChange as String = "N"
Dim Cl_SaldoDisponivel, _
    Cl_SaldoDisponivelItem, _
    Cl_DadosResevaAutomatica

'//Permissões do Gerenciamento de Pedido de Vendas
Dim Cl_Permissoes
Dim vPermissaoB2B, _
    vPermissaoB2C, _
    vPermissaoExp, _
    vPermissaoOut
Dim Bt_Reserva

Dim vCl_DadosExecutaScroll AS Boolean = False
Dim vCl_OrdemExecutaScroll AS Boolean = False

'//Exclusão em Massa das OE's do Pedido de Venda - 15/06/2023 - Luan Oliveira
Dim Cl_ExcluiOEPedido

'//Verifica se existe apontamento - 22/06/2023 - Luan Oliveira
Dim Cl_FS_APT_APONTAORDEM, Cl_Update_Cl_FS_APT_APONTAORDEM
Dim vAbreTela AS String = "S"

Dim Mi_LogLiberacao, Mi_LogLiberacaoPed '// Matheus H. 09/04/2026

Dim Pm_Acoes, Mi_Clientes, Mi_Itens, Mi_Clientes_Itens, Mi_Saldos, Mi_Saldos_Grupo, Mi_Historico
Dim Mi_Ocorrencia, Mi_Hist_Prog, Mi_Embalagem, Mi_Excluir_Ped, Mi_Commissoes, Mi_ProgCorte, Mi_LogRomaneio
Dim Mi_Separador, Mi_PedProg, Mi_AlteraComissao, Mi_Romaneio, Mi_Romaneio_OE

'// Verifica Data Horizonte - Herbert
Dim cCL_DataHorizonte

Dim vTag_User

Sub OnFormCreate
    With FORM_FS_GERENCIAMENTO_PEDIDOVENDA


      vTag_User = DMMega.UsuarioNome + " - " + DateTimeToStr(Now)

      WindowState = wsMaximized
      Formativo.BorderIcons = 7

      Pm_Acoes = New TmgPopupMenu(FormAtivo)

      mgPanel14.Visible = False

      Mi_Clientes          = new TMenuItem(FormAtivo)
      Mi_Clientes.Caption = "Clientes"
      Mi_Clientes.OnClick = AddressOf Bt_ClassCliente_OnAfterClick
      Mi_Clientes.Name    = "Mi_Clientes"
      Pm_Acoes.Items.Add(Mi_Clientes)

      Mi_Itens = new TMenuItem(FormAtivo)
      Mi_Itens.Caption = "Itens"
      Mi_Itens.OnClick =AddressOf Bt_ClassItem_OnAfterClick
      Mi_Itens.Name    = "Mi_Itens"
      Pm_Acoes.Items.Add(Mi_Itens)

      Mi_Clientes_Itens  = new TMenuItem(FormAtivo)
      Mi_Clientes_Itens.Caption = "Clientes/ Itens"
      Mi_Clientes_Itens.OnClick = AddressOf Bt_ClassClientesItens_OnAfterClick
      Mi_Clientes_Itens.Name    =  "Mi_Clientes_Itens"
      Pm_Acoes.Items.Add(Mi_Clientes_Itens)

      '//Mi_Saldos  = new TMenuItem(FormAtivo)
      '//Mi_Saldos.Caption = "Saldos"
      '//Mi_Saldos.OnClick = AddressOf Bt_Saldos_OnAfterClick
      '//Mi_Saldos.Name    =  "Mi_Saldos"
      '//Pm_Acoes.Items.Add(Mi_Saldos)

      Mi_Saldos_Grupo  = new TMenuItem(FormAtivo)
      Mi_Saldos_Grupo.Caption = "Saldos do Grupo"
      Mi_Saldos_Grupo.OnClick = AddressOf Bt_SaldosGrupo_OnAfterClick
      Mi_Saldos_Grupo.Name    =  "Mi_Saldos_Grupo"
      Pm_Acoes.Items.Add(Mi_Saldos_Grupo)

      '//Mi_Historico  = new TMenuItem(FormAtivo)
      '//Mi_Historico.Caption = "Histórico"
      '//Mi_Historico.OnClick = AddressOf Bt_Historico_OnAfterClick
      '//Mi_Historico.Name    =  "Mi_Historico"
      '//Pm_Acoes.Items.Add(Mi_Historico)

      Mi_Ocorrencia  = new TMenuItem(FormAtivo)
      Mi_Ocorrencia.Caption = "Ocorrências"
      Mi_Ocorrencia.OnClick = AddressOf Bt_OcorrenciaFin_OnAfterClick
      Mi_Ocorrencia.Name    =  "Mi_Ocorrencia"
      Pm_Acoes.Items.Add(Mi_Ocorrencia)

      Mi_Hist_Prog  = new TMenuItem(FormAtivo)
      Mi_Hist_Prog.Caption = "Histórico Alterações Prog. Entrega"
      Mi_Hist_Prog.OnClick = AddressOf cBt_HistAltProgEntrega_OnAfterClick
      Mi_Hist_Prog.Name    =  "Mi_Hist_Prog"
      Pm_Acoes.Items.Add(Mi_Hist_Prog)

      '//Mi_Embalagem  = new TMenuItem(FormAtivo)
      '//Mi_Embalagem.Caption = "Alterar Embalagem"
      '//Mi_Embalagem.OnClick = AddressOf Bt_AlteraEmbalagem_OnBeforeClick
      '//Mi_Embalagem.Name    =  "Mi_Embalagem"
      '//Pm_Acoes.Items.Add(Mi_Embalagem)

      Mi_Excluir_Ped  = new TMenuItem(FormAtivo)
      Mi_Excluir_Ped.Caption = "Excluir OEs do Pedido"
      Mi_Excluir_Ped.OnClick = AddressOf Bt_ExcluirOePedido_OnAfterClick
      Mi_Excluir_Ped.Name    =  "Mi_Excluir_Ped"
      Pm_Acoes.Items.Add(Mi_Excluir_Ped)

      Mi_Commissoes  = new TMenuItem(FormAtivo)
      Mi_Commissoes.Caption = "Comissões"
      Mi_Commissoes.OnClick = AddressOf Bt_Comissao_OnAfterClick
      Mi_Commissoes.Name    =  "Mi_Commissoes"
      Pm_Acoes.Items.Add(Mi_Commissoes)

      Mi_LogRomaneio = new TMenuItem(FormAtivo)
      Mi_LogRomaneio.Caption = "Log de Criação de Romaneio"
      Mi_LogRomaneio.OnClick =AddressOf Bt_LogCriacaoRomaneio_OnAfterClick
      Mi_LogRomaneio.Name    = "Mi_LogRomaneio"
      Pm_Acoes.Items.Add(Mi_LogRomaneio)

        '// Matheus H. 09/04/2026 Início

      Mi_LogLiberacao = new TMenuItem(FormAtivo)
      Mi_LogLiberacao.Caption = "Histórico de Liberações de OE"
      Mi_LogLiberacao.OnClick =AddressOf cBt_LogLiberacao_OnAfterClick
      Mi_LogLiberacao.Name    = "Mi_LogLiberacao"
      Pm_Acoes.Items.Add(Mi_LogLiberacao)

     '// Matheus H. 09/04/2026 Fim

     '// Matheus H. 09/04/2026 Início

      Mi_LogLiberacaoPed = new TMenuItem(FormAtivo)
      Mi_LogLiberacaoPed.Caption = "Histórico de Liberações de PDV"
      Mi_LogLiberacaoPed.OnClick =AddressOf cBt_LogLiberacaoPed_OnAfterClick
      Mi_LogLiberacaoPed.Name    = "Mi_LogLiberacaoPed"
      Pm_Acoes.Items.Add(Mi_LogLiberacaoPed)

     '// Matheus H. 09/04/2026 Fim

      '//Mi_ProgCorte = new TMenuItem(FormAtivo)
      '//Mi_ProgCorte.Caption = "Simulação Plano de Corte"
      '//Mi_ProgCorte.OnClick = AddressOf Bt_Simulacao_Corte
      '//Mi_ProgCorte.Name    = "Mi_ProgCorte"
      '//Pm_Acoes.Items.Add(Mi_ProgCorte)

      Bt_Simular.OnAfterClick = AddressOf Bt_Simulacao_Corte

      Mi_Separador = new TMenuItem(FormAtivo)
      Mi_Separador.Name = "Mi_Separador"
      Mi_Separador.Caption = "-"
      Pm_Acoes.Items.Insert(1,Mi_Separador)

      Mi_PedProg = new TMenuItem(FormAtivo)
      Mi_PedProg.Name = "Mi_PedProg"
      Mi_PedProg.Caption = "Alterar Prog. Entrega"
      Mi_PedProg.OnClick =AddressOf Mi_PedProg_OnAfterClick
      Mi_PedProg.Visible = True
      Pm_Acoes.Items.Insert(1,Mi_PedProg)

      Mi_AlteraComissao = new TMenuItem(FormAtivo)
      Mi_AlteraComissao.Name = "Mi_AlteraComissao"
      Mi_AlteraComissao.Caption = "Alterar Comissão"
      Mi_AlteraComissao.OnClick =AddressOf Mi_AlteraComissao_OnAfterClick
      Pm_Acoes.Items.Insert(1,Mi_AlteraComissao)

      Mi_Romaneio = new TMenuItem(FormAtivo)
      Mi_Romaneio.Name = "Mi_Romaneio"
      Mi_Romaneio.Caption = "Romaneio Expedição"
      Mi_Romaneio.OnClick =AddressOf Mi_Romaneio_OnAfterClick
      Pm_Acoes.Items.Insert(1,Mi_Romaneio)

      Mi_Romaneio_OE = new TMenuItem(FormAtivo)
      Mi_Romaneio_OE.Name = "Mi_Romaneio_OE"
      Mi_Romaneio_OE.Caption = "Conferência Romaneio OE"
      Mi_Romaneio_OE.OnClick =AddressOf Mi_Romaneio_OE_OnAfterClick
      Pm_Acoes.Items.Insert(1,Mi_Romaneio_OE)

      Bt_Acoes.DropDownMenu = Pm_Acoes

      Bt_Acoes.Colors = Bo_Ok.Colors

      '// Pm_Acoes.Items.Insert(3,Mi_Separador)

      '// Inicio Programação

      Sl_Prioridade = TStringList.Create
      Sl_Prioridade.Clear
      Sl_Prioridade.Add("0-Prioridade Não definida")
      Sl_Prioridade.Add("1-Prioridade Baixa"       )
      Sl_Prioridade.Add("2-Prioridade Média"       )
      Sl_Prioridade.Add("3-Prioridade Alta"        )
      '//Sl_Prioridade.Add("9-Exportação"             )

      Sl_StatusEntrega = TStringList.Create
      Sl_StatusEntrega.Clear
      Sl_StatusEntrega.Add("Bloqueado")
      Sl_StatusEntrega.Add("Liberado")

      Gd_Dados          = new TMgCxGrid(FormAtivo)
      Gd_OrdemExpedicao = new TMgCxGrid(FormAtivo)
      Gd_NotaFiscal     = new TMgCxGrid(FormAtivo)
      Pn_Grid           = new TmgPanel(FormAtivo)
      Pn_Usuario        = new TmgPanel(FormAtivo)
      Lb_Usuario        = new TmgLabel(FormAtivo)

      Lk_Representante = new TmgCLookup(FormAtivo)
      Lk_TipoDoc       = new TmgCLookup(FormAtivo)
      Lk_SubGrupos     = new TmgCLookup(FormAtivo)
      Lk_Cliente       = new TmgCLookup(FormAtivo)
      Lk_Itens         = new TmgCLookup(FormAtivo)
      Lk_Grupos        = new TmgCLookup(FormAtivo)

      '//Instancia os DataSets
      Cl_Usuario                         = new TmgClientDataSet(FormAtivo)
      Cl_IntegraOe                       = new TmgClientDataSet(FormAtivo)
      Cl_Expedicao                       = new TmgClientDataSet(FormAtivo)
      Cl_Programacao                     = new TmgClientDataSet(FormAtivo)
      Cl_DadosResevaAutomatica           = new TmgClientDataSet(FormAtivo)
      Cl_SaldoDisponivel                 = new TmgClientDataSet(FormAtivo)
      Cl_SaldoDisponivelItem             = new TmgClientDataSet(FormAtivo)
      Cl_DadosProgramadas                = new TmgClientDataSet(FormAtivo)
      Cl_ProgramacaoInsere               = new TmgClientDataSet(FormAtivo)
      Cl_FS_PedProgEntregaOco            = new TmgClientDataSet(FormAtivo)
      Cl_FS_PedProgEntrega               = new TmgClientDataSet(FormAtivo)
      Cl_Fs_PedidoVendaGer               = new TmgClientDataSet(FormAtivo)
      Cl_Fs_PedidoVenda                  = new TmgClientDataSet(FormAtivo)
      Cl_TipoOcorrencias                 = new TmgClientDataSet(FormAtivo)
      Cl_OrdemExpedicao                  = new TmgClientDataSet(FormAtivo)
      Cl_Permissoes                      = new TmgClientDataSet(FormAtivo)
      Cl_PedProgEntregaItem              = new TmgClientDataSet(FormAtivo)
      Cl_NotaFiscal                      = new TmgClientDataSet(FormAtivo)
      Cl_FS_PRC_PEDPROENTREGA            = new TmgClientDataSet(FormAtivo)
      Cl_FS_PRC_PEDPROENTREGADATA        = new TmgClientDataSet(FormAtivo)
      Cl_FS_PRC_PEDPROENTREGADATACLIENTE = new TmgClientDataSet(FormAtivo)
      Cl_FS_PRC_PEDPROGDATAEXP           = new TmgClientDataSet(FormAtivo)
      Cl_ExcluiOEPedido                  = new TmgClientDataSet(FormAtivo)
      Cl_FS_APT_APONTAORDEM              = new TmgClientDataSet(FormAtivo)
      Cl_Update_Cl_FS_APT_APONTAORDEM    = new TmgClientDataSet(FormAtivo)
      Cl_FS_RESERVAAUTO                  = new TmgClientDataSet(FormAtivo)
      Cl_FS_SEQ_RESERVAAUTO              = new TmgClientDataSet(FormAtivo)
      Cl_FS_RESERVAAUTO_Update           = new TmgClientDataSet(FormAtivo)

      Cl_Lk_Clientes            = new TmgClientDataSet(FormAtivo)
      Cl_Lk_Itens               = new TmgClientDataSet(FormAtivo)
      Cl_Lk_Grupos              = new TmgClientDataSet(FormAtivo)
      Cl_Lk_SubGrupos           = new TmgClientDataSet(FormAtivo)
      Cl_Lk_Representante       = new TmgClientDataSet(FormAtivo)
      Cl_Lk_TipoDoc             = new TmgClientDataSet(FormAtivo)

      '//Instancia os DataSources
      Ds_Lk_Cliente           = new TmgDataSource(FormAtivo)
      Ds_Lk_Itens             = new TmgDataSource(FormAtivo)
      Ds_Lk_Grupos            = new TmgDataSource(FormAtivo)
      Ds_Lk_SubGrupos         = new TmgDataSource(FormAtivo)
      Ds_OrdemExpedicao       = new TmgDataSource(FormAtivo)
      Ds_NotaFiscal           = new TmgDataSource(FormAtivo)
      Ds_Lk_Representante     = new TmgDataSource(FormAtivo)
      Ds_Lk_TipoDoc           = new TmgDataSource(FormAtivo)

      Tv_Dados          = Gd_Dados.CreateView
      Tv_Dados.Name     = "Tv_Dados"

      '// TcxGridDBTableView(Tv_Dados).PopupMenu.Items.Add(Mi_Separador)

      '// Pm_Acoes

      '// TcxGridDBTableView(Tv_Dados).PopupMenu = Pm_Acoes

      '// Pm_Acoes.Items.Add(Mi_Separador)
      '// Pm_Acoes.Items.Add(Mi_Clientes_Itens)

      '// Bt_Acoes.DropDownMenu = Pm_Acoes

      '// TcxGridDBTableView(Tv_Dados).PopupMenu.Itens.Insert(5, Mi_Separador)
      '// TcxGridDBTableView(Tv_Dados).PopupMenu.Insert(10, Mi_ProgCorte)


      '// = Pm_Acoes

      '// TcxGridDBTableView(Tv_Dados).PopupMenu = Pm_Acoes

      Tv_OrdemExpedicao = Gd_OrdemExpedicao.CreateView
      Tv_OrdemExpedicao.Name = "Tv_OrdemExpedicao"

      Tv_NotaFiscal = Gd_NotaFiscal.CreateView
      Tv_NotaFiscal.Name = "Tv_NotaFiscal"

      Cl_Dados.OnAfterOpen                  = AddressOf Cl_Dados_OnAfterOpen()
      Cl_Dados.OnBeforeOpen                 = AddressOf Cl_Dados_OnBeforeOpen()
      Cl_DadosResevaAutomatica.OnBeforeOpen = AddressOf Cl_DadosResevaAutomatica_OnBeforeOpen()

      Cl_Lk_Clientes.OnAfterOpen            = AddressOf Cl_Lk_Clientes_OnAfterOpen()
      Cl_Lk_Grupos.OnAfterOpen              = AddressOf Cl_Lk_Grupos_OnAfterOpen()
      Cl_Lk_Itens.OnAfterOpen               = AddressOf Cl_Lk_Itens_OnAfterOpen()
      Cl_Lk_SubGrupos.OnAfterOpen           = AddressOf Cl_Lk_SubGrupos_OnAfterOpen()

      Bt_ClassCliente.OnAfterClick          = AddressOf Bt_ClassCliente_OnAfterClick()
      Bt_ClassItens.OnAfterClick            = AddressOf Bt_ClassItem_OnAfterClick()
      Bt_ClassClientesItens.OnAfterClick    = AddressOf Bt_ClassClientesItens_OnAfterClick()
      Bt_Saldos.OnAfterClick                = AddressOf Bt_Saldos_OnAfterClick()
      Bt_Historico.OnAfterClick             = AddressOf Bt_Historico_OnAfterClick()
      Bt_Filtrar.OnAfterClick               = AddressOf Bt_Filtrar_OnAfterClick()
      Bt_Reserva.OnAfterClick               = AddressOf ReservaAutomatica()
      Bt_OcorrenciaFin.OnAfterClick         = AddressOf Bt_OcorrenciaFin_OnAfterClick()
      cBt_HistAltProgEntrega.OnAfterClick   = AddressOf cBt_HistAltProgEntrega_OnAfterClick()
      Bt_GerarOE.OnBeforeClick              = AddressOf Bt_GerarOE_OnBeforeClick()
      Bt_ExcluirOE.OnBeforeClick            = AddressOf Bt_ExcluirOE_OnBeforeClick()
      Bt_DistribuirReserva.OnBeforeClick    = AddressOf Bt_DistribuirReserva_OnAfterClick()
      Bt_SaldosGrupo.OnAfterClick           = AddressOf Bt_SaldosGrupo_OnAfterClick()
      Bt_AlteraEmbalagem.OnBeforeClick      = AddressOf Bt_AlteraEmbalagem_OnBeforeClick()
      Bt_ExcluirOePedido.OnAfterClick       = AddressOf Bt_ExcluirOePedido_OnAfterClick()
      Bt_Comissao.OnAfterClick              = AddressOf Bt_Comissao_OnAfterClick()
      Bt_LogCriacaoRomaneio.OnAfterClick    = AddressOf Bt_LogCriacaoRomaneio_OnAfterClick()

      '//cBt_LogLiberacao.OnAfterClick         = AddressOf cBt_LogLiberacao_OnAfterClick()  '// Matheus H. 25/02/2026

      Bt_ExcluirOE.Enabled = False
      Bt_GerarOE.Enabled   = False

      Cb_StatusPedido.ItemIndex = 0
      Gb_Status.Checked         = true


      With Cl_Permissoes
        Name      = "Cl_Permissoes"
        TableName = "DUAL"
        Close
        SQL.Clear
        SQL.Add("SELECT T.B2B_IN_NIVEL,                   ")
        SQL.Add("       T.B2C_IN_NIVEL,                   ")
        SQL.Add("       T.EXP_IN_NIVEL,                   ")
        SQL.Add("       T.OUT_IN_NIVEL                    ")
        SQL.Add("  FROM GLO_GRUPO_USUARIOCMPESP T         ")
        SQL.Add(" WHERE T.GRU_IN_CODIGO = :pUSU_IN_CODIGO ")
        ParamByName("pUSU_IN_CODIGO").Value = DMMega.Usuario
        Open
        vPermissaoB2B = FieldByName("B2B_IN_NIVEL").Value
        vPermissaoB2C = FieldByName("B2C_IN_NIVEL").Value
        vPermissaoExp = FieldByName("EXP_IN_NIVEL").Value
        vPermissaoOut = FieldByName("OUT_IN_NIVEL").Value
      End With

      With Cl_SaldoDisponivel
          Name = "Cl_SaldoDisponivel"
          TableName = "Dual"
          Close
          SQL.Add("SELECT FS_PCK_PEDIDOVENDA.F_SALDO_PEDIDO(:pORG_TAB_IN_CODIGO, ")
          SQL.Add("                                         :pORG_PAD_IN_CODIGO, ")
          SQL.Add("                                         :pORG_IN_CODIGO,     ")
          SQL.Add("                                         :pORG_TAU_ST_CODIGO, ")
          SQL.Add("                                         :pSER_ST_CODIGO,     ")
          SQL.Add("                                         :pPED_IN_CODIGO)  SALDO_DISPONIVEL ")
          SQL.Add("  FROM DUAL                                                                 ")
          OnBeforeOpen = AddressOf Cl_SaldoDisponivel_OnBeforeOpen()
      End With

      With Cl_SaldoDisponivelItem
          Name = "Cl_SaldoDisponivelItem"
          TableName = "Dual"
          Close
          SQL.Add(" SELECT FS_PCK_PEDIDOVENDA.F_SALDO_DISPONIVEL(:pORG_IN_CODIGO,           ")
          SQL.Add("                                              :pFIL_IN_CODIGO,           ")
          SQL.Add("                                              :pPRO_TAB_IN_CODIGO,       ")
          SQL.Add("                                              :pPRO_PAD_IN_CODIGO,       ")
          SQL.Add("                                              :pPRO_IN_CODIGO,")
          SQL.Add("                                              :PTPD_IN_CODIGO) DISPONIVEL")
          SQL.Add(" FROM DUAL                                                               ")
          OnBeforeOpen = AddressOf Cl_SaldoDisponivelItem_OnBeforeOpen()
      End With

      With Cl_IntegraOe
        Name      = "Cl_IntegraOe"
        TableName = "DUAL"
        SQL.Add("BEGIN                                                       ")
        SQL.Add(" FS_PCK_PEDIDOVENDA.FS_FNC_INTEGRAOE(:pORG_TAB_IN_CODIGO,   ")
        SQL.Add("                                     :pORG_PAD_IN_CODIGO,   ")
        SQL.Add("                                     :pORG_IN_CODIGO,       ")
        SQL.Add("                                     :pORG_TAU_ST_CODIGO,   ")
        SQL.Add("                                     :pFIL_IN_CODIGO,       ")
        SQL.Add("                                     :pSER_ST_CODIGO,       ")
        SQL.Add("                                     :pPED_IN_CODIGO,       ")
        SQL.Add("                                     :pITP_IN_SEQUENCIA,    ")
        SQL.Add("                                     :pIPE_IN_SEQUENCIA,    ")
        SQL.Add("                                     :pIPE_RE_QUANTIDADE,   ")
        SQL.Add("                                     :pEXP_DT_EMISSAO,      ")
        SQL.Add("                                     :pOPERACAO,            ")
        SQL.Add("                                     :pTRA_IN_CODIGO,       ")
        SQL.Add("                                     :pEXP_IN_CODIGO,       ")
        SQL.Add("                                     :pReservaAutomatica,   ")
        SQL.Add("                                     :pUSU_IN_CODIGO,       ")
        SQL.Add("                                     :pRES_IN_CODIGO,       ")
        SQL.Add("                                     :pSEQ_IN_CODIGO_RET,   ")
        SQL.Add("                                     :pEXP_IN_SEQUENCIA_RET,")
        SQL.Add("                                     :pEXP_IN_CODIGO_RET);  ")
        SQL.Add("END;                                                        ")
      End With

      With Cl_ProgramacaoInsere
        Name      = "Cl_ProgramacaoInsere"
        TableName = "DUAL"
        SQL.Add("BEGIN                                                                    ")
        SQL.Add("  FS_PCK_PEDIDOVENDA.FS_PRC_PEDPROGENTREGA_APPEND(:pORG_TAB_IN_CODIGO,   ")
        SQL.Add("                                                  :pORG_PAD_IN_CODIGO,   ")
        SQL.Add("                                                  :pORG_IN_CODIGO,       ")
        SQL.Add("                                                  :pORG_TAU_ST_CODIGO,   ")
        SQL.Add("                                                  :pSER_ST_CODIGO,       ")
        SQL.Add("                                                  :pPED_IN_CODIGO,       ")
        SQL.Add("                                                  :pITP_IN_SEQUENCIA,    ")
        SQL.Add("                                                  :pIPE_IN_SEQUENCIA,    ")
        SQL.Add("                                                  :pIPE_CH_STATUS,       ")
        SQL.Add("                                                  :pQUANTIDADE,          ")
        SQL.Add("                                                  :pSEQUENCIA,           ")
        SQL.Add("                                                  :pUSUARIO);            ")
        SQL.Add("END;                                                                     ")
      End With

      With Cl_TipoOcorrencias
        Name      = "Cl_TipoOcorrencias"
        TableName = "DUAL"
        Close
        SQL.Clear
        SQL.Add("SELECT *                        ")
        SQL.Add("  FROM FS_VW_TIPOOCORRENCIA A   ")
        SQL.Add("WHERE A.TIPO = :pTipoOcorrencia ")
      End With

      With Cl_Parametros
        Close
        SQL.Clear
        SQL.Add("SELECT CAST(NULL AS DATE)          ENTREGA_INICIAL,      ")
        SQL.Add("       CAST(NULL AS DATE)          ENTREGA_FINAL,        ")
        SQL.Add("       CAST(NULL AS DATE)          DATA_CLIENTE_INICIAL, ")
        SQL.Add("       CAST(NULL AS DATE)          DATA_CLIENTE_FINAL,   ")
        SQL.Add("       CAST(NULL AS DATE)          EMISSAO_INICIAL,      ")
        SQL.Add("       CAST(NULL AS DATE)          EMISSAO_FINAL,        ")
        SQL.Add("       CAST(NULL AS NUMBER)        PEDIDO_INICIAL,       ")
        SQL.Add("       CAST(NULL AS NUMBER)        PEDIDO_FINAL,         ")
        SQL.Add("       CAST(NULL AS NUMBER)        NOTA_INICIAL,         ")
        SQL.Add("       CAST(NULL AS NUMBER)        NOTA_FINAL,           ")
        SQL.Add("       CAST(NULL AS NUMBER(3))     AGN_TAB_IN_CODIGO,    ")
        SQL.Add("       CAST(NULL AS NUMBER(3))     AGN_PAD_IN_CODIGO,    ")
        SQL.Add("       CAST(NULL AS NUMBER(7))     AGN_IN_CODIGO,        ")
        SQL.Add("       CAST(NULL AS VARCHAR2(100)) AGN_ST_NOME,          ")
        SQL.Add("       CAST(NULL AS NUMBER(3))     TPD_TAB_IN_CODIGO,    ")
        SQL.Add("       CAST(NULL AS NUMBER(3))     TPD_PAD_IN_CODIGO,    ")
        SQL.Add("       CAST(NULL AS NUMBER(7))     TPD_IN_CODIGO,        ")
        SQL.Add("       CAST(NULL AS VARCHAR2(100)) TPD_ST_DESCRICAO,     ")
        SQL.Add("       CAST(NULL AS VARCHAR2(100)) ITP_ST_PEDIDOCLIENTE, ")
        SQL.Add("       'N'          B2B,                                 ")
        SQL.Add("       'N'          B2C,                                 ")
        SQL.Add("       'N'          EXPORTACAO,                          ")
        SQL.Add("       'N'          HIBRIDO   ,                          ")
        SQL.Add("       'N'          OUTROS    ,                          ")
        SQL.Add("       'N'          INDEFINIDO                           ")
        SQL.Add("  FROM DUAL                                              ")
        Open
      End With

      With Ds_Parametros
        Name    = "Ds_Parametros"
        DataSet = FormAtivo.Cl_Parametros
      End With

      With Ed_ITP_ST_PEDIDOCLIENTE
        DataField  = "ITP_ST_PEDIDOCLIENTE"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ed_EntregaInicial
        DataField  = "ENTREGA_INICIAL"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ed_EntregaFinal
        DataField  = "ENTREGA_FINAL"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ed_DataClienteInicial
        DataField  = "DATA_CLIENTE_INICIAL"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ed_DataClienteFinal
        DataField  = "DATA_CLIENTE_FINAL"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ed_EmissaoInicial
        DataField  = "EMISSAO_INICIAL"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ed_EmissaoFinal
        DataField  = "EMISSAO_FINAL"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ed_PedidoInicial
        DataField  = "PEDIDO_INICIAL"
        DataSource = FormAtivo.Ds_Parametros
        OnAfterExit = AddressOf Ed_PedidoInicial_OnExit
      End With

      With Ed_PedidoFinal
        DataField  = "PEDIDO_FINAL"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ck_B2B
        DataField  = "B2B"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ck_B2C
        DataField  = "B2C"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ck_EXPORTACAO
        DataField  = "EXPORTACAO"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ck_OUTROS
        DataField  = "OUTROS"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ck_HIBRIDO
        DataField  = "HIBRIDO"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ck_Indefinido
        DataField  = "INDEFINIDO"
        DataSource = FormAtivo.Ds_Parametros
      End With

      With Ed_NotaInicial
        DataField  = "NOTA_INICIAL"
        DataSource = FormAtivo.Ds_Parametros
        OnAfterExit = AddressOf Ed_NotaInicial_OnExit
      End With

      With Ed_NotaFinal
        DataField  = "NOTA_FINAL"
        DataSource = FormAtivo.Ds_Parametros
      End With

      '//Filtro de Representante
      With Cl_Lk_Representante
        Name            = "Cl_Lk_Representante"
        TableName       = "GLO_AGENTES"
        PkFields        = "AGN_TAB_IN_CODIGO;AGN_PAD_IN_CODIGO;AGN_IN_CODIGO"
        IndexFieldNames = "AGN_TAB_IN_CODIGO;AGN_PAD_IN_CODIGO;AGN_IN_CODIGO"
        SQL.Add("SELECT A.AGN_TAB_IN_CODIGO,                                    ")
        SQL.Add("       A.AGN_PAD_IN_CODIGO,                                    ")
        SQL.Add("       A.AGN_IN_CODIGO,                                        ")
        SQL.Add("       A.AGN_ST_NOME                                           ")
        SQL.Add("  FROM GLO_AGENTES A                                           ")
        SQL.Add(" WHERE EXISTS(SELECT 1                                         ")
        SQL.Add("                FROM GLO_AGENTES_ID B                          ")
        SQL.Add("               WHERE B.AGN_TAB_IN_CODIGO = A.AGN_TAB_IN_CODIGO ")
        SQL.Add("                 AND B.AGN_PAD_IN_CODIGO = A.AGN_PAD_IN_CODIGO ")
        SQL.Add("                 AND B.AGN_IN_CODIGO     = A.AGN_IN_CODIGO     ")
        SQL.Add("                 AND B.AGN_TAU_ST_CODIGO = 'R')                ")
        OnAfterOpen = AddressOf Cl_Lk_Representante_OnAfterOpen()
      End With

      With Ds_Lk_Representante
        Name    = "Ds_Lk_Representante"
        DataSet = Cl_Lk_Representante
      End With

      With Lk_Representante
        Name = "Lk_Representante"
        LookupSource = Ds_Lk_Representante
      End With

      With Ed_REP_IN_CODIGO
        Name         = "Ed_REP_IN_CODIGO"
        DisplayField = "AGN_IN_CODIGO"
        LookupFields = "AGN_TAB_IN_CODIGO;AGN_PAD_IN_CODIGO;AGN_IN_CODIGO;AGN_ST_NOME"
        DataFields   = "AGN_TAB_IN_CODIGO;AGN_PAD_IN_CODIGO;AGN_IN_CODIGO;AGN_ST_NOME"
        Lookup       = Lk_Representante
        DataSource   = Ds_Parametros
      End With

      With Ed_REP_ST_NOME
        Name         = "Ed_REP_ST_NOME"
        DataField    = "AGN_ST_NOME"
        DataSource   = Ds_Parametros
        Enabled      = false
        ReadOnly     = true
        ParentFont   = false
      End With

      '//Filtro de Tipo de Documento
      With Cl_Lk_TipoDoc
        Name            = "Cl_Lk_TipoDoc"
        TableName       = "VEN_TIPODOCUMENTO"
        PkFields        = "TPD_TAB_IN_CODIGO;TPD_PAD_IN_CODIGO;TPD_IN_CODIGO"
        IndexFieldNames = "TPD_TAB_IN_CODIGO;TPD_PAD_IN_CODIGO;TPD_IN_CODIGO"
        SQL.Add("SELECT T.TPD_TAB_IN_CODIGO,")
        SQL.Add("       T.TPD_PAD_IN_CODIGO,")
        SQL.Add("       T.TPD_IN_CODIGO,")
        SQL.Add("       T.TPD_SER_ST_CODIGO,")
        SQL.Add("       T.TPD_ST_DESCRICAO")
        SQL.Add("  FROM VEN_TIPODOCUMENTO T")
        SQL.Add(" WHERE T.TPD_CH_TIPODOCUMENTO = 'P'")
        SQL.Add("ORDER BY T.TPD_IN_CODIGO")
        '//OnAfterOpen = AddressOf Cl_Lk_TipoDoc_OnAfterOpen()
      End With

      With Ds_Lk_TipoDoc
        Name    = "Ds_Lk_TipoDoc"
        DataSet = Cl_Lk_TipoDoc
      End With

      With Lk_TipoDoc
        Name = "Lk_TipoDoc"
        LookupSource = Ds_Lk_TipoDoc
      End With

      With Ed_TipoDoc
        DisplayField = "TPD_IN_CODIGO"
        LookupFields = "TPD_TAB_IN_CODIGO;TPD_PAD_IN_CODIGO;TPD_IN_CODIGO;TPD_ST_DESCRICAO"
        DataFields   = "TPD_TAB_IN_CODIGO;TPD_PAD_IN_CODIGO;TPD_IN_CODIGO;TPD_ST_DESCRICAO"
        Lookup       = Lk_TipoDoc
        DataSource   = Ds_Parametros
      End With

      With Ed_TipoDocDesc
        DataField    = "TPD_ST_DESCRICAO"
        DataSource   = Ds_Parametros
        Enabled      = false
        ReadOnly     = true
        ParentFont   = false
      End With

      '//Cliente -----------------------
      With Cl_Lk_Clientes
        Name = "Cl_Lk_Clientes"
        TableName = "GLO_AGENTES"
        SQL.Clear
        SQL.Add("SELECT AGN_IN_CODIGO,AGN_ST_NOME                                ")
        SQL.Add("  FROM GLO_AGENTES B                                            ")
        SQL.Add(" WHERE EXISTS(SELECT A.AGN_IN_CODIGO                            ")
        SQL.Add("                FROM GLO_AGENTES_ID A                           ")
        SQL.Add("               WHERE A.AGN_TAB_IN_CODIGO = B.AGN_TAB_IN_CODIGO  ")
        SQL.Add("                 AND A.AGN_PAD_IN_CODIGO = B.AGN_PAD_IN_CODIGO  ")
        SQL.Add("                 AND A.AGN_IN_CODIGO     = B.AGN_IN_CODIGO      ")
        SQL.Add("                 AND A.AGN_TAU_ST_CODIGO = 'C')                 ")
        SQL.Add("ORDER BY B.AGN_IN_CODIGO                                        ")
      End With

      With Ds_Lk_Cliente
        Name    = "Ds_Lk_ClienteInicial"
        DataSet = Cl_Lk_Clientes
      End With

      With Lk_Cliente
        Name = "Lk_ClienteInicial"
        LookupSource = Ds_Lk_Cliente
      End With

      With Ed_ClienteInicial
        Name         = "Ed_ClienteInicial"
        DisplayField = "AGN_IN_CODIGO"
        LookupFields = "AGN_IN_CODIGO"
        Lookup       = Lk_Cliente
        OnAfterExit  = AddressOf Ed_ClienteInicial_OnAfterExit
      End With

      With Ed_ClienteFinal
        Name         = "Ed_ClienteFinal"
        DisplayField = "AGN_IN_CODIGO"
        LookupFields = "AGN_IN_CODIGO"
        Lookup       = Lk_Cliente
      End With

      With Cl_Lk_Grupos
        Name            = "Cl_Lk_Grupos"
        TableName       = "EST_GRUPOS"
        SQL.Clear
        SQL.Add("SELECT * ")
        SQL.Add("  FROM EST_GRUPOS")
        SQL.Add(" WHERE GRU_IN_CODIGO IN(SELECT GRU_IN_CODIGO FROM FS_VW_EST_GRUPOS)")
      End With

      With Ds_Lk_Grupos
        Name    = "Ds_Lk_Grupos"
        DataSet = Cl_Lk_Grupos
      End With

      With Lk_Grupos
        Name         = "Lk_Grupos"
        LookupSource = Ds_Lk_Grupos
      End With

      With Ed_GruposInicial
        Name         = "Ed_GruposInicial"
        DisplayField = "GRU_IN_CODIGO"
        LookupFields = "GRU_IN_CODIGO"
        Lookup       = Lk_Grupos
        OnAfterExit  = AddressOf Ed_GruposInicial_OnAfterExit
      End With

      With Ed_GruposFinal
        Name         = "Ed_GruposFinal"
        DisplayField = "GRU_IN_CODIGO"
        LookupFields = "GRU_IN_CODIGO"
        Lookup       = Lk_Grupos
      End With

      '//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 2 - Início
      cCl_GrupoCliente = new TmgClientDataSet(FormAtivo)
      With cCl_GrupoCliente
        OnAfterOpen = AddressOf cCl_GrupoCliente_OnAfterOpen()
        Name        = "cCl_GrupoCliente"
        TableName   = "FS_TB_CLASSIFICADORES"
        SQL.Clear
        SQL.Add("SELECT FCC_IN_CODIGO")
        SQL.Add(",FCC_ST_ALTERNATIVO")
        SQL.Add(",FCC_ST_DESCRICAO")
        SQL.Add("FROM FS_TB_CLASSIFICADORES")
        SQL.Add("WHERE FTT_IN_CODIGO = 2")
        SQL.Add("AND FTC_IN_CODIGO = 6")
      End With

      cDs_GrupoCliente = new TmgDataSource(FormAtivo)
      With cDs_GrupoCliente
        Name    = "cDs_GrupoCliente"
        DataSet = cCl_GrupoCliente
      End With

      cLk_GrupoCliente = new TMgCLookup(FormAtivo)
      With cLk_GrupoCliente
        Name         = "cLk_GrupoCliente"
        LookupSource = cDs_GrupoCliente
      End With

      With Ed_GrupoClienteInicial
        Name         = "Ed_GrupoClienteInicial"
        DisplayField = "FCC_IN_CODIGO"
        LookupFields = "FCC_IN_CODIGO"
        Lookup       = cLk_GrupoCliente
        OnAfterExit  = AddressOf Ed_GrupoClienteInicial_OnAfterExit
      End With

      With Ed_GrupoClienteFinal
        Name         = "Ed_GrupoClienteFinal"
        DisplayField = "FCC_IN_CODIGO"
        LookupFields = "FCC_IN_CODIGO"
        Lookup       = cLk_GrupoCliente
      End With
      '//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 2 - Fim

      '//--------------------------------------//
      With Cl_Lk_SubGrupos
        Name            = "Cl_Lk_SubGrupos"
        TableName       = "EST_GRUPOS"
        SQL.Clear
        SQL.Add("SELECT *                                                                                            ")
        SQL.Add("  FROM EST_GRUPOS                                                                                   ")
        SQL.Add("  WHERE GRU_IN_CODIGO IN(SELECT GRU_IN_CODIGO                                                       ")
        SQL.Add("                           FROM FS_VW_EST_SUBGRUPOS                                                 ")
        SQL.Add("                          WHERE GRUPO BETWEEN NVL(:pGRUPO_INICIAL,0) AND NVL(:pGRUPO_FINAL,999999)) ")
        SQL.Add("ORDER BY GRU_IN_CODIGO                                                                              ")
        OnBeforeOpen = AddressOf Cl_Lk_SubGrupos_OnBeforeOpen()
      End With

      With Ds_Lk_SubGrupos
        Name    = "Ds_Lk_SubGrupos"
        DataSet = Cl_Lk_SubGrupos
      End With

      With Lk_SubGrupos
        Name         = "Lk_SubGrupos"
        LookupSource = Ds_Lk_SubGrupos
      End With

      With Ed_SubGruposInicial
        Name         = "Ed_SubGruposInicial"
        DisplayField = "GRU_IN_CODIGO"
        LookupFields = "GRU_IN_CODIGO"
        Lookup       = Lk_SubGrupos
        OnAfterExit  = AddressOf Ed_SubGruposInicial_OnAfterExit
      End With

      With Ed_SubGruposFinal
        Name         = "Ed_SubGruposFinal"
        DisplayField = "GRU_IN_CODIGO"
        LookupFields = "GRU_IN_CODIGO"
        Lookup       = Lk_SubGrupos
      End With
      '//--------------------------------------//

      With Cl_Lk_Itens
        Name = "Cl_Lk_Itens"
        TableName = "EST_PRODUTOS"
        SQL.Clear
        SQL.Add("  SELECT *                                                                                ")
        SQL.Add("    FROM EST_PRODUTOS                                                                     ")
        SQL.Add("   WHERE GRU_IDE_ST_CODIGO IN('03','04','05')                                             ")
        SQL.Add("     AND GRU_IN_CODIGO BETWEEN NVL(:pSUBGRUPO_INICIAL,0) AND NVL(:pSUBGRUPO_FINAL,999999) ")
        SQL.Add("ORDER BY PRO_IN_CODIGO,PRO_ST_ALTERNATIVO,PRO_ST_DESCRICAO                                ")
        OnBeforeOpen = AddressOf Cl_Lk_Itens_OnBeforeOpen()
      End With

      With Ds_Lk_Itens
        Name    = "Ds_Lk_Itens"
        DataSet = Cl_Lk_Itens
      End With

      With Lk_Itens
        Name         = "Lk_Itens"
        LookupSource = Ds_Lk_Itens
      End With

      With Ed_CodItemInicial
        Name         = "Ed_CodItemInicial"
        DisplayField = "PRO_IN_CODIGO"
        LookupFields = "PRO_IN_CODIGO"
        Lookup       = Lk_Itens
        OnAfterExit  = AddressOf Ed_CodItemInicial_OnAfterExit
      End With

      With Ed_CodItemFinal
        Name         = "Ed_CodItemFinal"
        DisplayField = "PRO_IN_CODIGO"
        LookupFields = "PRO_IN_CODIGO"
        Lookup       = Lk_Itens
      End With

       With Cl_Usuario
        Name      = "Cl_Usuario"
        TableName = "GLO_GRUPO_USUARIO"
        SQL.Add("SELECT  GRU_ST_NOME                     ")
        SQL.Add("  FROM  GLO_GRUPO_USUARIO               ")
        SQL.Add(" WHERE  GRU_IN_CODIGO = :pGRU_IN_CODIGO ")
        ParamByName("pGRU_IN_CODIGO").Value = DMMega.Usuario
        Open
      End With

      With Pn_Usuario
        Name    = "Pn_Usuario"
        Parent  = FormAtivo.PageControl1.Parent
        Align   = AlTop
        Height  = 27
        Caption = ""
      End With

      With Lb_Usuario
        Name            = "Lb_Usuario"
        Caption         = "Usuário Logado: " & IntToStr(Dmmega.Usuario) & " - " & Trim(Cl_Usuario.FieldByName("GRU_ST_NOME").Value)
        Parent          = Pn_Usuario
        Visible         = True
        Align           = AlClient
        Alignment       = taLeftJustify
        Font.Size       = 16
        Font.Style      = fsBold
        Font.Color      = 32768
      End With

      vCl_DadosExecutaScroll = false
      '//INICIO SQL
      With Cl_Dados
        Name = "Cl_Dados"
        TableName = "DUAL"
        SQL.Clear

        Sql.Add(" select T.*,")
        Sql.Add("         /* Tag_usuario " + vTag_User +"*/")
        Sql.Add("        'N' CONFIRMAR,")
        Sql.Add("        (T.IPE_RE_QTDECONVERTIDA - T.GER_RE_QUANTIDADE) IPE_RE_SALDO,")
        Sql.Add("        ((T.IPE_RE_QTDECONVERTIDA - T.GER_RE_QUANTIDADE) *")
        Sql.Add("        ITP_RE_VALORUNITARIOCONV) IPE_RE_SALDOMERCADORIA,")
        Sql.Add("        (T.GER_RE_QUANTIDADE - T.IPE_RE_QTDEFATURADA) IPE_RE_QTDERESFAT,")

        Sql.Add("(T.ITP_RE_VALORUNITARIOCONV * ")
        Sql.Add("(T.GER_RE_QUANTIDADE - T.IPE_RE_QTDEFATURADA)) VALOR_RESERVADO_A_FATURAR,")'// Matheus H. - Inclusão coluna em grid principal. | 22/04/2026

        Sql.Add("        NVL(CUS_PCK_DADOSESTITEM.F_SALDO_GERAL_OE(T.ORG_IN_CODIGO,")
        Sql.Add("                                                  T.FIL_IN_CODIGO,")
        Sql.Add("                                                  T.PRO_PAD_IN_CODIGO,")
        Sql.Add("                                                  T.PRO_IN_CODIGO),")
        Sql.Add("            0) SALDO_ALM_DISP")
        Sql.Add("   from (select DADOS.ORG_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.ORG_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.ORG_IN_CODIGO,")
        Sql.Add("                 DADOS.ORG_TAU_ST_CODIGO,")
        Sql.Add("                 DADOS.SER_ST_CODIGO,")
        Sql.Add("                 DADOS.PED_IN_CODIGO,")
        Sql.Add("                 DADOS.FIL_IN_CODIGO,")
        Sql.Add("                 DADOS.TPD_IN_CODIGO,")
        Sql.Add("                 DADOS.TPD_ST_DESCRICAO,")
        Sql.Add("                 DADOS.PED_CH_STATUS,")
        Sql.Add("                 DADOS.PED_DT_EMISSAO,")
        Sql.Add("                 DADOS.CLI_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.CLI_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.CLI_IN_CODIGO,")
        Sql.Add("                 DADOS.CLI_TAU_ST_CODIGO,")
        Sql.Add("                 DADOS.CLI_ST_NOME,")
        Sql.Add("                 DADOS.UF_ST_SIGLA,")
        Sql.Add("                 DADOS.MUN_IN_CODIGO,")
        Sql.Add("                 DADOS.MUN_ST_NOME,")
        Sql.Add("                 DADOS.COND_ST_CODIGO,")
        Sql.Add("                 DADOS.COND_ST_NOME,")
        Sql.Add("                 DADOS.TRA_IN_CODIGO,")
        Sql.Add("                 DADOS.TRA_ST_NOME,")
        Sql.Add("                 DADOS.PRO_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.PRO_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.PRO_IN_CODIGO,")
        Sql.Add("                 DADOS.GRU_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.GRU_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.GRU_IDE_ST_CODIGO,")
        Sql.Add("                 DADOS.GRU_IN_CODIGO,")
        Sql.Add("                 DADOS.SUB_GRUPO,")
        Sql.Add("                 DADOS.PRO_ST_ALTERNATIVO,")
        Sql.Add("                 DADOS.PRO_ST_DESCRICAO,")
        Sql.Add("                 DADOS.UNI_ST_ORIGINAL UNI_ST_UNIDADE,")

        Sql.Add("                 FS_FNC_CONVERTE_M2_PC(DADOS.PRO_TAB_IN_CODIGO,")
        Sql.Add("                                       DADOS.PRO_PAD_IN_CODIGO,")
        Sql.Add("                                       DADOS.PRO_IN_CODIGO,")
        Sql.Add("                                       DADOS.UNI_ST_ORIGINAL,")
        Sql.Add("                                       DADOS.UNI_ST_UNIDADE,")
        Sql.Add("                                       DADOS.ITP_RE_QUANTIDADE) ITP_RE_QUANTIDADE,")


        Sql.Add("                 DADOS.ITP_IN_SEQUENCIA,")
        Sql.Add("                 DADOS.IPE_IN_SEQUENCIA,")
        Sql.Add("                 DADOS.IPE_RE_QUANTIDADE,")
        Sql.Add("                 DADOS.IPE_DT_DATAENTREGA,")
        Sql.Add("                 ")
        Sql.Add("                 FS_FNC_CONVERTE_M2_PC(DADOS.PRO_TAB_IN_CODIGO,")
        Sql.Add("                                       DADOS.PRO_PAD_IN_CODIGO,")
        Sql.Add("                                       DADOS.PRO_IN_CODIGO,")
        Sql.Add("                                       DADOS.UNI_ST_ORIGINAL,")
        Sql.Add("                                       DADOS.UNI_ST_UNIDADE,")
        Sql.Add("                                       DADOS.GER_RE_QUANTIDADE) GER_RE_QUANTIDADE,")
        Sql.Add("                 ")
        Sql.Add("                 FS_FNC_CONVERTE_M2_PC(DADOS.PRO_TAB_IN_CODIGO,")
        Sql.Add("                                       DADOS.PRO_PAD_IN_CODIGO,")
        Sql.Add("                                       DADOS.PRO_IN_CODIGO,")
        Sql.Add("                                       DADOS.UNI_ST_ORIGINAL,")
        Sql.Add("                                       DADOS.UNI_ST_UNIDADE,")
        Sql.Add("                                       DADOS.GER_RE_QTDEDISPONIVEL) GER_RE_QTDEDISPONIVEL,")
        Sql.Add("                 ")
        Sql.Add("                 -- DADOS.GER_RE_QUANTIDADE,                      ")
        Sql.Add("                 --  DADOS.GER_RE_QTDEDISPONIVEL,")
        Sql.Add("                 DADOS.PED_IN_FRETEPCONTA,")
        Sql.Add("                 DADOS.VEN_AGN_ST_NOME,")
        Sql.Add("                 DADOS.VEN_AGN_IN_CODIGO,")
        Sql.Add("                 DADOS.USU_IN_CODIGO,")
        Sql.Add("                 DADOS.IPE_CH_STATUS,")
        Sql.Add("                 DADOS.PED_BO_PARCIAL,")
        Sql.Add("                 DADOS.PED_IN_PRIORIDADE,")
        Sql.Add("                 DADOS.GRUPO,")
        Sql.Add("                 DADOS.B2B,")
        Sql.Add("                 DADOS.B2C,")
        Sql.Add("                 DADOS.EXPORTACAO,")
        Sql.Add("                 DADOS.OUTROS,")
        Sql.Add("                 DADOS.HIBRIDO,")
        Sql.Add("                 DADOS.INDEFINIDO,")
        Sql.Add("                 DADOS.PED_CH_SITUACAO,")
        Sql.Add("                 DADOS.PED_ST_SITUACAO,")
        Sql.Add("                 DADOS.PRIORIDADE,")
        Sql.Add("                 DADOS.IPE_ST_STATUS,")
        Sql.Add("                 DADOS.PED_ST_TIPOFRETE,")
        Sql.Add("                 DADOS.B2B_IN_NIVEL,")
        Sql.Add("                 DADOS.B2C_IN_NIVEL,")
        Sql.Add("                 DADOS.EXP_IN_NIVEL,")
        Sql.Add("                 DADOS.OUT_IN_NIVEL,")
        Sql.Add("                 DADOS.EMB_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_UNI_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_UNI_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_UNI_ST_UNIDADE,")
        Sql.Add("                 DADOS.EMB_ST_DESCRICAO,")
        Sql.Add("                 DADOS.NCM_ST_EXTENSO,")
        Sql.Add("                 DADOS.DATA_CLIENTE,")
        Sql.Add("                 DADOS.PEDIDO_INDISPONIVEL,")
        Sql.Add("                 DADOS.IPE_CH_SITUACAO,")
        Sql.Add("                 DADOS.MINIMO_3PC,")
        Sql.Add("                 DADOS.IPE_ST_TIPOENTREGA,")
        Sql.Add("                 DADOS.ITP_RE_VALORUNITARIO,")
        Sql.Add("                 DADOS.IPE_RE_QTDECONVERTIDA,")
        Sql.Add("                 DADOS.IPE_RE_QTDEFATURADA,")
        Sql.Add("                 DADOS.ITP_RE_VALORUNITARIOCONV,")
        Sql.Add("                 --  DADOS.IPE_RE_QTDESALDO,")
        Sql.Add("                 ")
        Sql.Add("                 FS_FNC_CONVERTE_M2_PC(DADOS.PRO_TAB_IN_CODIGO,")
        Sql.Add("                                       DADOS.PRO_PAD_IN_CODIGO,")
        Sql.Add("                                       DADOS.PRO_IN_CODIGO,")
        Sql.Add("                                       DADOS.UNI_ST_ORIGINAL,")
        Sql.Add("                                       DADOS.UNI_ST_UNIDADE,")
        Sql.Add("                                       DADOS.IPE_RE_QTDESALDO) IPE_RE_QTDESALDO,")
        Sql.Add("                 ")
        Sql.Add("                 DADOS.IPE_DT_DATAEXPEDICAO,")
        Sql.Add("                 DECODE(DADOS.B2B,")
        Sql.Add("                        'S',")
        Sql.Add("                        'B2B',")
        Sql.Add("                        DECODE(DADOS.B2C,")
        Sql.Add("                               'S',")
        Sql.Add("                               'B2C',")
        Sql.Add("                               DECODE(DADOS.EXPORTACAO,")
        Sql.Add("                                      'S',")
        Sql.Add("                                      'EXPORTACAO',")
        Sql.Add("                                      DECODE(DADOS.OUTROS,")
        Sql.Add("                                             'S',")
        Sql.Add("                                             'OUTROS',")
        Sql.Add("                                             DECODE(DADOS.HIBRIDO,")
        Sql.Add("                                                    'S',")
        Sql.Add("                                                    'HIBRIDO',")
        Sql.Add("                                                    DECODE(DADOS.INDEFINIDO,")
        Sql.Add("                                                           'S',")
        Sql.Add("                                                           'INDEFINIDO')))))) MERCADO,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when ((DADOS.PED_BO_PARCIAL in ('N') or")
        Sql.Add("                        DADOS.EXPORTACAO = 'S') and")
        Sql.Add("                        (IPE_RE_QUANTIDADE <> ITP_RE_QUANTIDADE)) then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.PED_CH_STATUS not in ('A', 'P', 'B') then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.IPE_CH_STATUS in ('B') then")
        Sql.Add("                    'S'")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end BLO_CH_GEROE,")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.IPE_CH_SITUACAO = 'B' then")
        Sql.Add("                    'S'")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end BLO_CH_EDICAO,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.B2B = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 2, 'S', 'N')")
        Sql.Add("                   when DADOS.B2C = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 2, 'S', 'N')")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 2, 'S', 'N')")
        Sql.Add("                   when DADOS.OUTROS = 'S' then")
        Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 2, 'S', 'N')")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end NIV_CH_GERENCIA,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.B2B = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 3, 'S', 'N')")
        Sql.Add("                   when DADOS.B2C = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 3, 'S', 'N')")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 3, 'S', 'N')")
        Sql.Add("                   when DADOS.OUTROS = 'S' then")
        Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 3, 'S', 'N')")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end NIV_CH_REDISTRIBUI,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.B2B = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 1, 'S', 'N')")
        Sql.Add("                   when DADOS.B2C = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 1, 'S', 'N')")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 1, 'S', 'N')")
        Sql.Add("                   when DADOS.OUTROS = 'S' then")
        Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 1, 'S', 'N')")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end NIV_CH_VISUALIZA,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.B2B = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 0, 'S', 'N')")
        Sql.Add("                   when DADOS.B2C = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 0, 'S', 'N')")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 0, 'S', 'N')")
        Sql.Add("                   when DADOS.OUTROS = 'S' then")
        Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 0, 'S', 'N')")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end NIV_CH_NENHUM,")
        Sql.Add("                 case")
        Sql.Add("                   when (select count(B.EXP_IN_CODIGO) EXP_IN_CODIGO")
        Sql.Add("                           from VEN_PEDIDOVENDA A")
        Sql.Add("                           join VEN_EXPEDICAO B")
        Sql.Add("                             on B.ORG_TAB_IN_CODIGO = A.ORG_TAB_IN_CODIGO")
        Sql.Add("                            and B.ORG_PAD_IN_CODIGO = A.ORG_PAD_IN_CODIGO")
        Sql.Add("                            and B.ORG_IN_CODIGO = A.ORG_IN_CODIGO")
        Sql.Add("                            and B.ORG_TAU_ST_CODIGO = A.ORG_TAU_ST_CODIGO")
        Sql.Add("                            and B.SER_ST_CODIGO = A.SER_ST_CODIGO")
        Sql.Add("                            and B.PED_IN_CODIGO = A.PED_IN_CODIGO")
        Sql.Add("                          where A.ORG_TAB_IN_CODIGO = DADOS.ORG_TAB_IN_CODIGO")
        Sql.Add("                            and A.ORG_PAD_IN_CODIGO = DADOS.ORG_PAD_IN_CODIGO")
        Sql.Add("                            and A.ORG_IN_CODIGO = DADOS.ORG_IN_CODIGO")
        Sql.Add("                            and A.ORG_TAU_ST_CODIGO = DADOS.ORG_TAU_ST_CODIGO")
        Sql.Add("                            and A.SER_ST_CODIGO = DADOS.SER_ST_CODIGO")
        Sql.Add("                            and A.PED_IN_CODIGO = DADOS.PED_IN_CODIGO) > 0 then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.PED_CH_STATUS not in ('A', 'P', 'B') then")
        Sql.Add("                    'S'")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end BLO_CH_PARCIAL,")
        Sql.Add("                 DADOS.ITP_ST_PEDIDOCLIENTE,")
        Sql.Add("                 case")
        Sql.Add("                   when ((DADOS.PED_BO_PARCIAL in ('N') or")
        Sql.Add("                        DADOS.EXPORTACAO = 'S') and")
        Sql.Add("                        (IPE_RE_QUANTIDADE <> ITP_RE_QUANTIDADE)) then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.PED_CH_STATUS not in ('A', 'P', 'B') then")
        Sql.Add("                    'S'")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end BLO_CH_STATUSOE,")
        Sql.Add("                 CASE")
        Sql.Add("                   WHEN DADOS.GER_RE_QUANTIDADE > 0 AND (DADOS.IPE_RE_QTDECONVERTIDA - DADOS.GER_RE_QUANTIDADE) > 0 THEN")
        Sql.Add("                     0")
        Sql.Add("                   ELSE")
        Sql.Add("                     1")
        Sql.Add("                 END ORDEM_OE_INICIADA,")
        Sql.Add("                 DADOS.CTD_CH_DATA_HORIZONTE,")
        Sql.Add("                 CASE")
        Sql.Add("                   WHEN DADOS.CTD_CH_DATA_HORIZONTE = 'S' THEN")
        Sql.Add("                     TRUNC(sysdate +")
        Sql.Add("                           FS_PCK_APT_NEW.FNC_OBTEM_DIAS_HORIZONTE(PCK_MEGA.ACHAPADRAODATABELA(FIL       => DADOS.FIL_IN_CODIGO,")
        Sql.Add("                                                                                               TAB       => 100,")
        Sql.Add("                                                                                               DATAATUAL => sysdate),")
        Sql.Add("                                                                                               DADOS.PRO_IN_CODIGO))")
        Sql.Add("                   ELSE")
        Sql.Add("                     NULL")
        Sql.Add("                 END DATA_HORIZONTE")
        Sql.Add("         ")
        Sql.Add("           from (select PED.ORG_TAB_IN_CODIGO ORG_TAB_IN_CODIGO,")
        Sql.Add("                         PED.ORG_PAD_IN_CODIGO ORG_PAD_IN_CODIGO,")
        Sql.Add("                         PED.ORG_IN_CODIGO ORG_IN_CODIGO,")
        Sql.Add("                         PED.ORG_TAU_ST_CODIGO ORG_TAU_ST_CODIGO,")
        Sql.Add("                         PED.SER_ST_CODIGO SER_ST_CODIGO,")
        Sql.Add("                         PED.PED_IN_CODIGO PED_IN_CODIGO,")
        Sql.Add("                         PED.FIL_IN_CODIGO FIL_IN_CODIGO,")
        Sql.Add("                         TPD.TPD_IN_CODIGO TPD_IN_CODIGO,")
        Sql.Add("                         TPD.TPD_ST_DESCRICAO TPD_ST_DESCRICAO,")
        Sql.Add("                         ITE.ITP_ST_SITUACAO PED_CH_STATUS,")
        Sql.Add("                         PED.PED_DT_EMISSAO PED_DT_EMISSAO,")
        Sql.Add("                         PED.CLI_TAB_IN_CODIGO CLI_TAB_IN_CODIGO,")
        Sql.Add("                         PED.CLI_PAD_IN_CODIGO CLI_PAD_IN_CODIGO,")
        Sql.Add("                         PED.CLI_IN_CODIGO CLI_IN_CODIGO,")
        Sql.Add("                         PED.CLI_TAU_ST_CODIGO CLI_TAU_ST_CODIGO,")
        Sql.Add("                         CLI.AGN_ST_NOME CLI_ST_NOME,")
        Sql.Add("                         MUN.UF_ST_SIGLA UF_ST_SIGLA,")
        Sql.Add("                         MUN.MUN_IN_CODIGO MUN_IN_CODIGO,")
        Sql.Add("                         MUN.MUN_ST_NOME MUN_ST_NOME,")
        Sql.Add("                         PED.COND_ST_CODIGO COND_ST_CODIGO,")
        Sql.Add("                         CON.COND_ST_NOME COND_ST_NOME,")
        Sql.Add("                         TRA.AGN_IN_CODIGO TRA_IN_CODIGO,")
        Sql.Add("                         TRA.AGN_ST_NOME TRA_ST_NOME,")
        Sql.Add("                         PRO.PRO_TAB_IN_CODIGO PRO_TAB_IN_CODIGO,")
        Sql.Add("                         PRO.PRO_PAD_IN_CODIGO PRO_PAD_IN_CODIGO,")
        Sql.Add("                         PRO.PRO_IN_CODIGO PRO_IN_CODIGO,")
        Sql.Add("                         PRO.GRU_TAB_IN_CODIGO GRU_TAB_IN_CODIGO,")
        Sql.Add("                         PRO.GRU_PAD_IN_CODIGO GRU_PAD_IN_CODIGO,")
        Sql.Add("                         PRO.GRU_IDE_ST_CODIGO GRU_IDE_ST_CODIGO,")
        Sql.Add("                         PRO.GRU_IN_CODIGO GRU_IN_CODIGO,")
        Sql.Add("                         PRO.GRU_IN_CODIGO SUB_GRUPO,")
        Sql.Add("                         PRO.PRO_ST_ALTERNATIVO PRO_ST_ALTERNATIVO,")
        Sql.Add("                         PRO.PRO_ST_DESCRICAO PRO_ST_DESCRICAO,")
        Sql.Add("                         ITE.UNI_ST_UNIDADE UNI_ST_UNIDADE,")
        Sql.Add("                         ITE.ITP_RE_QUANTIDADE ITP_RE_QUANTIDADE,")
        Sql.Add("                         ITE.ITP_IN_SEQUENCIA ITP_IN_SEQUENCIA,")
        Sql.Add("                         ITE.ITP_ST_PEDIDOCLIENTE,")
        Sql.Add("                         PRG.IPE_IN_SEQUENCIA IPE_IN_SEQUENCIA,")
        Sql.Add("                         PRG.IPE_RE_QUANTIDADE IPE_RE_QUANTIDADE,")
        Sql.Add("                         PRG.IPE_DT_DATAENTREGA IPE_DT_DATAENTREGA,")
        Sql.Add("                         PRG.IPE_DT_DATAEXPEDICAO IPE_DT_DATAEXPEDICAO,")
        Sql.Add("                         NVL((select sum(NVL(EXP.EXP_RE_QTDEFATURAR, 0))")
        Sql.Add("                               from VEN_EXPEDICAO EXP")
        Sql.Add("                              where EXP.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
        Sql.Add("                                and EXP.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
        Sql.Add("                                and EXP.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
        Sql.Add("                                and EXP.ORG_TAU_ST_CODIGO = PED.ORG_TAU_ST_CODIGO")
        Sql.Add("                                and EXP.SER_ST_CODIGO = PED.SER_ST_CODIGO")
        Sql.Add("                                and EXP.PED_IN_CODIGO = PED.PED_IN_CODIGO")
        Sql.Add("                                and EXP.ITP_IN_SEQUENCIA = ITE.ITP_IN_SEQUENCIA")
        Sql.Add("                                and EXP.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA),")
        Sql.Add("                             0) GER_RE_QUANTIDADE,")
        Sql.Add("                         NVL((select sum(NVL(EXP1.EXP_RE_QTDEFATURAR, 0))")
        Sql.Add("                               from VEN_EXPEDICAO EXP1")
        Sql.Add("                               left join FS_ROMANEIO_OE_ITENS RIT")
        Sql.Add("                                 on RIT.ORG_TAB_IN_CODIGO = EXP1.ORG_TAB_IN_CODIGO")
        Sql.Add("                                and RIT.ORG_PAD_IN_CODIGO = EXP1.ORG_PAD_IN_CODIGO")
        Sql.Add("                                and RIT.ORG_IN_CODIGO = EXP1.ORG_IN_CODIGO")
        Sql.Add("                                and RIT.ORG_TAU_ST_CODIGO = EXP1.ORG_TAU_ST_CODIGO")
        Sql.Add("                                and RIT.SEQ_TAB_IN_CODIGO = EXP1.SEQ_TAB_IN_CODIGO")
        Sql.Add("                                and RIT.SEQ_IN_CODIGO = EXP1.SEQ_IN_CODIGO")
        Sql.Add("                                and RIT.EXP_IN_SEQUENCIA = EXP1.EXP_IN_SEQUENCIA")
        Sql.Add("                               left join FS_ROMANEIO_OE ROE")
        Sql.Add("                                 on ROE.COL_IN_ID = RIT.COL_IN_ID")
        Sql.Add("                              where EXP1.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
        Sql.Add("                                and EXP1.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
        Sql.Add("                                and EXP1.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
        Sql.Add("                                and EXP1.ORG_TAU_ST_CODIGO = PED.ORG_TAU_ST_CODIGO")
        Sql.Add("                                and EXP1.SER_ST_CODIGO = PED.SER_ST_CODIGO")
        Sql.Add("                                and EXP1.PED_IN_CODIGO = PED.PED_IN_CODIGO")
        Sql.Add("                                and EXP1.ITP_IN_SEQUENCIA = ITE.ITP_IN_SEQUENCIA")
        Sql.Add("                                and EXP1.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                                and EXP1.EXP_CH_STATUS = 'N'")
        Sql.Add("                                and NVL(ROE.COL_CH_STATUS, 'N') = 'N'),")
        Sql.Add("                             0) GER_RE_QTDEDISPONIVEL,")
        Sql.Add("                         PED.PED_IN_FRETEPCONTA PED_IN_FRETEPCONTA,")
        Sql.Add("                         AGN.AGN_ST_NOME VEN_AGN_ST_NOME,")
        Sql.Add("                         AGN.AGN_IN_CODIGO VEN_AGN_IN_CODIGO,")
        Sql.Add("                         GRU.GRU_IN_CODIGO USU_IN_CODIGO,")
        Sql.Add("                         NVL(FPRG.IPE_CH_STATUS, 'L') IPE_CH_STATUS,")
        Sql.Add("                         NVL(FPE.PED_BO_PARCIAL, 'N') PED_BO_PARCIAL,")
        Sql.Add("                         NVL(GER.PED_IN_PRIORIDADE, 0) PED_IN_PRIORIDADE,")
        Sql.Add("                         (select J.GRU_IN_CODIGO")
        Sql.Add("                            from EST_PRODUTOS      F,")
        Sql.Add("                                 GLO_IDENTIFICADOR G,")
        Sql.Add("                                 EST_GRUPOS        H,")
        Sql.Add("                                 EST_GRUPOS        I,")
        Sql.Add("                                 EST_GRUPOS        J")
        Sql.Add("                           where F.GRU_TAB_IN_CODIGO = G.TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = G.PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = G.IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_TAB_IN_CODIGO = H.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = H.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = H.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_IN_CODIGO = H.GRU_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_TAB_IN_CODIGO = I.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_PAD_IN_CODIGO = I.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IDE_ST_CODIGO = I.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IN_CODIGO = I.GRU_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_TAB_IN_CODIGO = J.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_PAD_IN_CODIGO = J.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IDE_ST_CODIGO = J.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IN_CODIGO = J.GRU_IN_CODIGO")
        Sql.Add("                             and F.PRO_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
        Sql.Add("                             and F.PRO_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
        Sql.Add("                             and F.PRO_IN_CODIGO = PRO.PRO_IN_CODIGO")
        Sql.Add("                           group by J.GRU_IN_CODIGO) GRUPO,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'B2B' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end B2B,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'B2C' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end B2C,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'EXPORTAÇÃO' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end EXPORTACAO,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'OUTROS' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end OUTROS,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'HIBRIDO' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end HIBRIDO,")
        Sql.Add("                         ")
        Sql.Add("                         case")
        Sql.Add("                           when UPPER(trim(MER.FCC_ST_DESCRICAO)) not in")
        Sql.Add("                                ('HIBRIDO', 'OUTROS', 'EXPORTAÇÃO', 'B2C', 'B2B') then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end INDEFINIDO,")
        Sql.Add("                         case ITE.ITP_ST_SITUACAO")
        Sql.Add("                           when 'P' then")
        Sql.Add("                            'Pedido em Aberto'")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            'Pedido Bloqueado'")
        Sql.Add("                           when 'A' then")
        Sql.Add("                            'Pedido Aprovado'")
        Sql.Add("                           when 'F' then")
        Sql.Add("                            'Pedido Faturado Totalmente'")
        Sql.Add("                           when 'R' then")
        Sql.Add("                            'Pedido Faturado Parcialmente'")
        Sql.Add("                           when 'C' then")
        Sql.Add("                            'Pedido Cancelado'")
        Sql.Add("                           when 'V' then")
        Sql.Add("                            'Documento Vencido'")
        Sql.Add("                           when 'E' then")
        Sql.Add("                            'Documento Encerrado'")
        Sql.Add("                         end PED_CH_SITUACAO,")
        Sql.Add("                         ")
        Sql.Add("                         case ITE.ITP_ST_SITUACAO")
        Sql.Add("                           when 'P' then")
        Sql.Add("                            'Pedido em Aberto'")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            'Pedido Bloqueado'")
        Sql.Add("                           when 'A' then")
        Sql.Add("                            'Pedido em Aberto'")
        Sql.Add("                           when 'F' then")
        Sql.Add("                            'Pedido Faturado Totalmente'")
        Sql.Add("                           when 'R' then")
        Sql.Add("                            'Pedido Faturado Parcialmente'")
        Sql.Add("                           when 'C' then")
        Sql.Add("                            'Pedido Cancelado'")
        Sql.Add("                           when 'V' then")
        Sql.Add("                            'Documento Vencido'")
        Sql.Add("                           when 'E' then")
        Sql.Add("                            'Documento Encerrado'")
        Sql.Add("                         end PED_ST_SITUACAO,")
        Sql.Add("                         ")
        Sql.Add("                         cast(case NVL(GER.PED_IN_PRIORIDADE, 0)")
        Sql.Add("                                when 9 then")
        Sql.Add("                                 '9-Exportação'")
        Sql.Add("                                when 3 then")
        Sql.Add("                                 '3-Prioridade Alta'")
        Sql.Add("                                when 2 then")
        Sql.Add("                                 '2-Prioridade Média'")
        Sql.Add("                                when 1 then")
        Sql.Add("                                 '1-Prioridade Baixa'")
        Sql.Add("                                when 0 then")
        Sql.Add("                                 '0-Prioridade Não definida'")
        Sql.Add("                              end as varchar2(30)) PRIORIDADE,")
        Sql.Add("                         ")
        Sql.Add("                         case NVL(FPRG.IPE_CH_STATUS, 'L')")
        Sql.Add("                           when 'L' then")
        Sql.Add("                            'Liberado'")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            'Bloqueado'")
        Sql.Add("                         end IPE_ST_STATUS,")
        Sql.Add("                         ")
        Sql.Add("                         case PED.PED_IN_FRETEPCONTA")
        Sql.Add("                           when 1 then")
        Sql.Add("                            'CIF'")
        Sql.Add("                           when 2 then")
        Sql.Add("                            'FOB'")
        Sql.Add("                           when 3 then")
        Sql.Add("                            'Terceiros'")
        Sql.Add("                           when 4 then")
        Sql.Add("                            'Sem Frete'")
        Sql.Add("                           when 5 then")
        Sql.Add("                            'Remetente Próprio'")
        Sql.Add("                           when 6 then")
        Sql.Add("                            'Destinatário Próprio'")
        Sql.Add("                         end PED_ST_TIPOFRETE,")
        Sql.Add("                         ")
        Sql.Add("                         NIV.B2B_IN_NIVEL,")
        Sql.Add("                         NIV.B2C_IN_NIVEL,")
        Sql.Add("                         NIV.EXP_IN_NIVEL,")
        Sql.Add("                         NIV.OUT_IN_NIVEL,")
        Sql.Add("                         ITE.EMB_TAB_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_PAD_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_UNI_TAB_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_UNI_PAD_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_UNI_ST_UNIDADE,")
        Sql.Add("                         EMB.PRO_ST_DESCRICAOPDV EMB_ST_DESCRICAO,")
        Sql.Add("                         NCM.NCM_ST_EXTENSO,")
        Sql.Add("                         PRDT.IPE_DT_DATAENTREGA DATA_CLIENTE,")
        Sql.Add("                         DECODE(PVI.PED_IN_CODIGO, null, '', 'SIM') PEDIDO_INDISPONIVEL,")
        Sql.Add("                         PRG.IPE_CH_SITUACAO,")
        Sql.Add("                         NVL(FPE.PED_BO_MIN3PC, 'N') MINIMO_3PC,")
        Sql.Add("                         ITE.ITP_RE_VALORUNITARIOCONV,")
        Sql.Add("                         /*")
        Sql.Add("                         NVL((select 'S' MINIMO_3PC")
        Sql.Add("                               from FS_TB_CLASSIFICADORES_CLIENTE CLIC")
        Sql.Add("                              where CLIC.FTT_IN_CODIGO = 2")
        Sql.Add("                                and CLIC.FTC_IN_CODIGO = 13")
        Sql.Add("                                and CLIC.AGN_TAB_IN_CODIGO = PED.CLI_TAB_IN_CODIGO")
        Sql.Add("                                and CLIC.AGN_PAD_IN_CODIGO = PED.CLI_PAD_IN_CODIGO")
        Sql.Add("                                and CLIC.AGN_IN_CODIGO = PED.CLI_IN_CODIGO")
        Sql.Add("                                and CLIC.AGN_TAU_ST_CODIGO = PED.CLI_TAU_ST_CODIGO),")
        Sql.Add("                             '') MINIMO_3PC,")
        Sql.Add("                         */")
        Sql.Add("                         case PRG.IPE_CH_TIPOENTREGA")
        Sql.Add("                           when 'A' then")
        Sql.Add("                            'Até a Data'")
        Sql.Add("                           when 'S' then")
        Sql.Add("                            'Somente na Data'")
        Sql.Add("                           when 'P' then")
        Sql.Add("                            'Após a Data'")
        Sql.Add("                         end IPE_ST_TIPOENTREGA,")
        Sql.Add("                         ")
        Sql.Add("                         (ITE.ITP_RE_VALORUNITARIO -")
        Sql.Add("                         (ITE.ITP_RE_VALORDESCRATEIO / ITE.ITP_RE_QUANTIDADE)) ITP_RE_VALORUNITARIO,")
        Sql.Add("                         PRG.IPE_RE_QTDECONVERTIDA,")
        Sql.Add("                         PRO.UNI_ST_UNIDADE UNI_ST_ORIGINAL,")
        Sql.Add("                         PRG.IPE_RE_QTDEFATURADA,")
        Sql.Add("                         PRG.IPE_RE_QUANTIDADE - PRG.IPE_RE_QTDEFATURADA IPE_RE_QTDESALDO,")
        Sql.Add("                         NVL(CPT.CTD_CH_DATA_HORIZONTE, 'N') CTD_CH_DATA_HORIZONTE")
        Sql.Add("                  ")
        Sql.Add("                    from VEN_PEDIDOVENDA PED")
        Sql.Add("                    left join FS_VEN_TIPODOCUMENTO_CLASSIFICADOR CLA")
        Sql.Add("                      on CLA.TPD_TAB_IN_CODIGO = PED.TPD_TAB_IN_CODIGO")
        Sql.Add("                     and CLA.TPD_PAD_IN_CODIGO = PED.TPD_PAD_IN_CODIGO")
        Sql.Add("                     and CLA.TPD_IN_CODIGO = PED.TPD_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_TB_CLASSIFICADORES MER")
        Sql.Add("                      on MER.FTT_IN_CODIGO = CLA.FTT_IN_CODIGO")
        Sql.Add("                     and MER.FTC_IN_CODIGO = CLA.FTC_IN_CODIGO")
        Sql.Add("                     and MER.FCC_IN_CODIGO = CLA.FCC_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_PEDIDOVENDA FPE")
        Sql.Add("                      on FPE.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and FPE.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and FPE.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
        Sql.Add("                     and FPE.ORG_TAU_ST_CODIGO = PED.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and FPE.SER_ST_CODIGO = PED.SER_ST_CODIGO")
        Sql.Add("                     and FPE.PED_IN_CODIGO = PED.PED_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_ROMANEIO_PEDVEN_INCOMPLETOS PVI")
        Sql.Add("                      on PED.ORG_TAB_IN_CODIGO = PVI.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and PED.ORG_PAD_IN_CODIGO = PVI.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and PED.ORG_IN_CODIGO = PVI.ORG_IN_CODIGO")
        Sql.Add("                     and PED.ORG_TAU_ST_CODIGO = PVI.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and PED.SER_ST_CODIGO = PVI.SER_ST_CODIGO")
        Sql.Add("                     and PED.PED_IN_CODIGO = PVI.PED_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join GLO_AGENTES AGN")
        Sql.Add("                      on PED.REP_TAB_IN_CODIGO = AGN.AGN_TAB_IN_CODIGO")
        Sql.Add("                     and PED.REP_PAD_IN_CODIGO = AGN.AGN_PAD_IN_CODIGO")
        Sql.Add("                     and PED.REP_IN_CODIGO = AGN.AGN_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join GLO_GRUPO_USUARIO GRU")
        Sql.Add("                      on GRU.GRU_IN_CODIGO = :PUSU_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join GLO_GRUPO_USUARIOCMPESP NIV")
        Sql.Add("                      on NIV.GRU_IN_CODIGO = GRU.GRU_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    join GLO_CONDPAGTO CON")
        Sql.Add("                      on CON.COND_TAB_IN_CODIGO = PED.COND_TAB_IN_CODIGO")
        Sql.Add("                     and CON.COND_PAD_IN_CODIGO = PED.COND_PAD_IN_CODIGO")
        Sql.Add("                     and CON.COND_ST_CODIGO = PED.COND_ST_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    join VEN_TIPODOCUMENTO TPD")
        Sql.Add("                      on TPD.TPD_TAB_IN_CODIGO = PED.TPD_TAB_IN_CODIGO")
        Sql.Add("                     and TPD.TPD_PAD_IN_CODIGO = PED.TPD_PAD_IN_CODIGO")
        Sql.Add("                     and TPD.TPD_IN_CODIGO = PED.TPD_IN_CODIGO")
        Sql.Add("                     and TPD.TPD_CH_TIPODOCUMENTO = 'P'")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_VEN_TIPODOCUMENTO CPT")
        Sql.Add("                      on CPT.TPD_TAB_IN_CODIGO = TPD.TPD_TAB_IN_CODIGO")
        Sql.Add("                     and CPT.TPD_PAD_IN_CODIGO = TPD.TPD_PAD_IN_CODIGO")
        Sql.Add("                     and CPT.TPD_IN_CODIGO = TPD.TPD_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                  --- CLIENTE DO PEDIDO")
        Sql.Add("                    join GLO_AGENTES_ID CLD")
        Sql.Add("                      on CLD.AGN_TAB_IN_CODIGO = PED.CLI_TAB_IN_CODIGO")
        Sql.Add("                     and CLD.AGN_PAD_IN_CODIGO = PED.CLI_PAD_IN_CODIGO")
        Sql.Add("                     and CLD.AGN_IN_CODIGO = PED.CLI_IN_CODIGO")
        Sql.Add("                     and CLD.AGN_TAU_ST_CODIGO = PED.CLI_TAU_ST_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    join GLO_AGENTES CLI")
        Sql.Add("                      on CLI.AGN_TAB_IN_CODIGO = CLD.AGN_TAB_IN_CODIGO")
        Sql.Add("                     and CLI.AGN_PAD_IN_CODIGO = CLD.AGN_PAD_IN_CODIGO")
        Sql.Add("                     and CLI.AGN_IN_CODIGO = CLD.AGN_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join GLO_MUNICIPIO MUN")
        Sql.Add("                      on MUN.UF_ST_SIGLA = CLI.UF_ST_SIGLA")
        Sql.Add("                     and MUN.MUN_IN_CODIGO = CLI.MUN_IN_CODIGO")
        Sql.Add("                  --- ITENS DO PEDIDO")
        Sql.Add("                    join VEN_ITEMPEDIDOVENDA ITE")
        Sql.Add("                      on ITE.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and ITE.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and ITE.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
        Sql.Add("                     and ITE.PED_IN_CODIGO = PED.PED_IN_CODIGO")
        Sql.Add("                  --- EMBALAGEM DO PRODUTO")
        Sql.Add("                    left join EST_PRODUTOS EMB")
        Sql.Add("                      on EMB.PRO_TAB_IN_CODIGO = ITE.EMB_TAB_IN_CODIGO")
        Sql.Add("                     and EMB.PRO_PAD_IN_CODIGO = ITE.EMB_PAD_IN_CODIGO")
        Sql.Add("                     and EMB.PRO_IN_CODIGO = ITE.EMB_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join VEN_PEDPROGENTREGA PRG")
        Sql.Add("                      on PRG.ORG_TAB_IN_CODIGO = ITE.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and PRG.ORG_PAD_IN_CODIGO = ITE.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and PRG.ORG_IN_CODIGO = ITE.ORG_IN_CODIGO")
        Sql.Add("                     and PRG.ORG_TAU_ST_CODIGO = ITE.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and PRG.SER_ST_CODIGO = ITE.SER_ST_CODIGO")
        Sql.Add("                     and PRG.PED_IN_CODIGO = ITE.PED_IN_CODIGO")
        Sql.Add("                     and PRG.ITP_IN_SEQUENCIA = ITE.ITP_IN_SEQUENCIA")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_PEDPROGENTREGA FPRG")
        Sql.Add("                      on FPRG.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and FPRG.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and FPRG.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                     and FPRG.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and FPRG.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                     and FPRG.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                     and FPRG.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                     and FPRG.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_PEDPROGENTREGA_DATACLI PRDT")
        Sql.Add("                      on PRDT.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and PRDT.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and PRDT.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                     and PRDT.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and PRDT.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                     and PRDT.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                     and PRDT.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                     and PRDT.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                  ")
        Sql.Add("                    join EST_PRODUTOS PRO")
        Sql.Add("                      on PRO.PRO_TAB_IN_CODIGO = ITE.PRO_TAB_IN_CODIGO")
        Sql.Add("                     and PRO.PRO_PAD_IN_CODIGO = ITE.PRO_PAD_IN_CODIGO")
        Sql.Add("                     and PRO.PRO_IN_CODIGO = ITE.PRO_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                  --- NCM")
        Sql.Add("                    left join TRF_NCM NCM")
        Sql.Add("                      on PRO.NCM_TAB_IN_CODIGO = NCM.NCM_TAB_IN_CODIGO")
        Sql.Add("                     and PRO.NCM_PAD_IN_CODIGO = NCM.NCM_PAD_IN_CODIGO")
        Sql.Add("                     and PRO.NCM_IN_CODIGO = NCM.NCM_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join VEN_ITEMPEDI_VEN_ITEMNOT NFI")
        Sql.Add("                      on NFI.PE_ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and NFI.PE_ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and NFI.PE_ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                     and NFI.PE_ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and NFI.PE_SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                     and NFI.PE_PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                     and NFI.PE_ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                     and NFI.PE_IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                  ")
        Sql.Add("                  --- TRANSPORTADOR")
        Sql.Add("                    left join GLO_AGENTES TRA")
        Sql.Add("                      on TRA.AGN_TAB_IN_CODIGO = PED.TRA_TAB_IN_CODIGO")
        Sql.Add("                     and TRA.AGN_PAD_IN_CODIGO = PED.TRA_PAD_IN_CODIGO")
        Sql.Add("                     and TRA.AGN_IN_CODIGO = PED.TRA_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_PEDIDOVENDAGER GER")
        Sql.Add("                      on GER.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and GER.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and GER.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                     and GER.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and GER.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                     and GER.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                     and GER.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                     and GER.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                   where PED.FIL_IN_CODIGO = :PFIL_IN_CODIGO")
        Sql.Add("                        ")
        Sql.Add("                     and ((:PITP_ST_PEDIDOCLIENTE is null and 1 = 1) or")
        Sql.Add("                         (:PITP_ST_PEDIDOCLIENTE is not null and")
        Sql.Add("                         ITE.ITP_ST_PEDIDOCLIENTE = :PITP_ST_PEDIDOCLIENTE))")
        Sql.Add("                        ")
        Sql.Add("                     and PED.REP_IN_CODIGO =")
        Sql.Add("                         NVL(:PREP_IN_CODIGO, PED.REP_IN_CODIGO)")
        Sql.Add("                        ")
        Sql.Add("                     and PED.TPD_IN_CODIGO =")
        Sql.Add("                         NVL(:PTPD_IN_CODIGO, PED.TPD_IN_CODIGO)")
        Sql.Add("                        ")
        Sql.Add("                     and PRG.IPE_DT_DATAENTREGA between")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PENTREGA_INICIAL), '01/01/2022') ||")
        Sql.Add("                                 ' 00:00:00',")
        Sql.Add("                                 'dd/mm/yyyy hh24:mi:ss') and")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PENTREGA_FINAL), '01/01/2099') ||")
        Sql.Add("                                 ' 23:59:59',")
        Sql.Add("                                 'dd/mm/yyyy HH24:mi:ss')")
        Sql.Add("                     and NVL(PRDT.IPE_DT_DATAENTREGA, TRUNC(sysdate)) between")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PDATA_CLIENTE_INICIAL),")
        Sql.Add("                                     '01/01/2022') || ' 00:00:00',")
        Sql.Add("                                 'dd/mm/yyyy hh24:mi:ss') and")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PDATA_CLIENTE_FINAL), '01/01/2099') ||")
        Sql.Add("                                 ' 23:59:59',")
        Sql.Add("                                 'dd/mm/yyyy HH24:mi:ss')")
        Sql.Add("                     and PED.PED_DT_EMISSAO between")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PEMISSAO_INICIAL), '01/01/2022') ||")
        Sql.Add("                                 '00:00:00',")
        Sql.Add("                                 'dd/mm/yyyy hh24:mi:ss') and")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PEMISSAO_FINAL), '01/01/2099') ||")
        Sql.Add("                                 '23:59:59',")
        Sql.Add("                                 'dd/mm/yyyy HH24:mi:ss')")
        Sql.Add("                     and PED.PED_IN_CODIGO between NVL(:PPEDIDO_INICIAL, 0) and")
        Sql.Add("                         NVL(:PPEDIDO_FINAL, 99999999)")
        Sql.Add("                     and PRO.PRO_IN_CODIGO between NVL(:PITEM_INICIAL, 0) and")
        Sql.Add("                         NVL(:PITEM_FINAL, 99999999)")
        Sql.Add("                     and exists")
        Sql.Add("                   (select J.GRU_IN_CODIGO")
        Sql.Add("                            from EST_PRODUTOS      F,")
        Sql.Add("                                 GLO_IDENTIFICADOR G,")
        Sql.Add("                                 EST_GRUPOS        H,")
        Sql.Add("                                 EST_GRUPOS        I,")
        Sql.Add("                                 EST_GRUPOS        J")
        Sql.Add("                           where F.GRU_TAB_IN_CODIGO = G.TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = G.PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = G.IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_TAB_IN_CODIGO = H.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = H.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = H.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_IN_CODIGO = H.GRU_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_TAB_IN_CODIGO = I.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_PAD_IN_CODIGO = I.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IDE_ST_CODIGO = I.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IN_CODIGO = I.GRU_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_TAB_IN_CODIGO = J.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_PAD_IN_CODIGO = J.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IDE_ST_CODIGO = J.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IN_CODIGO = J.GRU_IN_CODIGO")
        Sql.Add("                             and F.PRO_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
        Sql.Add("                             and F.PRO_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
        Sql.Add("                             and F.PRO_IN_CODIGO = PRO.PRO_IN_CODIGO")
        Sql.Add("                             and J.GRU_IN_CODIGO between NVL(:PGRUPO_INICIAL, 0) and")
        Sql.Add("                                 NVL(:PGRUPO_FINAL, 999999)")
        Sql.Add("                           group by J.GRU_IN_CODIGO)")
        Sql.Add("                        ")
        Sql.Add("                     and exists")
        Sql.Add("                   (select D.GRU_IN_CODIGO")
        Sql.Add("                            from EST_PRODUTOS A")
        Sql.Add("                            join EST_GRUPOS B")
        Sql.Add("                              on B.GRU_TAB_IN_CODIGO = A.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and B.GRU_PAD_IN_CODIGO = A.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and B.GRU_IDE_ST_CODIGO = A.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and B.GRU_IN_CODIGO = A.GRU_IN_CODIGO")
        Sql.Add("                            join EST_GRUPOS C")
        Sql.Add("                              on C.GRU_TAB_IN_CODIGO = B.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and C.GRU_PAD_IN_CODIGO = B.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and C.GRU_IDE_ST_CODIGO = B.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and C.GRU_IN_CODIGO = B.GRU_IN_CODIGO")
        Sql.Add("                            join EST_GRUPOS D")
        Sql.Add("                              on D.GRU_TAB_IN_CODIGO = C.PAI_GRU_TAB_IN_CODIGO")
        Sql.Add("                             and D.GRU_PAD_IN_CODIGO = C.PAI_GRU_PAD_IN_CODIGO")
        Sql.Add("                             and D.GRU_IDE_ST_CODIGO = C.PAI_GRU_IDE_ST_CODIGO")
        Sql.Add("                             and D.GRU_IN_CODIGO = C.PAI_GRU_IN_CODIGO")
        Sql.Add("                           where A.PRO_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
        Sql.Add("                             and A.PRO_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
        Sql.Add("                             and A.PRO_IN_CODIGO = PRO.PRO_IN_CODIGO")
        Sql.Add("                             and D.GRU_IN_CODIGO between")
        Sql.Add("                                 NVL(:PSUBGRUPO_INICIAL, 0) and")
        Sql.Add("                                 NVL(:PSUBGRUPO_FINAL, 999999)")
        Sql.Add("                           group by D.GRU_IN_CODIGO)")
        Sql.Add("                        ")
        Sql.Add("                     and PED.CLI_IN_CODIGO between NVL(:PCLIENTE_INICIAL, 0) and")
        Sql.Add("                         NVL(:PCLIENTE_FINAL, 999999)")
        Sql.Add("                        ")
        Sql.Add("                     and ((:PNOTA_INICIAL is null and 1 = 1) or")
        Sql.Add("                         PED.PED_IN_CODIGO in")
        Sql.Add("                         (select IT.PE_PED_IN_CODIGO")
        Sql.Add("                             from VEN_NOTAFISCAL NF")
        Sql.Add("                             join VEN_ITEMPEDI_VEN_ITEMNOT IT")
        Sql.Add("                               on IT.NF_ORG_TAB_IN_CODIGO = NF.ORG_TAB_IN_CODIGO")
        Sql.Add("                              and IT.NF_ORG_PAD_IN_CODIGO = NF.ORG_PAD_IN_CODIGO")
        Sql.Add("                              and IT.NF_ORG_IN_CODIGO = NF.ORG_IN_CODIGO")
        Sql.Add("                              and IT.NF_ORG_TAU_ST_CODIGO = NF.ORG_TAU_ST_CODIGO")
        Sql.Add("                              and IT.NF_SEQ_TAB_IN_CODIGO = NF.SEQ_TAB_IN_CODIGO")
        Sql.Add("                              and IT.NF_SEQ_IN_CODIGO = NF.SEQ_IN_CODIGO")
        Sql.Add("                              and IT.NF_NOT_IN_CODIGO = NF.NOT_IN_CODIGO")
        Sql.Add("                            where NF.NOT_IN_NUMERO between :PNOTA_INICIAL and :PNOTA_FINAL")
        Sql.Add("                              and IT.PE_ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                              and IT.PE_ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                              and IT.PE_ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                              and IT.PE_ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                              and IT.PE_SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                              and IT.PE_PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                              and IT.PE_ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                              and IT.PE_IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                            group by IT.PE_PED_IN_CODIGO))")
        Sql.Add("                        ")
        Sql.Add("                     and NVL(GER.PED_IN_PRIORIDADE, 0) between")
        Sql.Add("                         NVL(:PPRIORIDADE, 0) and NVL(:PPRIORIDADE, 9)")
        Sql.Add("                        ")
        Sql.Add("                     and (case NVL(FPRG.IPE_CH_STATUS, 'L')")
        Sql.Add("                           when 'L' then")
        Sql.Add("                            'Liberado'")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            'Bloqueado'")
        Sql.Add("                         end = :PSTATUSENTREGA or")
        Sql.Add("                         NVL(:PSTATUSENTREGA, 'S') = 'S')")
        Sql.Add("                        ")
        Sql.Add("                     and ((case ITE.ITP_ST_SITUACAO")
        Sql.Add("                           when 'P' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto Pedido Bloqueado',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'A' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'R' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto Pedido Faturado Parcialmente',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'F' then")
        Sql.Add("                            'Pedido Faturado Totalmente'")
        Sql.Add("                           when 'C' then")
        Sql.Add("                            'Pedido Cancelado'")
        Sql.Add("                           when 'V' then")
        Sql.Add("                            'Documento Vencido'")
        Sql.Add("                           when 'E' then")
        Sql.Add("                            'Documento Encerrado'")
        Sql.Add("                         end like '%' || :PSTATUS || '%') or")
        Sql.Add("                         NVL(:PSTATUS, 'S') = 'S')")
        Sql.Add("                        ")
        Sql.Add("                     and NVL(FPE.PED_BO_PARCIAL, 'N') =")
        Sql.Add("                         DECODE(NVL(:PPARCIAL, 'T'),")
        Sql.Add("                                'T',")
        Sql.Add("                                NVL(FPE.PED_BO_PARCIAL, 'N'),")
        Sql.Add("                                NVL(:PPARCIAL, 'T'))")
        Sql.Add("                        ")
        Sql.Add("                     and GRU.GRU_IN_CODIGO = :PUSU_IN_CODIGO")
        Sql.Add("                        ")
        Sql.Add("                     and ((:PIPE_IN_SEQUENCIA is null and 1 = 1) or")
        Sql.Add("                         (:PIPE_IN_SEQUENCIA is not null and")
        Sql.Add("                         PRG.IPE_IN_SEQUENCIA = :PIPE_IN_SEQUENCIA))")
        Sql.Add("                        ")
        Sql.Add("                     and ((:PSTATUSOE is null and 1 = 1) or")
        Sql.Add("                         (exists")
        Sql.Add("                          (select 1")
        Sql.Add("                              from VEN_EXPEDICAO EXP")
        Sql.Add("                             where EXP.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                               and EXP.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                               and EXP.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                               and EXP.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                               and EXP.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                               and EXP.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                               and EXP.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                               and EXP.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                               and case EXP.EXP_CH_STATUS")
        Sql.Add("                                     when 'N' then")
        Sql.Add("                                      'Aguardando Separação'")
        Sql.Add("                                     when 'B' then")
        Sql.Add("                                      'Bloqueado'")
        Sql.Add("                                     when 'L' then")
        Sql.Add("                                      'Liberadas para faturamento'")
        Sql.Add("                                     when 'F' then")
        Sql.Add("                                      'Faturado'")
        Sql.Add("                                     when 'C' then")
        Sql.Add("                                      'Cancelado'")
        Sql.Add("                                   end = :PSTATUSOE)))")
        Sql.Add("                  ")
        Sql.Add("                   group by PED.ORG_TAB_IN_CODIGO,")
        Sql.Add("                            PED.ORG_PAD_IN_CODIGO,")
        Sql.Add("                            PED.ORG_IN_CODIGO,")
        Sql.Add("                            PED.ORG_TAU_ST_CODIGO,")
        Sql.Add("                            PED.SER_ST_CODIGO,")
        Sql.Add("                            PED.PED_IN_CODIGO,")
        Sql.Add("                            PED.FIL_IN_CODIGO,")
        Sql.Add("                            TPD.TPD_IN_CODIGO,")
        Sql.Add("                            TPD.TPD_ST_DESCRICAO,")
        Sql.Add("                            PED.PED_DT_EMISSAO,")
        Sql.Add("                            PED.PED_DT_EMISSAO,")
        Sql.Add("                            PED.CLI_TAB_IN_CODIGO,")
        Sql.Add("                            PED.CLI_PAD_IN_CODIGO,")
        Sql.Add("                            PED.CLI_IN_CODIGO,")
        Sql.Add("                            PED.CLI_TAU_ST_CODIGO,")
        Sql.Add("                            CLI.AGN_ST_NOME,")
        Sql.Add("                            MUN.UF_ST_SIGLA,")
        Sql.Add("                            MUN.MUN_IN_CODIGO,")
        Sql.Add("                            MUN.MUN_ST_NOME,")
        Sql.Add("                            PED.COND_ST_CODIGO,")
        Sql.Add("                            CON.COND_ST_NOME,")
        Sql.Add("                            TRA.AGN_IN_CODIGO,")
        Sql.Add("                            TRA.AGN_ST_NOME,")
        Sql.Add("                            PRO.PRO_TAB_IN_CODIGO,")
        Sql.Add("                            PRO.PRO_PAD_IN_CODIGO,")
        Sql.Add("                            PRO.PRO_IN_CODIGO,")
        Sql.Add("                            PRO.GRU_TAB_IN_CODIGO,")
        Sql.Add("                            PRO.GRU_PAD_IN_CODIGO,")
        Sql.Add("                            PRO.GRU_IDE_ST_CODIGO,")
        Sql.Add("                            PRO.GRU_IN_CODIGO,")
        Sql.Add("                            PRO.PRO_ST_ALTERNATIVO,")
        Sql.Add("                            PRO.PRO_ST_DESCRICAO,")
        Sql.Add("                            ITE.UNI_ST_UNIDADE,")
        Sql.Add("                            ITE.ITP_RE_QUANTIDADE,")
        Sql.Add("                            ITE.ITP_IN_SEQUENCIA,")
        Sql.Add("                            ITE.ITP_ST_SITUACAO,")
        Sql.Add("                            ITE.ITP_RE_VALORUNITARIO,")
        Sql.Add("                            ITE.ITP_RE_VALORUNITARIOCONV,")
        Sql.Add("                            ITE.ITP_RE_VALORDESCRATEIO,")
        Sql.Add("                            PRG.IPE_IN_SEQUENCIA,")
        Sql.Add("                            PRG.IPE_RE_QUANTIDADE,")
        Sql.Add("                            PRG.IPE_DT_DATAENTREGA,")
        Sql.Add("                            PRG.IPE_RE_QTDECONVERTIDA,")
        Sql.Add("                            PRG.IPE_DT_DATAEXPEDICAO,")
        Sql.Add("                            AGN.AGN_ST_NOME,")
        Sql.Add("                            AGN.AGN_IN_CODIGO,")
        Sql.Add("                            GRU.GRU_IN_CODIGO,")
        Sql.Add("                            GRU.GRU_ST_NOME,")
        Sql.Add("                            PED.PED_CH_SITUACAO,")
        Sql.Add("                            GER.PED_IN_PRIORIDADE,")
        Sql.Add("                            GER.PED_IN_CODIGO,")
        Sql.Add("                            FPRG.IPE_CH_STATUS,")
        Sql.Add("                            FPE.PED_BO_PARCIAL,")
        Sql.Add("                            PED.PED_IN_FRETEPCONTA,")
        Sql.Add("                            MER.FCC_ST_DESCRICAO,")
        Sql.Add("                            NIV.B2B_IN_NIVEL,")
        Sql.Add("                            NIV.B2C_IN_NIVEL,")
        Sql.Add("                            NIV.EXP_IN_NIVEL,")
        Sql.Add("                            NIV.OUT_IN_NIVEL,")
        Sql.Add("                            ITE.EMB_TAB_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_PAD_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_UNI_TAB_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_UNI_PAD_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_UNI_ST_UNIDADE,")
        Sql.Add("                            EMB.PRO_ST_DESCRICAOPDV,")
        Sql.Add("                            NCM.NCM_ST_EXTENSO,")
        Sql.Add("                            PRDT.IPE_DT_DATAENTREGA,")
        Sql.Add("                            DECODE(PVI.PED_IN_CODIGO, null, '', 'SIM'),")
        Sql.Add("                            PRG.IPE_CH_SITUACAO,")
        Sql.Add("                            FPE.PED_BO_MIN3PC,")
        Sql.Add("                            PRG.IPE_CH_TIPOENTREGA,")
        Sql.Add("                            ITE.ITP_RE_QTDECONVERTIDA,")
        Sql.Add("                            PRO.UNI_ST_UNIDADE,")
        Sql.Add("                            ITE.ITP_ST_PEDIDOCLIENTE,")
        Sql.Add("                            PRG.IPE_RE_QTDEFATURADA,")
        Sql.Add("                            CPT.CTD_CH_DATA_HORIZONTE) DADOS")
        Sql.Add("         ")
        Sql.Add("          where ((DADOS.B2B =")
        Sql.Add("                DECODE(:PB2B, 'N', DECODE(DADOS.B2B, 'N', 'S', 'N'), 'S') or")
        Sql.Add("                DADOS.B2C =")
        Sql.Add("                DECODE(:PB2C, 'N', DECODE(DADOS.B2C, 'N', 'S', 'N'), 'S') or")
        Sql.Add("                DADOS.EXPORTACAO =")
        Sql.Add("                DECODE(:PEXPORTACAO,")
        Sql.Add("                         'N',")
        Sql.Add("                         DECODE(DADOS.EXPORTACAO, 'N', 'S', 'N'),")
        Sql.Add("                         'S') or")
        Sql.Add("                DADOS.OUTROS = DECODE(:POUTROS,")
        Sql.Add("                                        'N',")
        Sql.Add("                                        DECODE(DADOS.OUTROS, 'N', 'S', 'N'),")
        Sql.Add("                                        'S') or")
        Sql.Add("                DADOS.HIBRIDO = DECODE(:PHIBRIDO,")
        Sql.Add("                                         'N',")
        Sql.Add("                                         DECODE(DADOS.HIBRIDO, 'N', 'S', 'N'),")
        Sql.Add("                                         'S') or")
        Sql.Add("                DADOS.INDEFINIDO =")
        Sql.Add("                DECODE(:PINDEFINIDO,")
        Sql.Add("                         'N',")
        Sql.Add("                         DECODE(DADOS.INDEFINIDO, 'N', 'S', 'N'),")
        Sql.Add("                         'S') or :PTODOS = 'S'))")
        Sql.Add("         ")
        Sql.Add("         ) T")
        Sql.Add("  where ((T.B2B = 'S' and T.B2B_IN_NIVEL >= 1) or")
        Sql.Add("        (T.B2C = 'S' and T.B2C_IN_NIVEL >= 1) or")
        Sql.Add("        (T.EXPORTACAO = 'S' and T.EXP_IN_NIVEL >= 1) or")
        Sql.Add("        (T.OUTROS = 'S' and T.OUT_IN_NIVEL >= 1))")
        Sql.Add("    and ((:PCARREGATELA = 'N' and 1 = 1) or (:PCARREGATELA = 'S' and 1 = 2))")
        Sql.Add("order by T.PED_IN_PRIORIDADE desc,")
        Sql.Add("         TO_NUMBER(TO_CHAR(T.IPE_DT_DATAEXPEDICAO, 'YYYYMMDD')),")
        Sql.Add("         T.PED_IN_CODIGO,")
        Sql.Add("         T.ORDEM_OE_INICIADA,")
        Sql.Add("         T.ITP_IN_SEQUENCIA,")
        Sql.Add("         T.IPE_IN_SEQUENCIA")
        '// Aqui Herbert


        '// OnAfterScroll = AddressOf Cl_Dados_OnAfterScroll()
        '//Open thiago mazolli
      End With

      With Cl_PedProgEntregaItem
        Name = "Cl_PedProgEntregaItem"
        TableName = "DUAL"
        SQL.Clear
        SQL.Add("SELECT T.*                                                               ")
        SQL.Add("  FROM TABLE(FS_PCK_PEDIDOVENDA.F_FNC_PEDIDOVENDA(:pFIL_IN_CODIGO,       ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  :pPEDIDO_INICIAL,      ")
        SQL.Add("                                                  :pPEDIDO_FINAL,        ")
        SQL.Add("                                                  :pITEM_INICIAL,        ")
        SQL.Add("                                                  :pITEM_FINAL,          ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  :pUSU_IN_CODIGO,       ")
        SQL.Add("                                                  :pIPE_IN_SEQUENCIA,    ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL,                  ")
        SQL.Add("                                                  NULL)) T               ")
        SQL.Add("WHERE ((T.B2B         = 'S' AND T.B2B_IN_NIVEL >= 1) OR                  ")
        SQL.Add("       (T.B2C         = 'S' AND T.B2C_IN_NIVEL >= 1) OR                  ")
        SQL.Add("       (T.EXPORTACAO  = 'S' AND T.EXP_IN_NIVEL >= 1) OR                  ")
        SQL.Add("       (T.OUTROS      = 'S' AND T.OUT_IN_NIVEL >= 1))                    ")
        '// ParamByname("pTAG_USER").Value = vTag_User
      End With

      With Cl_DadosResevaAutomatica
        Name = "Cl_DadosResevaAutomatica"
        TableName = "DUAL"
        Close
        SQL.Clear
        Sql.Add(" select T.*,")
        Sql.Add("        FS_PCK_PEDIDOVENDA.F_SALDO_DISPONIVEL(T.ORG_IN_CODIGO,")
        Sql.Add("                                              T.FIL_IN_CODIGO,")
        Sql.Add("                                              T.PRO_TAB_IN_CODIGO,")
        Sql.Add("                                              T.PRO_PAD_IN_CODIGO,")
        Sql.Add("                                              T.PRO_IN_CODIGO,")
        Sql.Add("                                              null) SALDO_ITEM,")
        Sql.Add("        FS_PCK_PEDIDOVENDA.F_SALDO_PEDIDO(T.ORG_TAB_IN_CODIGO,")
        Sql.Add("                                          T.ORG_PAD_IN_CODIGO,")
        Sql.Add("                                          T.ORG_IN_CODIGO,")
        Sql.Add("                                          T.ORG_TAU_ST_CODIGO,")
        Sql.Add("                                          T.SER_ST_CODIGO,")
        Sql.Add("                                          T.PED_IN_CODIGO) SALDO_PEDIDO,")
        Sql.Add("        'N' CONFIRMAR")
        Sql.Add("   from (select DADOS.ORG_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.ORG_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.ORG_IN_CODIGO,")
        Sql.Add("                 DADOS.ORG_TAU_ST_CODIGO,")
        Sql.Add("                 DADOS.SER_ST_CODIGO,")
        Sql.Add("                 DADOS.PED_IN_CODIGO,")
        Sql.Add("                 DADOS.FIL_IN_CODIGO,")
        Sql.Add("                 DADOS.TPD_IN_CODIGO,")
        Sql.Add("                 DADOS.TPD_ST_DESCRICAO,")
        Sql.Add("                 DADOS.PED_CH_STATUS,")
        Sql.Add("                 DADOS.PED_DT_EMISSAO,")
        Sql.Add("                 DADOS.CLI_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.CLI_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.CLI_IN_CODIGO,")
        Sql.Add("                 DADOS.CLI_TAU_ST_CODIGO,")
        Sql.Add("                 DADOS.CLI_ST_NOME,")
        Sql.Add("                 DADOS.UF_ST_SIGLA,")
        Sql.Add("                 DADOS.MUN_IN_CODIGO,")
        Sql.Add("                 DADOS.MUN_ST_NOME,")
        Sql.Add("                 DADOS.COND_ST_CODIGO,")
        Sql.Add("                 DADOS.COND_ST_NOME,")
        Sql.Add("                 DADOS.TRA_IN_CODIGO,")
        Sql.Add("                 DADOS.TRA_ST_NOME,")
        Sql.Add("                 DADOS.PRO_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.PRO_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.PRO_IN_CODIGO,")
        Sql.Add("                 DADOS.GRU_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.GRU_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.GRU_IDE_ST_CODIGO,")
        Sql.Add("                 DADOS.GRU_IN_CODIGO,")
        Sql.Add("                 DADOS.SUB_GRUPO,")
        Sql.Add("                 DADOS.PRO_ST_ALTERNATIVO,")
        Sql.Add("                 DADOS.PRO_ST_DESCRICAO,")
        Sql.Add("                 DADOS.UNI_ST_UNIDADE,")
        Sql.Add("                 DADOS.ITP_RE_QUANTIDADE,")
        Sql.Add("                 DADOS.ITP_IN_SEQUENCIA,")
        Sql.Add("                 DADOS.IPE_IN_SEQUENCIA,")
        Sql.Add("                 DADOS.IPE_RE_QUANTIDADE,")
        Sql.Add("                 DADOS.IPE_DT_DATAENTREGA,")
        Sql.Add("                 DADOS.GER_RE_QUANTIDADE,")
        Sql.Add("                 DADOS.GER_RE_QTDEDISPONIVEL,")
        Sql.Add("                 DADOS.PED_IN_FRETEPCONTA,")
        Sql.Add("                 DADOS.VEN_AGN_ST_NOME,")
        Sql.Add("                 DADOS.VEN_AGN_IN_CODIGO,")
        Sql.Add("                 DADOS.USU_IN_CODIGO,")
        Sql.Add("                 DADOS.IPE_CH_STATUS,")
        Sql.Add("                 DADOS.PED_BO_PARCIAL,")
        Sql.Add("                 DADOS.PED_IN_PRIORIDADE,")
        Sql.Add("                 DADOS.GRUPO,")
        Sql.Add("                 DADOS.B2B,")
        Sql.Add("                 DADOS.B2C,")
        Sql.Add("                 DADOS.EXPORTACAO,")
        Sql.Add("                 DADOS.OUTROS,")
        Sql.Add("                 DADOS.HIBRIDO,")
        Sql.Add("                 DADOS.INDEFINIDO,")
        Sql.Add("                 DADOS.PED_CH_SITUACAO,")
        Sql.Add("                 DADOS.PED_ST_SITUACAO,")
        Sql.Add("                 DADOS.PRIORIDADE,")
        Sql.Add("                 DADOS.IPE_ST_STATUS,")
        Sql.Add("                 DADOS.PED_ST_TIPOFRETE,")
        Sql.Add("                 DADOS.B2B_IN_NIVEL,")
        Sql.Add("                 DADOS.B2C_IN_NIVEL,")
        Sql.Add("                 DADOS.EXP_IN_NIVEL,")
        Sql.Add("                 DADOS.OUT_IN_NIVEL,")
        Sql.Add("                 DADOS.EMB_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_UNI_TAB_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_UNI_PAD_IN_CODIGO,")
        Sql.Add("                 DADOS.EMB_UNI_ST_UNIDADE,")
        Sql.Add("                 DADOS.EMB_ST_DESCRICAO,")
        Sql.Add("                 DADOS.DATA_CLIENTE,")
        Sql.Add("                 DADOS.IPE_CH_SITUACAO,")
        Sql.Add("                 DADOS.MINIMO_3PC,")
        Sql.Add("                 DADOS.IPE_ST_TIPOENTREGA,")
        Sql.Add("                 DADOS.ITP_RE_VALORUNITARIO,")
        Sql.Add("                 DADOS.IPE_RE_QTDECONVERTIDA,")
        Sql.Add("                 DADOS.IPE_RE_QTDEFATURADA,")
        Sql.Add("                 DADOS.IPE_RE_QTDESALDO,")
        Sql.Add("                 DADOS.IPE_DT_DATAEXPEDICAO,")
        Sql.Add("                 DECODE(DADOS.B2B,")
        Sql.Add("                        'S',")
        Sql.Add("                        'B2B',")
        Sql.Add("                        DECODE(DADOS.B2C,")
        Sql.Add("                               'S',")
        Sql.Add("                               'B2C',")
        Sql.Add("                               DECODE(DADOS.EXPORTACAO,")
        Sql.Add("                                      'S',")
        Sql.Add("                                      'EXPORTACAO',")
        Sql.Add("                                      DECODE(DADOS.OUTROS,")
        Sql.Add("                                             'S',")
        Sql.Add("                                             'OUTROS',")
        Sql.Add("                                             DECODE(DADOS.HIBRIDO,")
        Sql.Add("                                                    'S',")
        Sql.Add("                                                    'HIBRIDO',")
        Sql.Add("                                                    DECODE(DADOS.INDEFINIDO,")
        Sql.Add("                                                           'S',")
        Sql.Add("                                                           'INDEFINIDO')))))) MERCADO,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when ((DADOS.PED_BO_PARCIAL in ('N') or")
        Sql.Add("                        DADOS.EXPORTACAO = 'S') and")
        Sql.Add("                        (IPE_RE_QUANTIDADE <> ITP_RE_QUANTIDADE)) then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.PED_CH_STATUS not in ('A', 'P', 'B') then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.IPE_CH_STATUS in ('B') then")
        Sql.Add("                    'S'")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end BLO_CH_GEROE,")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.IPE_CH_SITUACAO = 'B' then")
        Sql.Add("                    'S'")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end BLO_CH_EDICAO,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.B2B = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 2, 'S', 'N')")
        Sql.Add("                   when DADOS.B2C = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 2, 'S', 'N')")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 2, 'S', 'N')")
        Sql.Add("                   when DADOS.OUTROS = 'S' then")
        Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 2, 'S', 'N')")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end NIV_CH_GERENCIA,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.B2B = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 3, 'S', 'N')")
        Sql.Add("                   when DADOS.B2C = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 3, 'S', 'N')")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 3, 'S', 'N')")
        Sql.Add("                   when DADOS.OUTROS = 'S' then")
        Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 3, 'S', 'N')")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end NIV_CH_REDISTRIBUI,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.B2B = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 1, 'S', 'N')")
        Sql.Add("                   when DADOS.B2C = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 1, 'S', 'N')")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 1, 'S', 'N')")
        Sql.Add("                   when DADOS.OUTROS = 'S' then")
        Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 1, 'S', 'N')")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end NIV_CH_VISUALIZA,")
        Sql.Add("                 ")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.B2B = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 0, 'S', 'N')")
        Sql.Add("                   when DADOS.B2C = 'S' then")
        Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 0, 'S', 'N')")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 0, 'S', 'N')")
        Sql.Add("                   when DADOS.OUTROS = 'S' then")
        Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 0, 'S', 'N')")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end NIV_CH_NENHUM,")
        Sql.Add("                 case")
        Sql.Add("                   when (select count(B.EXP_IN_CODIGO) EXP_IN_CODIGO")
        Sql.Add("                           from VEN_PEDIDOVENDA A")
        Sql.Add("                           join VEN_EXPEDICAO B")
        Sql.Add("                             on B.ORG_TAB_IN_CODIGO = A.ORG_TAB_IN_CODIGO")
        Sql.Add("                            and B.ORG_PAD_IN_CODIGO = A.ORG_PAD_IN_CODIGO")
        Sql.Add("                            and B.ORG_IN_CODIGO = A.ORG_IN_CODIGO")
        Sql.Add("                            and B.ORG_TAU_ST_CODIGO = A.ORG_TAU_ST_CODIGO")
        Sql.Add("                            and B.SER_ST_CODIGO = A.SER_ST_CODIGO")
        Sql.Add("                            and B.PED_IN_CODIGO = A.PED_IN_CODIGO")
        Sql.Add("                          where A.ORG_TAB_IN_CODIGO = DADOS.ORG_TAB_IN_CODIGO")
        Sql.Add("                            and A.ORG_PAD_IN_CODIGO = DADOS.ORG_PAD_IN_CODIGO")
        Sql.Add("                            and A.ORG_IN_CODIGO = DADOS.ORG_IN_CODIGO")
        Sql.Add("                            and A.ORG_TAU_ST_CODIGO = DADOS.ORG_TAU_ST_CODIGO")
        Sql.Add("                            and A.SER_ST_CODIGO = DADOS.SER_ST_CODIGO")
        Sql.Add("                            and A.PED_IN_CODIGO = DADOS.PED_IN_CODIGO) > 0 then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.PED_CH_STATUS not in ('A', 'P', 'B') then")
        Sql.Add("                    'S'")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end BLO_CH_PARCIAL,")
        Sql.Add("                 case")
        Sql.Add("                   when ((DADOS.PED_BO_PARCIAL in ('N') or")
        Sql.Add("                        DADOS.EXPORTACAO = 'S') and")
        Sql.Add("                        (IPE_RE_QUANTIDADE <> ITP_RE_QUANTIDADE)) then")
        Sql.Add("                    'S'")
        Sql.Add("                   when DADOS.PED_CH_STATUS not in ('A', 'P', 'B') then")
        Sql.Add("                    'S'")
        Sql.Add("                   else")
        Sql.Add("                    'N'")
        Sql.Add("                 end BLO_CH_STATUSOE,")
        Sql.Add("                 case")
        Sql.Add("                   when DADOS.GER_RE_QUANTIDADE > 0 and")
        Sql.Add("                        (DADOS.IPE_RE_QTDECONVERTIDA - DADOS.GER_RE_QUANTIDADE) > 0 then")
        Sql.Add("                    0")
        Sql.Add("                   else")
        Sql.Add("                    1")
        Sql.Add("                 end ORDEM_OE_INICIADA,")
        Sql.Add("                 DADOS.CTD_CH_DATA_HORIZONTE")
        Sql.Add("         ")
        Sql.Add("           from (select PED.ORG_TAB_IN_CODIGO ORG_TAB_IN_CODIGO,")
        Sql.Add("                         PED.ORG_PAD_IN_CODIGO ORG_PAD_IN_CODIGO,")
        Sql.Add("                         PED.ORG_IN_CODIGO ORG_IN_CODIGO,")
        Sql.Add("                         PED.ORG_TAU_ST_CODIGO ORG_TAU_ST_CODIGO,")
        Sql.Add("                         PED.SER_ST_CODIGO SER_ST_CODIGO,")
        Sql.Add("                         PED.PED_IN_CODIGO PED_IN_CODIGO,")
        Sql.Add("                         PED.FIL_IN_CODIGO FIL_IN_CODIGO,")
        Sql.Add("                         TPD.TPD_IN_CODIGO TPD_IN_CODIGO,")
        Sql.Add("                         TPD.TPD_ST_DESCRICAO TPD_ST_DESCRICAO,")
        Sql.Add("                         ITE.ITP_ST_SITUACAO PED_CH_STATUS,")
        Sql.Add("                         PED.PED_DT_EMISSAO PED_DT_EMISSAO,")
        Sql.Add("                         PED.CLI_TAB_IN_CODIGO CLI_TAB_IN_CODIGO,")
        Sql.Add("                         PED.CLI_PAD_IN_CODIGO CLI_PAD_IN_CODIGO,")
        Sql.Add("                         PED.CLI_IN_CODIGO CLI_IN_CODIGO,")
        Sql.Add("                         PED.CLI_TAU_ST_CODIGO CLI_TAU_ST_CODIGO,")
        Sql.Add("                         CLI.AGN_ST_NOME CLI_ST_NOME,")
        Sql.Add("                         MUN.UF_ST_SIGLA UF_ST_SIGLA,")
        Sql.Add("                         MUN.MUN_IN_CODIGO MUN_IN_CODIGO,")
        Sql.Add("                         MUN.MUN_ST_NOME MUN_ST_NOME,")
        Sql.Add("                         PED.COND_ST_CODIGO COND_ST_CODIGO,")
        Sql.Add("                         CON.COND_ST_NOME COND_ST_NOME,")
        Sql.Add("                         TRA.AGN_IN_CODIGO TRA_IN_CODIGO,")
        Sql.Add("                         TRA.AGN_ST_NOME TRA_ST_NOME,")
        Sql.Add("                         PRO.PRO_TAB_IN_CODIGO PRO_TAB_IN_CODIGO,")
        Sql.Add("                         PRO.PRO_PAD_IN_CODIGO PRO_PAD_IN_CODIGO,")
        Sql.Add("                         PRO.PRO_IN_CODIGO PRO_IN_CODIGO,")
        Sql.Add("                         PRO.GRU_TAB_IN_CODIGO GRU_TAB_IN_CODIGO,")
        Sql.Add("                         PRO.GRU_PAD_IN_CODIGO GRU_PAD_IN_CODIGO,")
        Sql.Add("                         PRO.GRU_IDE_ST_CODIGO GRU_IDE_ST_CODIGO,")
        Sql.Add("                         PRO.GRU_IN_CODIGO GRU_IN_CODIGO,")
        Sql.Add("                         PRO.GRU_IN_CODIGO SUB_GRUPO,")
        Sql.Add("                         PRO.PRO_ST_ALTERNATIVO PRO_ST_ALTERNATIVO,")
        Sql.Add("                         PRO.PRO_ST_DESCRICAO PRO_ST_DESCRICAO,")
        Sql.Add("                         ITE.UNI_ST_UNIDADE UNI_ST_UNIDADE,")
        Sql.Add("                         ITE.ITP_RE_QUANTIDADE ITP_RE_QUANTIDADE,")
        Sql.Add("                         ITE.ITP_IN_SEQUENCIA ITP_IN_SEQUENCIA,")
        Sql.Add("                         PRG.IPE_IN_SEQUENCIA IPE_IN_SEQUENCIA,")
        Sql.Add("                         PRG.IPE_RE_QUANTIDADE IPE_RE_QUANTIDADE,")
        Sql.Add("                         PRG.IPE_DT_DATAENTREGA IPE_DT_DATAENTREGA,")
        Sql.Add("                         PRG.IPE_DT_DATAEXPEDICAO IPE_DT_DATAEXPEDICAO,")
        Sql.Add("                         NVL((select sum(NVL(EXP.EXP_RE_QTDEFATURAR, 0))")
        Sql.Add("                               from VEN_EXPEDICAO EXP")
        Sql.Add("                              where EXP.ORG_TAB_IN_CODIGO =")
        Sql.Add("                                    PED.ORG_TAB_IN_CODIGO")
        Sql.Add("                                and EXP.ORG_PAD_IN_CODIGO =")
        Sql.Add("                                    PED.ORG_PAD_IN_CODIGO")
        Sql.Add("                                and EXP.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
        Sql.Add("                                and EXP.ORG_TAU_ST_CODIGO =")
        Sql.Add("                                    PED.ORG_TAU_ST_CODIGO")
        Sql.Add("                                and EXP.SER_ST_CODIGO = PED.SER_ST_CODIGO")
        Sql.Add("                                and EXP.PED_IN_CODIGO = PED.PED_IN_CODIGO")
        Sql.Add("                                and EXP.ITP_IN_SEQUENCIA = ITE.ITP_IN_SEQUENCIA")
        Sql.Add("                                and EXP.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA),")
        Sql.Add("                             0) GER_RE_QUANTIDADE,")
        Sql.Add("                         NVL((select sum(NVL(EXP1.EXP_RE_QTDEFATURAR, 0))")
        Sql.Add("                               from VEN_EXPEDICAO EXP1")
        Sql.Add("                               left join FS_ROMANEIO_OE_ITENS RIT")
        Sql.Add("                                 on RIT.ORG_TAB_IN_CODIGO =")
        Sql.Add("                                    EXP1.ORG_TAB_IN_CODIGO")
        Sql.Add("                                and RIT.ORG_PAD_IN_CODIGO =")
        Sql.Add("                                    EXP1.ORG_PAD_IN_CODIGO")
        Sql.Add("                                and RIT.ORG_IN_CODIGO = EXP1.ORG_IN_CODIGO")
        Sql.Add("                                and RIT.ORG_TAU_ST_CODIGO =")
        Sql.Add("                                    EXP1.ORG_TAU_ST_CODIGO")
        Sql.Add("                                and RIT.SEQ_TAB_IN_CODIGO =")
        Sql.Add("                                    EXP1.SEQ_TAB_IN_CODIGO")
        Sql.Add("                                and RIT.SEQ_IN_CODIGO = EXP1.SEQ_IN_CODIGO")
        Sql.Add("                                and RIT.EXP_IN_SEQUENCIA = EXP1.EXP_IN_SEQUENCIA")
        Sql.Add("                               left join FS_ROMANEIO_OE ROE")
        Sql.Add("                                 on ROE.COL_IN_ID = RIT.COL_IN_ID")
        Sql.Add("                              where EXP1.ORG_TAB_IN_CODIGO =")
        Sql.Add("                                    PED.ORG_TAB_IN_CODIGO")
        Sql.Add("                                and EXP1.ORG_PAD_IN_CODIGO =")
        Sql.Add("                                    PED.ORG_PAD_IN_CODIGO")
        Sql.Add("                                and EXP1.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
        Sql.Add("                                and EXP1.ORG_TAU_ST_CODIGO =")
        Sql.Add("                                    PED.ORG_TAU_ST_CODIGO")
        Sql.Add("                                and EXP1.SER_ST_CODIGO = PED.SER_ST_CODIGO")
        Sql.Add("                                and EXP1.PED_IN_CODIGO = PED.PED_IN_CODIGO")
        Sql.Add("                                and EXP1.ITP_IN_SEQUENCIA = ITE.ITP_IN_SEQUENCIA")
        Sql.Add("                                and EXP1.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                                and EXP1.EXP_CH_STATUS = 'N'")
        Sql.Add("                                and NVL(ROE.COL_CH_STATUS, 'N') = 'N'),")
        Sql.Add("                             0) GER_RE_QTDEDISPONIVEL,")
        Sql.Add("                         PED.PED_IN_FRETEPCONTA PED_IN_FRETEPCONTA,")
        Sql.Add("                         AGN.AGN_ST_NOME VEN_AGN_ST_NOME,")
        Sql.Add("                         AGN.AGN_IN_CODIGO VEN_AGN_IN_CODIGO,")
        Sql.Add("                         GRU.GRU_IN_CODIGO USU_IN_CODIGO,")
        Sql.Add("                         NVL(FPRG.IPE_CH_STATUS, 'L') IPE_CH_STATUS,")
        Sql.Add("                         NVL(FPE.PED_BO_PARCIAL, 'N') PED_BO_PARCIAL,")
        Sql.Add("                         NVL(GER.PED_IN_PRIORIDADE, 0) PED_IN_PRIORIDADE,")
        Sql.Add("                         (select J.GRU_IN_CODIGO")
        Sql.Add("                            from EST_PRODUTOS      F,")
        Sql.Add("                                 GLO_IDENTIFICADOR G,")
        Sql.Add("                                 EST_GRUPOS        H,")
        Sql.Add("                                 EST_GRUPOS        I,")
        Sql.Add("                                 EST_GRUPOS        J")
        Sql.Add("                           where F.GRU_TAB_IN_CODIGO = G.TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = G.PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = G.IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_TAB_IN_CODIGO = H.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = H.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = H.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_IN_CODIGO = H.GRU_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_TAB_IN_CODIGO = I.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_PAD_IN_CODIGO = I.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IDE_ST_CODIGO = I.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IN_CODIGO = I.GRU_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_TAB_IN_CODIGO = J.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_PAD_IN_CODIGO = J.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IDE_ST_CODIGO = J.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IN_CODIGO = J.GRU_IN_CODIGO")
        Sql.Add("                             and F.PRO_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
        Sql.Add("                             and F.PRO_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
        Sql.Add("                             and F.PRO_IN_CODIGO = PRO.PRO_IN_CODIGO")
        Sql.Add("                           group by J.GRU_IN_CODIGO) GRUPO,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'B2B' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end B2B,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'B2C' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end B2C,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'EXPORTAÇÃO' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end EXPORTACAO,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'OUTROS' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end OUTROS,")
        Sql.Add("                         ")
        Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
        Sql.Add("                           when 'HIBRIDO' then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end HIBRIDO,")
        Sql.Add("                         ")
        Sql.Add("                         case")
        Sql.Add("                           when UPPER(trim(MER.FCC_ST_DESCRICAO)) not in")
        Sql.Add("                                ('HIBRIDO', 'OUTROS', 'EXPORTAÇÃO', 'B2C', 'B2B') then")
        Sql.Add("                            'S'")
        Sql.Add("                           else")
        Sql.Add("                            'N'")
        Sql.Add("                         end INDEFINIDO,")
        Sql.Add("                         case ITE.ITP_ST_SITUACAO")
        Sql.Add("                           when 'P' then")
        Sql.Add("                            'Pedido em Aberto'")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            'Pedido Bloqueado'")
        Sql.Add("                           when 'A' then")
        Sql.Add("                            'Pedido Aprovado'")
        Sql.Add("                           when 'F' then")
        Sql.Add("                            'Pedido Faturado Totalmente'")
        Sql.Add("                           when 'R' then")
        Sql.Add("                            'Pedido Faturado Parcialmente'")
        Sql.Add("                           when 'C' then")
        Sql.Add("                            'Pedido Cancelado'")
        Sql.Add("                           when 'V' then")
        Sql.Add("                            'Documento Vencido'")
        Sql.Add("                           when 'E' then")
        Sql.Add("                            'Documento Encerrado'")
        Sql.Add("                         end PED_CH_SITUACAO,")
        Sql.Add("                         ")
        Sql.Add("                         case ITE.ITP_ST_SITUACAO")
        Sql.Add("                           when 'P' then")
        Sql.Add("                            'Pedido em Aberto'")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            'Pedido Bloqueado'")
        Sql.Add("                           when 'A' then")
        Sql.Add("                            'Pedido em Aberto'")
        Sql.Add("                           when 'F' then")
        Sql.Add("                            'Pedido Faturado Totalmente'")
        Sql.Add("                           when 'R' then")
        Sql.Add("                            'Pedido Faturado Parcialmente'")
        Sql.Add("                           when 'C' then")
        Sql.Add("                            'Pedido Cancelado'")
        Sql.Add("                           when 'V' then")
        Sql.Add("                            'Documento Vencido'")
        Sql.Add("                           when 'E' then")
        Sql.Add("                            'Documento Encerrado'")
        Sql.Add("                         end PED_ST_SITUACAO,")
        Sql.Add("                         ")
        Sql.Add("                         cast(case NVL(GER.PED_IN_PRIORIDADE, 0)")
        Sql.Add("                                when 9 then")
        Sql.Add("                                 '9-Exportação'")
        Sql.Add("                                when 3 then")
        Sql.Add("                                 '3-Prioridade Alta'")
        Sql.Add("                                when 2 then")
        Sql.Add("                                 '2-Prioridade Média'")
        Sql.Add("                                when 1 then")
        Sql.Add("                                 '1-Prioridade Baixa'")
        Sql.Add("                                when 0 then")
        Sql.Add("                                 '0-Prioridade Não definida'")
        Sql.Add("                              end as varchar2(30)) PRIORIDADE,")
        Sql.Add("                         ")
        Sql.Add("                         case NVL(FPRG.IPE_CH_STATUS, 'L')")
        Sql.Add("                           when 'L' then")
        Sql.Add("                            'Liberado'")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            'Bloqueado'")
        Sql.Add("                         end IPE_ST_STATUS,")
        Sql.Add("                         ")
        Sql.Add("                         case PED.PED_IN_FRETEPCONTA")
        Sql.Add("                           when 1 then")
        Sql.Add("                            'CIF'")
        Sql.Add("                           when 2 then")
        Sql.Add("                            'FOB'")
        Sql.Add("                           when 3 then")
        Sql.Add("                            'Terceiros'")
        Sql.Add("                           when 4 then")
        Sql.Add("                            'Sem Frete'")
        Sql.Add("                           when 5 then")
        Sql.Add("                            'Remetente Próprio'")
        Sql.Add("                           when 6 then")
        Sql.Add("                            'Destinatário Próprio'")
        Sql.Add("                         end PED_ST_TIPOFRETE,")
        Sql.Add("                         ")
        Sql.Add("                         NIV.B2B_IN_NIVEL,")
        Sql.Add("                         NIV.B2C_IN_NIVEL,")
        Sql.Add("                         NIV.EXP_IN_NIVEL,")
        Sql.Add("                         NIV.OUT_IN_NIVEL,")
        Sql.Add("                         ITE.EMB_TAB_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_PAD_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_UNI_TAB_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_UNI_PAD_IN_CODIGO,")
        Sql.Add("                         ITE.EMB_UNI_ST_UNIDADE,")
        Sql.Add("                         EMB.PRO_ST_DESCRICAOPDV EMB_ST_DESCRICAO,")
        Sql.Add("                         PRDT.IPE_DT_DATAENTREGA DATA_CLIENTE,")
        Sql.Add("                         PRG.IPE_CH_SITUACAO,")
        Sql.Add("                         NVL(FPE.PED_BO_MIN3PC, 'N') MINIMO_3PC,")
        Sql.Add("                         case PRG.IPE_CH_TIPOENTREGA")
        Sql.Add("                           when 'A' then")
        Sql.Add("                            'Até a Data'")
        Sql.Add("                           when 'S' then")
        Sql.Add("                            'Somente na Data'")
        Sql.Add("                           when 'P' then")
        Sql.Add("                            'Após a Data'")
        Sql.Add("                         end IPE_ST_TIPOENTREGA,")
        Sql.Add("                         ")
        Sql.Add("                         (ITE.ITP_RE_VALORUNITARIO -")
        Sql.Add("                         (ITE.ITP_RE_VALORDESCRATEIO / ITE.ITP_RE_QUANTIDADE)) ITP_RE_VALORUNITARIO,")
        Sql.Add("                         PRG.IPE_RE_QTDECONVERTIDA,")
        Sql.Add("                         PRO.UNI_ST_UNIDADE UNI_ST_ORIGINAL,")
        Sql.Add("                         PRG.IPE_RE_QTDEFATURADA,")
        Sql.Add("                         PRG.IPE_RE_QUANTIDADE - PRG.IPE_RE_QTDEFATURADA IPE_RE_QTDESALDO,")
        Sql.Add("                         CPT.CTD_CH_DATA_HORIZONTE")
        Sql.Add("                  ")
        Sql.Add("                    from VEN_PEDIDOVENDA PED")
        Sql.Add("                    left join FS_VEN_TIPODOCUMENTO_CLASSIFICADOR CLA")
        Sql.Add("                      on CLA.TPD_TAB_IN_CODIGO = PED.TPD_TAB_IN_CODIGO")
        Sql.Add("                     and CLA.TPD_PAD_IN_CODIGO = PED.TPD_PAD_IN_CODIGO")
        Sql.Add("                     and CLA.TPD_IN_CODIGO = PED.TPD_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_TB_CLASSIFICADORES MER")
        Sql.Add("                      on MER.FTT_IN_CODIGO = CLA.FTT_IN_CODIGO")
        Sql.Add("                     and MER.FTC_IN_CODIGO = CLA.FTC_IN_CODIGO")
        Sql.Add("                     and MER.FCC_IN_CODIGO = CLA.FCC_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_PEDIDOVENDA FPE")
        Sql.Add("                      on FPE.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and FPE.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and FPE.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
        Sql.Add("                     and FPE.ORG_TAU_ST_CODIGO = PED.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and FPE.SER_ST_CODIGO = PED.SER_ST_CODIGO")
        Sql.Add("                     and FPE.PED_IN_CODIGO = PED.PED_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join GLO_AGENTES AGN")
        Sql.Add("                      on PED.REP_TAB_IN_CODIGO = AGN.AGN_TAB_IN_CODIGO")
        Sql.Add("                     and PED.REP_PAD_IN_CODIGO = AGN.AGN_PAD_IN_CODIGO")
        Sql.Add("                     and PED.REP_IN_CODIGO = AGN.AGN_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join GLO_GRUPO_USUARIO GRU")
        Sql.Add("                      on GRU.GRU_IN_CODIGO = :PUSU_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join GLO_GRUPO_USUARIOCMPESP NIV")
        Sql.Add("                      on NIV.GRU_IN_CODIGO = GRU.GRU_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    join GLO_CONDPAGTO CON")
        Sql.Add("                      on CON.COND_TAB_IN_CODIGO = PED.COND_TAB_IN_CODIGO")
        Sql.Add("                     and CON.COND_PAD_IN_CODIGO = PED.COND_PAD_IN_CODIGO")
        Sql.Add("                     and CON.COND_ST_CODIGO = PED.COND_ST_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    join VEN_TIPODOCUMENTO TPD")
        Sql.Add("                      on TPD.TPD_TAB_IN_CODIGO = PED.TPD_TAB_IN_CODIGO")
        Sql.Add("                     and TPD.TPD_PAD_IN_CODIGO = PED.TPD_PAD_IN_CODIGO")
        Sql.Add("                     and TPD.TPD_IN_CODIGO = PED.TPD_IN_CODIGO")
        Sql.Add("                     and TPD.TPD_CH_TIPODOCUMENTO = 'P'")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_VEN_TIPODOCUMENTO CPT")
        Sql.Add("                      on CPT.TPD_TAB_IN_CODIGO = TPD.TPD_TAB_IN_CODIGO")
        Sql.Add("                     and CPT.TPD_PAD_IN_CODIGO = TPD.TPD_PAD_IN_CODIGO")
        Sql.Add("                     and CPT.TPD_IN_CODIGO = TPD.TPD_IN_CODIGO")
        Sql.Add("                  --- CLIENTE DO PEDIDO")
        Sql.Add("                    join GLO_AGENTES_ID CLD")
        Sql.Add("                      on CLD.AGN_TAB_IN_CODIGO = PED.CLI_TAB_IN_CODIGO")
        Sql.Add("                     and CLD.AGN_PAD_IN_CODIGO = PED.CLI_PAD_IN_CODIGO")
        Sql.Add("                     and CLD.AGN_IN_CODIGO = PED.CLI_IN_CODIGO")
        Sql.Add("                     and CLD.AGN_TAU_ST_CODIGO = PED.CLI_TAU_ST_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    join GLO_AGENTES CLI")
        Sql.Add("                      on CLI.AGN_TAB_IN_CODIGO = CLD.AGN_TAB_IN_CODIGO")
        Sql.Add("                     and CLI.AGN_PAD_IN_CODIGO = CLD.AGN_PAD_IN_CODIGO")
        Sql.Add("                     and CLI.AGN_IN_CODIGO = CLD.AGN_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join GLO_MUNICIPIO MUN")
        Sql.Add("                      on MUN.UF_ST_SIGLA = CLI.UF_ST_SIGLA")
        Sql.Add("                     and MUN.MUN_IN_CODIGO = CLI.MUN_IN_CODIGO")
        Sql.Add("                  --- ITENS DO PEDIDO")
        Sql.Add("                    join VEN_ITEMPEDIDOVENDA ITE")
        Sql.Add("                      on ITE.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and ITE.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and ITE.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
        Sql.Add("                     and ITE.PED_IN_CODIGO = PED.PED_IN_CODIGO")
        Sql.Add("                  --- EMBALAGEM DO PRODUTO")
        Sql.Add("                    left join EST_PRODUTOS EMB")
        Sql.Add("                      on EMB.PRO_TAB_IN_CODIGO = ITE.EMB_TAB_IN_CODIGO")
        Sql.Add("                     and EMB.PRO_PAD_IN_CODIGO = ITE.EMB_PAD_IN_CODIGO")
        Sql.Add("                     and EMB.PRO_IN_CODIGO = ITE.EMB_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join VEN_PEDPROGENTREGA PRG")
        Sql.Add("                      on PRG.ORG_TAB_IN_CODIGO = ITE.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and PRG.ORG_PAD_IN_CODIGO = ITE.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and PRG.ORG_IN_CODIGO = ITE.ORG_IN_CODIGO")
        Sql.Add("                     and PRG.ORG_TAU_ST_CODIGO = ITE.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and PRG.SER_ST_CODIGO = ITE.SER_ST_CODIGO")
        Sql.Add("                     and PRG.PED_IN_CODIGO = ITE.PED_IN_CODIGO")
        Sql.Add("                     and PRG.ITP_IN_SEQUENCIA = ITE.ITP_IN_SEQUENCIA")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_PEDPROGENTREGA FPRG")
        Sql.Add("                      on FPRG.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and FPRG.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and FPRG.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                     and FPRG.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and FPRG.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                     and FPRG.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                     and FPRG.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                     and FPRG.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_PEDPROGENTREGA_DATACLI PRDT")
        Sql.Add("                      on PRDT.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and PRDT.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and PRDT.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                     and PRDT.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and PRDT.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                     and PRDT.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                     and PRDT.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                     and PRDT.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                  ")
        Sql.Add("                    join EST_PRODUTOS PRO")
        Sql.Add("                      on PRO.PRO_TAB_IN_CODIGO = ITE.PRO_TAB_IN_CODIGO")
        Sql.Add("                     and PRO.PRO_PAD_IN_CODIGO = ITE.PRO_PAD_IN_CODIGO")
        Sql.Add("                     and PRO.PRO_IN_CODIGO = ITE.PRO_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join VEN_ITEMPEDI_VEN_ITEMNOT NFI")
        Sql.Add("                      on NFI.PE_ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and NFI.PE_ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and NFI.PE_ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                     and NFI.PE_ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and NFI.PE_SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                     and NFI.PE_PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                     and NFI.PE_ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                     and NFI.PE_IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                  ")
        Sql.Add("                  --- TRANSPORTADOR")
        Sql.Add("                    left join GLO_AGENTES TRA")
        Sql.Add("                      on TRA.AGN_TAB_IN_CODIGO = PED.TRA_TAB_IN_CODIGO")
        Sql.Add("                     and TRA.AGN_PAD_IN_CODIGO = PED.TRA_PAD_IN_CODIGO")
        Sql.Add("                     and TRA.AGN_IN_CODIGO = PED.TRA_IN_CODIGO")
        Sql.Add("                  ")
        Sql.Add("                    left join FS_PEDIDOVENDAGER GER")
        Sql.Add("                      on GER.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                     and GER.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                     and GER.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                     and GER.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                     and GER.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                     and GER.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                     and GER.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                     and GER.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                   where PED.FIL_IN_CODIGO = :PFIL_IN_CODIGO")
        Sql.Add("                     and PED.PED_CH_SITUACAO not in ('B', 'C', 'V', 'E')")
        Sql.Add("                        ")
        Sql.Add("                     and ((:PITP_ST_PEDIDOCLIENTE is null and 1 = 1) or")
        Sql.Add("                         (:PITP_ST_PEDIDOCLIENTE is not null and")
        Sql.Add("                         ITE.ITP_ST_PEDIDOCLIENTE = :PITP_ST_PEDIDOCLIENTE))")
        Sql.Add("                        ")
        Sql.Add("                     and PED.REP_IN_CODIGO =")
        Sql.Add("                         NVL(:PREP_IN_CODIGO, PED.REP_IN_CODIGO)")
        Sql.Add("                        ")
        Sql.Add("                     and PED.TPD_IN_CODIGO =")
        Sql.Add("                         NVL(:PTPD_IN_CODIGO, PED.TPD_IN_CODIGO)")
        Sql.Add("                        ")
        Sql.Add("                     and PRG.IPE_DT_DATAENTREGA between")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PENTREGA_INICIAL), '01/01/2022') ||")
        Sql.Add("                                 ' 00:00:00',")
        Sql.Add("                                 'dd/mm/yyyy hh24:mi:ss') and")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PENTREGA_FINAL), '01/01/2099') ||")
        Sql.Add("                                 ' 23:59:59',")
        Sql.Add("                                 'dd/mm/yyyy HH24:mi:ss')")
        Sql.Add("                     and NVL(PRDT.IPE_DT_DATAENTREGA, TRUNC(sysdate)) between")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PDATA_CLIENTE_INICIAL),")
        Sql.Add("                                     '01/01/2022') || ' 00:00:00',")
        Sql.Add("                                 'dd/mm/yyyy hh24:mi:ss') and")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PDATA_CLIENTE_FINAL), '01/01/2099') ||")
        Sql.Add("                                 ' 23:59:59',")
        Sql.Add("                                 'dd/mm/yyyy HH24:mi:ss')")
        Sql.Add("                     and PED.PED_DT_EMISSAO between")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PEMISSAO_INICIAL), '01/01/2022') ||")
        Sql.Add("                                 '00:00:00',")
        Sql.Add("                                 'dd/mm/yyyy hh24:mi:ss') and")
        Sql.Add("                         TO_DATE(NVL(TO_CHAR(:PEMISSAO_FINAL), '01/01/2099') ||")
        Sql.Add("                                 '23:59:59',")
        Sql.Add("                                 'dd/mm/yyyy HH24:mi:ss')")
        Sql.Add("                     and PED.PED_IN_CODIGO between NVL(:PPEDIDO_INICIAL, 0) and")
        Sql.Add("                         NVL(:PPEDIDO_FINAL, 99999999)")
        Sql.Add("                     and PRO.PRO_IN_CODIGO between NVL(:PITEM_INICIAL, 0) and")
        Sql.Add("                         NVL(:PITEM_FINAL, 99999999)")
        Sql.Add("                     and exists")
        Sql.Add("                   (select J.GRU_IN_CODIGO")
        Sql.Add("                            from EST_PRODUTOS      F,")
        Sql.Add("                                 GLO_IDENTIFICADOR G,")
        Sql.Add("                                 EST_GRUPOS        H,")
        Sql.Add("                                 EST_GRUPOS        I,")
        Sql.Add("                                 EST_GRUPOS        J")
        Sql.Add("                           where F.GRU_TAB_IN_CODIGO = G.TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = G.PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = G.IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_TAB_IN_CODIGO = H.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = H.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = H.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_IN_CODIGO = H.GRU_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_TAB_IN_CODIGO = I.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_PAD_IN_CODIGO = I.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IDE_ST_CODIGO = I.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IN_CODIGO = I.GRU_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_TAB_IN_CODIGO = J.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_PAD_IN_CODIGO = J.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IDE_ST_CODIGO = J.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IN_CODIGO = J.GRU_IN_CODIGO")
        Sql.Add("                             and F.PRO_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
        Sql.Add("                             and F.PRO_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
        Sql.Add("                             and F.PRO_IN_CODIGO = PRO.PRO_IN_CODIGO")
        Sql.Add("                             and J.GRU_IN_CODIGO between NVL(:PGRUPO_INICIAL, 0) and")
        Sql.Add("                                 NVL(:PGRUPO_FINAL, 999999)")
        Sql.Add("                           group by J.GRU_IN_CODIGO)")
        Sql.Add("                        ")
        Sql.Add("                     and exists")
        Sql.Add("                   (select D.GRU_IN_CODIGO")
        Sql.Add("                            from EST_PRODUTOS A")
        Sql.Add("                            join EST_GRUPOS B")
        Sql.Add("                              on B.GRU_TAB_IN_CODIGO = A.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and B.GRU_PAD_IN_CODIGO = A.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and B.GRU_IDE_ST_CODIGO = A.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and B.GRU_IN_CODIGO = A.GRU_IN_CODIGO")
        Sql.Add("                            join EST_GRUPOS C")
        Sql.Add("                              on C.GRU_TAB_IN_CODIGO = B.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and C.GRU_PAD_IN_CODIGO = B.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and C.GRU_IDE_ST_CODIGO = B.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and C.GRU_IN_CODIGO = B.GRU_IN_CODIGO")
        Sql.Add("                            join EST_GRUPOS D")
        Sql.Add("                              on D.GRU_TAB_IN_CODIGO = C.PAI_GRU_TAB_IN_CODIGO")
        Sql.Add("                             and D.GRU_PAD_IN_CODIGO = C.PAI_GRU_PAD_IN_CODIGO")
        Sql.Add("                             and D.GRU_IDE_ST_CODIGO = C.PAI_GRU_IDE_ST_CODIGO")
        Sql.Add("                             and D.GRU_IN_CODIGO = C.PAI_GRU_IN_CODIGO")
        Sql.Add("                           where A.PRO_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
        Sql.Add("                             and A.PRO_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
        Sql.Add("                             and A.PRO_IN_CODIGO = PRO.PRO_IN_CODIGO")
        Sql.Add("                             and D.GRU_IN_CODIGO between")
        Sql.Add("                                 NVL(:PSUBGRUPO_INICIAL, 0) and")
        Sql.Add("                                 NVL(:PSUBGRUPO_FINAL, 999999)")
        Sql.Add("                           group by D.GRU_IN_CODIGO)")
        Sql.Add("                        ")
        Sql.Add("                     and PED.CLI_IN_CODIGO between NVL(:PCLIENTE_INICIAL, 0) and")
        Sql.Add("                         NVL(:PCLIENTE_FINAL, 999999)")
        Sql.Add("                        ")
        Sql.Add("                     and ((:PNOTA_INICIAL is null and 1 = 1) or")
        Sql.Add("                         PED.PED_IN_CODIGO in")
        Sql.Add("                         (select IT.PE_PED_IN_CODIGO")
        Sql.Add("                             from VEN_NOTAFISCAL NF")
        Sql.Add("                             join VEN_ITEMPEDI_VEN_ITEMNOT IT")
        Sql.Add("                               on IT.NF_ORG_TAB_IN_CODIGO = NF.ORG_TAB_IN_CODIGO")
        Sql.Add("                              and IT.NF_ORG_PAD_IN_CODIGO = NF.ORG_PAD_IN_CODIGO")
        Sql.Add("                              and IT.NF_ORG_IN_CODIGO = NF.ORG_IN_CODIGO")
        Sql.Add("                              and IT.NF_ORG_TAU_ST_CODIGO = NF.ORG_TAU_ST_CODIGO")
        Sql.Add("                              and IT.NF_SEQ_TAB_IN_CODIGO = NF.SEQ_TAB_IN_CODIGO")
        Sql.Add("                              and IT.NF_SEQ_IN_CODIGO = NF.SEQ_IN_CODIGO")
        Sql.Add("                              and IT.NF_NOT_IN_CODIGO = NF.NOT_IN_CODIGO")
        Sql.Add("                            where NF.NOT_IN_NUMERO between :PNOTA_INICIAL and")
        Sql.Add("                                  :PNOTA_FINAL")
        Sql.Add("                              and IT.PE_ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                              and IT.PE_ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                              and IT.PE_ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                              and IT.PE_ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                              and IT.PE_SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                              and IT.PE_PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                              and IT.PE_ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                              and IT.PE_IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                            group by IT.PE_PED_IN_CODIGO))")
        Sql.Add("                        ")
        Sql.Add("                     and NVL(GER.PED_IN_PRIORIDADE, 0) between")
        Sql.Add("                         NVL(:PPRIORIDADE, 0) and NVL(:PPRIORIDADE, 9)")
        Sql.Add("                        ")
        Sql.Add("                     and (case NVL(FPRG.IPE_CH_STATUS, 'L')")
        Sql.Add("                           when 'L' then")
        Sql.Add("                            'Liberado'")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            'Bloqueado'")
        Sql.Add("                         end = :PSTATUSENTREGA or")
        Sql.Add("                         NVL(:PSTATUSENTREGA, 'S') = 'S')")
        Sql.Add("                        ")
        Sql.Add("                     and ((case ITE.ITP_ST_SITUACAO")
        Sql.Add("                           when 'P' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto Pedido Bloqueado',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'A' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'R' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto Pedido Faturado Parcialmente',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'F' then")
        Sql.Add("                            'Pedido Faturado Totalmente'")
        Sql.Add("                           when 'C' then")
        Sql.Add("                            'Pedido Cancelado'")
        Sql.Add("                           when 'V' then")
        Sql.Add("                            'Documento Vencido'")
        Sql.Add("                           when 'E' then")
        Sql.Add("                            'Documento Encerrado'")
        Sql.Add("                         end like '%' || :PSTATUS || '%') or")
        Sql.Add("                         NVL(:PSTATUS, 'S') = 'S')")
        Sql.Add("                        ")
        Sql.Add("                     and NVL(FPE.PED_BO_PARCIAL, 'N') =")
        Sql.Add("                         DECODE(NVL(:PPARCIAL, 'T'),")
        Sql.Add("                                'T',")
        Sql.Add("                                NVL(FPE.PED_BO_PARCIAL, 'N'),")
        Sql.Add("                                NVL(:PPARCIAL, 'T'))")
        Sql.Add("                        ")
        Sql.Add("                     and GRU.GRU_IN_CODIGO = :PUSU_IN_CODIGO")
        Sql.Add("                        ")
        Sql.Add("                     and ((:PIPE_IN_SEQUENCIA is null and 1 = 1) or")
        Sql.Add("                         (:PIPE_IN_SEQUENCIA is not null and")
        Sql.Add("                         PRG.IPE_IN_SEQUENCIA = :PIPE_IN_SEQUENCIA))")
        Sql.Add("                        ")
        Sql.Add("                     and ((:PSTATUSOE is null and 1 = 1) or")
        Sql.Add("                         (exists")
        Sql.Add("                          (select 1")
        Sql.Add("                              from VEN_EXPEDICAO EXP")
        Sql.Add("                             where EXP.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                               and EXP.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                               and EXP.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                               and EXP.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                               and EXP.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                               and EXP.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                               and EXP.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                               and EXP.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                               and case EXP.EXP_CH_STATUS")
        Sql.Add("                                     when 'N' then")
        Sql.Add("                                      'Aguardando Separação'")
        Sql.Add("                                     when 'B' then")
        Sql.Add("                                      'Bloqueado'")
        Sql.Add("                                     when 'L' then")
        Sql.Add("                                      'Liberadas para faturamento'")
        Sql.Add("                                     when 'F' then")
        Sql.Add("                                      'Faturado'")
        Sql.Add("                                     when 'C' then")
        Sql.Add("                                      'Cancelado'")
        Sql.Add("                                   end = :PSTATUSOE)))")
        Sql.Add("                  ")
        Sql.Add("                   group by PED.ORG_TAB_IN_CODIGO,")
        Sql.Add("                            PED.ORG_PAD_IN_CODIGO,")
        Sql.Add("                            PED.ORG_IN_CODIGO,")
        Sql.Add("                            PED.ORG_TAU_ST_CODIGO,")
        Sql.Add("                            PED.SER_ST_CODIGO,")
        Sql.Add("                            PED.PED_IN_CODIGO,")
        Sql.Add("                            PED.FIL_IN_CODIGO,")
        Sql.Add("                            TPD.TPD_IN_CODIGO,")
        Sql.Add("                            TPD.TPD_ST_DESCRICAO,")
        Sql.Add("                            PED.PED_DT_EMISSAO,")
        Sql.Add("                            PED.PED_DT_EMISSAO,")
        Sql.Add("                            PED.CLI_TAB_IN_CODIGO,")
        Sql.Add("                            PED.CLI_PAD_IN_CODIGO,")
        Sql.Add("                            PED.CLI_IN_CODIGO,")
        Sql.Add("                            PED.CLI_TAU_ST_CODIGO,")
        Sql.Add("                            CLI.AGN_ST_NOME,")
        Sql.Add("                            MUN.UF_ST_SIGLA,")
        Sql.Add("                            MUN.MUN_IN_CODIGO,")
        Sql.Add("                            MUN.MUN_ST_NOME,")
        Sql.Add("                            PED.COND_ST_CODIGO,")
        Sql.Add("                            CON.COND_ST_NOME,")
        Sql.Add("                            TRA.AGN_IN_CODIGO,")
        Sql.Add("                            TRA.AGN_ST_NOME,")
        Sql.Add("                            PRO.PRO_TAB_IN_CODIGO,")
        Sql.Add("                            PRO.PRO_PAD_IN_CODIGO,")
        Sql.Add("                            PRO.PRO_IN_CODIGO,")
        Sql.Add("                            PRO.GRU_TAB_IN_CODIGO,")
        Sql.Add("                            PRO.GRU_PAD_IN_CODIGO,")
        Sql.Add("                            PRO.GRU_IDE_ST_CODIGO,")
        Sql.Add("                            PRO.GRU_IN_CODIGO,")
        Sql.Add("                            PRO.PRO_ST_ALTERNATIVO,")
        Sql.Add("                            PRO.PRO_ST_DESCRICAO,")
        Sql.Add("                            ITE.UNI_ST_UNIDADE,")
        Sql.Add("                            ITE.ITP_RE_QUANTIDADE,")
        Sql.Add("                            ITE.ITP_IN_SEQUENCIA,")
        Sql.Add("                            ITE.ITP_ST_SITUACAO,")
        Sql.Add("                            ITE.ITP_RE_VALORUNITARIO,")
        Sql.Add("                            ITE.ITP_RE_VALORDESCRATEIO,")
        Sql.Add("                            PRG.IPE_IN_SEQUENCIA,")
        Sql.Add("                            PRG.IPE_RE_QUANTIDADE,")
        Sql.Add("                            PRG.IPE_DT_DATAENTREGA,")
        Sql.Add("                            PRG.IPE_RE_QTDECONVERTIDA,")
        Sql.Add("                            PRG.IPE_DT_DATAEXPEDICAO,")
        Sql.Add("                            AGN.AGN_ST_NOME,")
        Sql.Add("                            AGN.AGN_IN_CODIGO,")
        Sql.Add("                            GRU.GRU_IN_CODIGO,")
        Sql.Add("                            GRU.GRU_ST_NOME,")
        Sql.Add("                            PED.PED_CH_SITUACAO,")
        Sql.Add("                            GER.PED_IN_PRIORIDADE,")
        Sql.Add("                            GER.PED_IN_CODIGO,")
        Sql.Add("                            FPRG.IPE_CH_STATUS,")
        Sql.Add("                            FPE.PED_BO_PARCIAL,")
        Sql.Add("                            PED.PED_IN_FRETEPCONTA,")
        Sql.Add("                            MER.FCC_ST_DESCRICAO,")
        Sql.Add("                            NIV.B2B_IN_NIVEL,")
        Sql.Add("                            NIV.B2C_IN_NIVEL,")
        Sql.Add("                            NIV.EXP_IN_NIVEL,")
        Sql.Add("                            NIV.OUT_IN_NIVEL,")
        Sql.Add("                            ITE.EMB_TAB_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_PAD_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_UNI_TAB_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_UNI_PAD_IN_CODIGO,")
        Sql.Add("                            ITE.EMB_UNI_ST_UNIDADE,")
        Sql.Add("                            EMB.PRO_ST_DESCRICAOPDV,")
        Sql.Add("                            PRDT.IPE_DT_DATAENTREGA,")
        Sql.Add("                            PRG.IPE_CH_SITUACAO,")
        Sql.Add("                            FPE.PED_BO_MIN3PC,")
        Sql.Add("                            PRG.IPE_CH_TIPOENTREGA,")
        Sql.Add("                            ITE.ITP_RE_QTDECONVERTIDA,")
        Sql.Add("                            PRO.UNI_ST_UNIDADE,")
        Sql.Add("                            PRG.IPE_RE_QTDEFATURADA,")
        Sql.Add("                            CPT.CTD_CH_DATA_HORIZONTE) DADOS")
        Sql.Add("         ")
        Sql.Add("          where ((DADOS.B2B =")
        Sql.Add("                DECODE(:PB2B, 'N', DECODE(DADOS.B2B, 'N', 'S', 'N'), 'S') or")
        Sql.Add("                DADOS.B2C =")
        Sql.Add("                DECODE(:PB2C, 'N', DECODE(DADOS.B2C, 'N', 'S', 'N'), 'S') or")
        Sql.Add("                DADOS.EXPORTACAO =")
        Sql.Add("                DECODE(:PEXPORTACAO,")
        Sql.Add("                         'N',")
        Sql.Add("                         DECODE(DADOS.EXPORTACAO, 'N', 'S', 'N'),")
        Sql.Add("                         'S') or")
        Sql.Add("                DADOS.OUTROS = DECODE(:POUTROS,")
        Sql.Add("                                        'N',")
        Sql.Add("                                        DECODE(DADOS.OUTROS, 'N', 'S', 'N'),")
        Sql.Add("                                        'S') or")
        Sql.Add("                DADOS.HIBRIDO = DECODE(:PHIBRIDO,")
        Sql.Add("                                         'N',")
        Sql.Add("                                         DECODE(DADOS.HIBRIDO, 'N', 'S', 'N'),")
        Sql.Add("                                         'S') or")
        Sql.Add("                DADOS.INDEFINIDO =")
        Sql.Add("                DECODE(:PINDEFINIDO,")
        Sql.Add("                         'N',")
        Sql.Add("                         DECODE(DADOS.INDEFINIDO, 'N', 'S', 'N'),")
        Sql.Add("                         'S') or :PTODOS = 'S'))) T")
        Sql.Add(" ")
        Sql.Add("  where T.INDEFINIDO = 'N'")
        Sql.Add("    and T.GER_RE_QUANTIDADE < T.IPE_RE_QUANTIDADE")
        Sql.Add("       ")
        Sql.Add("    and (NVL(T.CTD_CH_DATA_HORIZONTE, 'N') = 'N' or")
        Sql.Add("        (T.DATA_CLIENTE <=")
        Sql.Add("        TRUNC(sysdate +")
        Sql.Add("                FS_PCK_APT_NEW.FNC_OBTEM_DIAS_HORIZONTE(PCK_MEGA.ACHAPADRAODATABELA(FIL       => T.FIL_IN_CODIGO,")
        Sql.Add("                                                                                    TAB       => 100,")
        Sql.Add("                                                                                    DATAATUAL => sysdate),")
        Sql.Add("                                                        T.PRO_IN_CODIGO))))")
        Sql.Add("       ")
        Sql.Add("    and ((T.B2B = 'S' and T.B2B_IN_NIVEL >= 2) or")
        Sql.Add("        (T.B2C = 'S' and T.B2C_IN_NIVEL >= 2) or")
        Sql.Add("        (T.EXPORTACAO = 'S' and T.EXP_IN_NIVEL >= 2) or")
        Sql.Add("        (T.OUTROS = 'S' and T.OUT_IN_NIVEL >= 2))")
        Sql.Add("  order by T.PED_IN_PRIORIDADE desc,")
        Sql.Add("           TO_NUMBER(TO_CHAR(T.IPE_DT_DATAEXPEDICAO, 'YYYYMMDD')),")
        Sql.Add("           T.PED_IN_CODIGO,")
        Sql.Add("           T.ORDEM_OE_INICIADA,")
        Sql.Add("           T.ITP_IN_SEQUENCIA,")
        Sql.Add("           T.IPE_IN_SEQUENCIA")
      End With

      With Cl_Programacao
        Name         = "Cl_Programacao"
        TableName    = "VEN_PEDPROGENTREGA"
        PkFields     = "ORG_TAB_IN_CODIGO;ORG_PAD_IN_CODIGO;ORG_IN_CODIGO;ORG_TAU_ST_CODIGO;SER_ST_CODIGO;PED_IN_CODIGO;ITP_IN_SEQUENCIA;IPE_IN_SEQUENCIA"
        Close
        SQL.Clear
        SQL.Add("SELECT *                                       ")
        SQL.Add("  FROM VEN_PEDPROGENTREGA                      ")
        SQL.Add(" WHERE ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO ")
        SQL.Add("   AND ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO ")
        SQL.Add("   AND ORG_IN_CODIGO     = :pORG_IN_CODIGO     ")
        SQL.Add("   AND ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO ")
        SQL.Add("   AND SER_ST_CODIGO     = :pSER_ST_CODIGO     ")
        SQL.Add("   AND PED_IN_CODIGO     = :pPED_IN_CODIGO     ")
        SQL.Add("   AND ITP_IN_SEQUENCIA  = :pITP_IN_SEQUENCIA  ")
        SQL.Add("   AND IPE_IN_SEQUENCIA  = :pIPE_IN_SEQUENCIA  ")
      End With

      With Cl_DadosProgramadas
        Name         = "Cl_QtdeProgramada"
        TableName    = "DUAL"
        Close
        SQL.Clear
        SQL.Add("SELECT NVL((SELECT MAX(X.IPE_IN_SEQUENCIA)                                          ")
        SQL.Add("              FROM VEN_PEDPROGENTREGA X                                             ")
        SQL.Add("             WHERE X.ORG_TAB_IN_CODIGO = P.ORG_TAB_IN_CODIGO                        ")
        SQL.Add("               AND X.ORG_PAD_IN_CODIGO = P.ORG_PAD_IN_CODIGO                        ")
        SQL.Add("               AND X.ORG_IN_CODIGO     = P.ORG_IN_CODIGO                            ")
        SQL.Add("               AND X.ORG_TAU_ST_CODIGO = P.ORG_TAU_ST_CODIGO                        ")
        SQL.Add("               AND X.SER_ST_CODIGO     = P.SER_ST_CODIGO                            ")
        SQL.Add("               AND X.PED_IN_CODIGO     = P.PED_IN_CODIGO                            ")
        SQL.Add("               AND X.ITP_IN_SEQUENCIA  = P.ITP_IN_SEQUENCIA                         ")
        SQL.Add("               AND X.IPE_IN_SEQUENCIA  < :pIPE_IN_SEQUENCIA),0) ANTERIOR,           ")
        SQL.Add("        NVL((SELECT MIN(X.IPE_IN_SEQUENCIA)                                         ")
        SQL.Add("              FROM VEN_PEDPROGENTREGA X                                             ")
        SQL.Add("              WHERE X.ORG_TAB_IN_CODIGO = P.ORG_TAB_IN_CODIGO                       ")
        SQL.Add("                AND X.ORG_PAD_IN_CODIGO = P.ORG_PAD_IN_CODIGO                       ")
        SQL.Add("                AND X.ORG_IN_CODIGO     = P.ORG_IN_CODIGO                           ")
        SQL.Add("                AND X.ORG_TAU_ST_CODIGO = P.ORG_TAU_ST_CODIGO                       ")
        SQL.Add("                AND X.SER_ST_CODIGO     = P.SER_ST_CODIGO                           ")
        SQL.Add("                AND X.PED_IN_CODIGO     = P.PED_IN_CODIGO                           ")
        SQL.Add("                AND X.ITP_IN_SEQUENCIA  = P.ITP_IN_SEQUENCIA                        ")
        SQL.Add("                AND X.IPE_IN_SEQUENCIA  > :pIPE_IN_SEQUENCIA),0) POSTERIOR,         ")
        SQL.Add("        NVL((SELECT X.IPE_RE_QUANTIDADE                                             ")
        SQL.Add("              FROM VEN_PEDPROGENTREGA X                                             ")
        SQL.Add("              WHERE X.ORG_TAB_IN_CODIGO = P.ORG_TAB_IN_CODIGO                       ")
        SQL.Add("                AND X.ORG_PAD_IN_CODIGO = P.ORG_PAD_IN_CODIGO                       ")
        SQL.Add("                AND X.ORG_IN_CODIGO     = P.ORG_IN_CODIGO                           ")
        SQL.Add("                AND X.ORG_TAU_ST_CODIGO = P.ORG_TAU_ST_CODIGO                       ")
        SQL.Add("                AND X.SER_ST_CODIGO     = P.SER_ST_CODIGO                           ")
        SQL.Add("                AND X.PED_IN_CODIGO     = P.PED_IN_CODIGO                           ")
        SQL.Add("                AND X.ITP_IN_SEQUENCIA  = P.ITP_IN_SEQUENCIA                        ")
        SQL.Add("                AND X.IPE_IN_SEQUENCIA  = :pIPE_IN_SEQUENCIA),0)  QTDE_ATUAL,       ")
        SQL.Add("        SUM(P.IPE_RE_QUANTIDADE)                                  IPE_RE_QUANTIDADE,")
        SQL.Add("        (SELECT SUM(NVL(I.EXP_RE_QTDEFATURAR,0)) EXP_RE_QTDEFATURAR                 ")
        SQL.Add("           FROM VEN_EXPEDICAO I                                                     ")
        SQL.Add("          WHERE I.ORG_TAB_IN_CODIGO = P.ORG_TAB_IN_CODIGO                           ")
        SQL.Add("            AND I.ORG_PAD_IN_CODIGO = P.ORG_PAD_IN_CODIGO                           ")
        SQL.Add("            AND I.ORG_IN_CODIGO     = P.ORG_IN_CODIGO                               ")
        SQL.Add("            AND I.ORG_TAU_ST_CODIGO = P.ORG_TAU_ST_CODIGO                           ")
        SQL.Add("            AND I.SER_ST_CODIGO     = P.SER_ST_CODIGO                               ")
        SQL.Add("            AND I.PED_IN_CODIGO     = P.PED_IN_CODIGO                               ")
        SQL.Add("            AND I.ITP_IN_SEQUENCIA  = P.ITP_IN_SEQUENCIA) EXP_RE_QTDEFATURAR        ")
        SQL.Add("   FROM VEN_PEDPROGENTREGA P                                                        ")
        SQL.Add("  WHERE P.ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO                                   ")
        SQL.Add("    AND P.ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO                                   ")
        SQL.Add("    AND P.ORG_IN_CODIGO     = :pORG_IN_CODIGO                                       ")
        SQL.Add("    AND P.ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO                                   ")
        SQL.Add("    AND P.SER_ST_CODIGO     = :pSER_ST_CODIGO                                       ")
        SQL.Add("    AND P.PED_IN_CODIGO     = :pPED_IN_CODIGO                                       ")
        SQL.Add("    AND P.ITP_IN_SEQUENCIA  = :pITP_IN_SEQUENCIA                                    ")
        SQL.Add("GROUP BY P.ORG_TAB_IN_CODIGO,                                                       ")
        SQL.Add("         P.ORG_PAD_IN_CODIGO,                                                       ")
        SQL.Add("         P.ORG_IN_CODIGO    ,                                                       ")
        SQL.Add("         P.ORG_TAU_ST_CODIGO,                                                       ")
        SQL.Add("         P.SER_ST_CODIGO    ,                                                       ")
        SQL.Add("         P.PED_IN_CODIGO    ,                                                       ")
        SQL.Add("         P.ITP_IN_SEQUENCIA                                                         ")
      End With

      With Cl_Fs_PedidoVenda
        Name         = "Cl_Fs_PedidoVenda"
        TableName    = "FS_PEDIDOVENDA"
        PkFields     = "ORG_TAB_IN_CODIGO;ORG_PAD_IN_CODIGO;ORG_IN_CODIGO;ORG_TAU_ST_CODIGO;SER_ST_CODIGO;PED_IN_CODIGO;"
        Close
        SQL.Clear
        SQL.Add("SELECT *                                       ")
        SQL.Add("  FROM FS_PEDIDOVENDA                          ")
        SQL.Add(" WHERE ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO ")
        SQL.Add("   AND ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO ")
        SQL.Add("   AND ORG_IN_CODIGO     = :pORG_IN_CODIGO     ")
        SQL.Add("   AND ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO ")
        SQL.Add("   AND SER_ST_CODIGO     = :pSER_ST_CODIGO     ")
        SQL.Add("   AND PED_IN_CODIGO     = :pPED_IN_CODIGO     ")
        OnBeforeOpen = AddressOf Cl_OnBeforeOpen()
      End With

      With Cl_Fs_PedidoVendaGer
        Name         = "Cl_Fs_PedidoVendaGer"
        TableName    = "FS_PEDIDOVENDAGER"
        PkFields     = "ORG_TAB_IN_CODIGO;ORG_PAD_IN_CODIGO;ORG_IN_CODIGO;ORG_TAU_ST_CODIGO;SER_ST_CODIGO;PED_IN_CODIGO;ITP_IN_SEQUENCIA;IPE_IN_SEQUENCIA"
        Close
        SQL.Clear
        SQL.Add("SELECT *                                       ")
        SQL.Add("  FROM FS_PEDIDOVENDAGER                       ")
        SQL.Add(" WHERE ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO ")
        SQL.Add("   AND ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO ")
        SQL.Add("   AND ORG_IN_CODIGO     = :pORG_IN_CODIGO     ")
        SQL.Add("   AND ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO ")
        SQL.Add("   AND SER_ST_CODIGO     = :pSER_ST_CODIGO     ")
        SQL.Add("   AND PED_IN_CODIGO     = :pPED_IN_CODIGO     ")
        SQL.Add("   AND ITP_IN_SEQUENCIA  = :pITP_IN_SEQUENCIA  ")
        SQL.Add("   AND IPE_IN_SEQUENCIA  = :pIPE_IN_SEQUENCIA  ")
        OnBeforeOpen = AddressOf Cl_OnBeforeOpen()
      End With

      With Cl_FS_PedProgEntregaOco
        Name         = "Cl_FS_PedProgEntregaOco"
        TableName    = "FS_PEDPROGENTREGAOCO"
        PkFields     = "ORG_TAB_IN_CODIGO;ORG_PAD_IN_CODIGO;ORG_IN_CODIGO;ORG_TAU_ST_CODIGO;SER_ST_CODIGO;PED_IN_CODIGO;ITP_IN_SEQUENCIA;IPE_IN_SEQUENCIA;IPE_IN_OCORRENCIA"
        IndexFieldNames = PkFields
        Close
        SQL.Clear
        SQL.Add("SELECT *                                       ")
        SQL.Add("  FROM FS_PEDPROGENTREGAOCO                    ")
        SQL.Add(" WHERE ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO ")
        SQL.Add("   AND ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO ")
        SQL.Add("   AND ORG_IN_CODIGO     = :pORG_IN_CODIGO     ")
        SQL.Add("   AND ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO ")
        SQL.Add("   AND SER_ST_CODIGO     = :pSER_ST_CODIGO     ")
        SQL.Add("   AND PED_IN_CODIGO     = :pPED_IN_CODIGO     ")
        SQL.Add("   AND ITP_IN_SEQUENCIA  = :pITP_IN_SEQUENCIA  ")
        SQL.Add("   AND IPE_IN_SEQUENCIA  = :pIPE_IN_SEQUENCIA  ")
        OnBeforeOpen = AddressOf Cl_OnBeforeOpen()
      End With

      With Cl_FS_PedProgEntrega
        Name         = "Cl_FS_PedProgEntrega"
        TableName    = "FS_PEDPROGENTREGA"
        PkFields     = "ORG_TAB_IN_CODIGO;ORG_PAD_IN_CODIGO;ORG_IN_CODIGO;ORG_TAU_ST_CODIGO;SER_ST_CODIGO;PED_IN_CODIGO;ITP_IN_SEQUENCIA;IPE_IN_SEQUENCIA;"
        Close
        SQL.Clear
        SQL.Add("SELECT *                                       ")
        SQL.Add("  FROM FS_PEDPROGENTREGA                       ")
        SQL.Add(" WHERE ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO ")
        SQL.Add("   AND ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO ")
        SQL.Add("   AND ORG_IN_CODIGO     = :pORG_IN_CODIGO     ")
        SQL.Add("   AND ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO ")
        SQL.Add("   AND SER_ST_CODIGO     = :pSER_ST_CODIGO     ")
        SQL.Add("   AND PED_IN_CODIGO     = :pPED_IN_CODIGO     ")
        SQL.Add("   AND ITP_IN_SEQUENCIA  = :pITP_IN_SEQUENCIA  ")
        SQL.Add("   AND IPE_IN_SEQUENCIA  = :pIPE_IN_SEQUENCIA  ")
        OnBeforeOpen = AddressOf Cl_OnBeforeOpen()
      End With

      With Cl_FS_PRC_PEDPROENTREGA
        Name = "Cl_FS_PRC_PEDPROENTREGA"
        TableName = "DUAL"
        SQL.Clear
        SQL.Add("BEGIN                                                           ")
        SQL.Add("  FS_PCK_PEDIDOVENDA.FS_PRC_PEDPROGENTREGA(:pORG_TAB_IN_CODIGO, ")
        SQL.Add("                                           :pORG_PAD_IN_CODIGO, ")
        SQL.Add("                                           :pORG_IN_CODIGO,     ")
        SQL.Add("                                           :pORG_TAU_ST_CODIGO, ")
        SQL.Add("                                           :pSER_ST_CODIGO,     ")
        SQL.Add("                                           :pPED_IN_CODIGO,     ")
        SQL.Add("                                           :pOCORRENCIA,        ")
        SQL.Add("                                           :pMOTIVO,            ")
        SQL.Add("                                           :pUSUARIO);          ")
        SQL.Add("END;                                                            ")
      End With

      With Cl_FS_PRC_PEDPROENTREGADATA
        Name      = "Cl_FS_PRC_PEDPROENTREGADATA"
        TableName = "DUAL"
        SQL.Add("BEGIN                                                                ")
        SQL.Add("  FS_PCK_PEDIDOVENDA.FS_PRC_PEDPROGENTREGADATA(:pORG_TAB_IN_CODIGO,  ")
        SQL.Add("                                               :pORG_PAD_IN_CODIGO,  ")
        SQL.Add("                                               :pORG_IN_CODIGO,      ")
        SQL.Add("                                               :pORG_TAU_ST_CODIGO,  ")
        SQL.Add("                                               :pSER_ST_CODIGO,      ")
        SQL.Add("                                               :pPED_IN_CODIGO,      ")
        SQL.Add("                                               :pDATA_ENTREGA,       ")
        SQL.Add("                                               :pUSUARIO);           ")
        SQL.Add("END;                                                                 ")
      End With

      With Cl_FS_PRC_PEDPROENTREGADATACLIENTE
        Name      = "Cl_FS_PRC_PEDPROENTREGADATACLIENTE"
        TableName = "DUAL"
        SQL.Add("BEGIN                                                                ")
        SQL.Add("  FS_PCK_PEDIDOVENDA.FS_PRC_PEDPROGENTREGADATACLIENTE(:pORG_TAB_IN_CODIGO,  ")
        SQL.Add("                                                      :pORG_PAD_IN_CODIGO,  ")
        SQL.Add("                                                      :pORG_IN_CODIGO,      ")
        SQL.Add("                                                      :pORG_TAU_ST_CODIGO,  ")
        SQL.Add("                                                      :pSER_ST_CODIGO,      ")
        SQL.Add("                                                      :pPED_IN_CODIGO,      ")
        SQL.Add("                                                      :pITP_IN_SEQUENCIA,   ")
        SQL.Add("                                                      :pIPE_IN_SEQUENCIA,   ")
        SQL.Add("                                                      :pDATA_CLIENTE,       ")
        SQL.Add("                                                      :pUSUARIO);           ")
        SQL.Add("END;                                                                        ")
      End With

      With Cl_OrdemExpedicao
        Name            = "Cl_OrdemExpedicao"
        TableName       = "VEN_EXPEDICAO"
        SQL.Add("SELECT      A.ORG_TAB_IN_CODIGO,                                              ")
        SQL.Add("            A.ORG_PAD_IN_CODIGO,                                              ")
        SQL.Add("            A.ORG_IN_CODIGO,                                                  ")
        SQL.Add("            A.ORG_TAU_ST_CODIGO,                                              ")
        SQL.Add("            A.SEQ_TAB_IN_CODIGO,                                              ")
        SQL.Add("            A.SEQ_IN_CODIGO,                                                  ")
        SQL.Add("            A.EXP_IN_SEQUENCIA,                                               ")
        SQL.Add("            A.FIL_IN_CODIGO,                                                  ")
        SQL.Add("            A.SER_ST_CODIGO,                                                  ")
        SQL.Add("            A.PED_IN_CODIGO,                                                  ")
        SQL.Add("            A.ITP_IN_SEQUENCIA,                                               ")
        SQL.Add("            A.IPE_IN_SEQUENCIA,                                               ")
        SQL.Add("            A.EXP_IN_CODIGO,                                                  ")
        SQL.Add("            A.EXP_DT_EMISSAO,                                                 ")
        '//  SQL.Add("            A.EXP_RE_QTDEFATURAR,                                             ")
        SQL.Add("            A.EXP_RE_QTDEFATURADA,                                            ")
        SQL.Add("            A.EXP_CH_STATUS,                                                  ")
        SQL.Add("            A.PRO_TAB_IN_CODIGO,                                              ")
        SQL.Add("            A.PRO_PAD_IN_CODIGO,                                              ")
        SQL.Add("            A.PRO_IN_CODIGO,                                                  ")
        SQL.Add("            A.SEQ_TAB_IN_CODIGO,                                              ")
        SQL.Add("            A.SEQ_IN_CODIGO,                                                  ")
        SQL.Add("            A.EXP_IN_SEQUENCIA,                                               ")
        SQL.Add("            FS_FNC_CONVERTE_M2_PC(F.PRO_TAB_IN_CODIGO,                        ")
        SQL.Add("                                  F.PRO_PAD_IN_CODIGO,                        ")
        SQL.Add("                                  F.PRO_IN_CODIGO,                            ")
        SQL.Add("                                  F.UNI_ST_UNIDADE,                           ")
        SQL.Add("                                  E.UNI_ST_UNIDADE,                           ")
        SQL.Add("                                  A.EXP_RE_QTDEFATURAR) EXP_RE_QTDEFATURAR,   ")
        SQL.Add("            FS_FNC_CONVERTE_M2_PC(F.PRO_TAB_IN_CODIGO,                        ")
        SQL.Add("                                  F.PRO_PAD_IN_CODIGO,                        ")
        SQL.Add("                                  F.PRO_IN_CODIGO,                            ")
        SQL.Add("                                  F.UNI_ST_UNIDADE,                           ")
        SQL.Add("                                  E.UNI_ST_UNIDADE,                           ")
        SQL.Add("                                  A.EXP_RE_QTDEFATURADA) EXP_RE_QTDEFATURADA, ")
        SQL.Add("            FS_FNC_CONVERTE_M2_PC(F.PRO_TAB_IN_CODIGO,                        ")
        SQL.Add("                                  F.PRO_PAD_IN_CODIGO,                        ")
        SQL.Add("                                  F.PRO_IN_CODIGO,                            ")
        SQL.Add("                                  F.UNI_ST_UNIDADE,                           ")
        SQL.Add("                                  E.UNI_ST_UNIDADE,                           ")
        SQL.Add("            (SELECT SUM(NVL(B.EXP_RE_QTDEFATURAR,0))                          ")
        SQL.Add("               FROM VEN_EXPEDICAO B                                           ")
        SQL.Add("              WHERE B.ORG_TAB_IN_CODIGO = A.ORG_TAB_IN_CODIGO                 ")
        SQL.Add("                AND B.ORG_PAD_IN_CODIGO = A.ORG_PAD_IN_CODIGO                 ")
        SQL.Add("                AND B.ORG_IN_CODIGO     = A.ORG_IN_CODIGO                     ")
        SQL.Add("                AND B.ORG_TAU_ST_CODIGO = A.ORG_TAU_ST_CODIGO                 ")
        SQL.Add("                AND B.SER_ST_CODIGO     = A.SER_ST_CODIGO                     ")
        SQL.Add("                AND B.PED_IN_CODIGO     = A.PED_IN_CODIGO                     ")
        SQL.Add("                AND B.ITP_IN_SEQUENCIA  = A.ITP_IN_SEQUENCIA                  ")
        SQL.Add("                AND B.IPE_IN_SEQUENCIA  = A.IPE_IN_SEQUENCIA)) QTDE_RESERVADA,")
        SQL.Add("            CASE A.EXP_CH_STATUS WHEN 'N' THEN 'Aguardando Separação'         ")
        SQL.Add("                                 WHEN 'B' THEN 'Bloqueado'                    ")
        SQL.Add("                                 WHEN 'L' THEN 'Liberadas para faturamento'   ")
        SQL.Add("                                 WHEN 'F' THEN 'Faturado'                     ")
        SQL.Add("                                 WHEN 'C' THEN 'Cancelado' END STATUS_OE,     ")
        SQL.Add("           NVL(B.COL_IN_ID,0)                                  ORDEM_COLETA,  ")
        SQL.Add("           NVL(C.COL_CH_STATUS,'N')                            COL_CH_STATUS, ")
        SQL.Add("      CASE C.COL_CH_STATUS WHEN 'P' THEN 'Pronto p/ Coleta'                   ")
        SQL.Add("                           WHEN 'A' THEN 'Romaneio em Andamento'              ")
        SQL.Add("                           WHEN 'F' THEN 'Romaneio Encerrado'                 ")
        SQL.Add("                           ELSE 'Romaneio não Gerado' END  STATUS_COLETA,     ")
        SQL.Add("      (select sum(r1.mvs_re_quantidade)                                       ")
        SQL.Add("              from fs_romaneio_oe_itens_leitura r1                            ")
        SQL.Add("             where r1.org_tab_in_codigo = a.org_tab_in_codigo                 ")
        SQL.Add("               and r1.org_pad_in_codigo = a.org_pad_in_codigo                 ")
        SQL.Add("               and r1.org_in_codigo     = a.org_in_codigo                     ")
        SQL.Add("               and r1.org_tau_st_codigo = a.org_tau_st_codigo                 ")
        SQL.Add("               and r1.seq_in_codigo     = a.seq_in_codigo                     ")
        SQL.Add("               and r1.seq_tab_in_codigo = a.seq_tab_in_codigo                 ")
        SQL.Add("               and r1.exp_in_sequencia  = a.exp_in_sequencia                  ")
        SQL.Add("               and r1.oel_ch_status_log = 'V'                                 ")
        SQL.Add("               and r1.oel_ch_origem     = 'P') Qtde_Testa,                    ")
        SQL.Add("               (select sum(r2.mvs_re_quantidade)                              ")
        SQL.Add("                  from fs_romaneio_oe_itens_leitura r2                        ")
        SQL.Add("                 where r2.org_tab_in_codigo = a.org_tab_in_codigo             ")
        SQL.Add("                   and r2.org_pad_in_codigo = a.org_pad_in_codigo             ")
        SQL.Add("                   and r2.org_in_codigo     = a.org_in_codigo                 ")
        SQL.Add("                   and r2.org_tau_st_codigo = a.org_tau_st_codigo             ")
        SQL.Add("                   and r2.seq_in_codigo     = a.seq_in_codigo                 ")
        SQL.Add("                   and r2.seq_tab_in_codigo = a.seq_tab_in_codigo             ")
        SQL.Add("                   and r2.exp_in_sequencia  = a.exp_in_sequencia              ")
        SQL.Add("                   and r2.oel_ch_status_log = 'V'                             ")
        SQL.Add("                   and r2.oel_ch_origem     = 'C') Qtde_Estoque               ")
        SQL.Add("   FROM VEN_EXPEDICAO        A                                                ")
        SQL.Add("   JOIN VEN_PEDPROGENTREGA   D ON D.ORG_TAB_IN_CODIGO = A.ORG_TAB_IN_CODIGO   ")
        SQL.Add("                              AND D.ORG_PAD_IN_CODIGO = A.ORG_PAD_IN_CODIGO   ")
        SQL.Add("                              AND D.ORG_IN_CODIGO     = A.ORG_IN_CODIGO       ")
        SQL.Add("                              AND D.ORG_TAU_ST_CODIGO = A.ORG_TAU_ST_CODIGO   ")
        SQL.Add("                              AND D.SER_ST_CODIGO     = A.SER_ST_CODIGO       ")
        SQL.Add("                              AND D.PED_IN_CODIGO     = A.PED_IN_CODIGO       ")
        SQL.Add("                              AND D.ITP_IN_SEQUENCIA  = A.ITP_IN_SEQUENCIA    ")
        SQL.Add("                              AND D.IPE_IN_SEQUENCIA  = A.IPE_IN_SEQUENCIA    ")
        SQL.Add("   JOIN VEN_ITEMPEDIDOVENDA  E ON E.ORG_TAB_IN_CODIGO = D.ORG_TAB_IN_CODIGO   ")
        SQL.Add("                              AND E.ORG_PAD_IN_CODIGO = D.ORG_PAD_IN_CODIGO   ")
        SQL.Add("                              AND E.ORG_IN_CODIGO     = D.ORG_IN_CODIGO       ")
        SQL.Add("                              AND E.ORG_TAU_ST_CODIGO = D.ORG_TAU_ST_CODIGO   ")
        SQL.Add("                              AND E.SER_ST_CODIGO     = D.SER_ST_CODIGO       ")
        SQL.Add("                              AND E.PED_IN_CODIGO     = D.PED_IN_CODIGO       ")
        SQL.Add("                              AND E.ITP_IN_SEQUENCIA  = D.ITP_IN_SEQUENCIA    ")
        SQL.Add("   JOIN EST_PRODUTOS         F ON F.PRO_TAB_IN_CODIGO = E.PRO_TAB_IN_CODIGO   ")
        SQL.Add("                              AND F.PRO_PAD_IN_CODIGO = E.PRO_PAD_IN_CODIGO   ")
        SQL.Add("                              AND F.PRO_IN_CODIGO     = E.PRO_IN_CODIGO       ")
        SQL.Add("   LEFT                                                                       ")
        SQL.Add("   JOIN FS_ROMANEIO_OE_ITENS B  ON A.ORG_TAB_IN_CODIGO = B.ORG_TAB_IN_CODIGO  ")
        SQL.Add("                               AND A.ORG_PAD_IN_CODIGO = B.ORG_PAD_IN_CODIGO  ")
        SQL.Add("                               AND A.ORG_IN_CODIGO     = B.ORG_IN_CODIGO      ")
        SQL.Add("                               AND A.ORG_TAU_ST_CODIGO = B.ORG_TAU_ST_CODIGO  ")
        SQL.Add("                               AND A.SEQ_TAB_IN_CODIGO = B.SEQ_TAB_IN_CODIGO  ")
        SQL.Add("                               AND A.SEQ_IN_CODIGO     = B.SEQ_IN_CODIGO      ")
        SQL.Add("                               AND A.EXP_IN_SEQUENCIA  = B.EXP_IN_SEQUENCIA   ")
        SQL.Add("  LEFT                                                                        ")
        SQL.Add("  JOIN FS_ROMANEIO_OE        C ON B.COL_IN_ID = C.COL_IN_ID                   ")
        SQL.Add(" WHERE A.ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO                              ")
        SQL.Add("   AND A.ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO                              ")
        SQL.Add("   AND A.ORG_IN_CODIGO     = :pORG_IN_CODIGO                                  ")
        SQL.Add("   AND A.ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO                              ")
        SQL.Add("   AND A.SER_ST_CODIGO     = :pSER_ST_CODIGO                                  ")
        SQL.Add("   AND A.PED_IN_CODIGO     = :pPED_IN_CODIGO                                  ")
        SQL.Add("   AND A.ITP_IN_SEQUENCIA  = :pITP_IN_SEQUENCIA                               ")
        SQL.Add("   AND A.IPE_IN_SEQUENCIA  = :pIPE_IN_SEQUENCIA                               ")

        OnBeforeOpen = AddressOf Cl_OrdemExpedicao_OnBeforeOpen()
        OnAfterOpen  = AddressOf Cl_OrdemExpedicao_OnAfterOpen()
        OnAfterScroll= AddressOf Cl_OrdemExpedicao_OnAfterScroll()

        '//Open thiago mazolli
      End With

      With Ds_OrdemExpedicao
        Name    = "Ds_OrdemExpedicao"
        DataSet = Cl_OrdemExpedicao
      End With

      With Cl_NotaFiscal
        Name      = "Cl_NotaFiscal"
        TableName = "VEN_NOTAFISCAL"
        Close
        SQL.Clear
        SQL.Add("SELECT B.ORG_TAB_IN_CODIGO,                                                        ")
        SQL.Add("       B.ORG_PAD_IN_CODIGO,                                                        ")
        SQL.Add("       B.ORG_IN_CODIGO,                                                            ")
        SQL.Add("       B.ORG_TAU_ST_CODIGO,                                                        ")
        SQL.Add("       B.SEQ_TAB_IN_CODIGO,                                                        ")
        SQL.Add("       B.SEQ_IN_CODIGO,                                                            ")
        SQL.Add("       B.NOT_IN_CODIGO,                                                            ")
        SQL.Add("       B.NOT_DT_EMISSAO,                                                           ")
        SQL.Add("       B.NOT_IN_NUMERO,                                                            ")
        SQL.Add("       B.NOT_RE_VALORTOTAL                                                         ")
        SQL.Add("  FROM VEN_ITEMPEDI_VEN_ITEMNOT  A                                                 ")
        SQL.Add("  JOIN VEN_NOTAFISCAL            B ON B.ORG_TAB_IN_CODIGO = A.NF_ORG_TAB_IN_CODIGO ")
        SQL.Add("                                  AND B.ORG_PAD_IN_CODIGO = A.NF_ORG_PAD_IN_CODIGO ")
        SQL.Add("                                  AND B.ORG_IN_CODIGO     = A.NF_ORG_IN_CODIGO     ")
        SQL.Add("                                  AND B.ORG_TAU_ST_CODIGO = A.NF_ORG_TAU_ST_CODIGO ")
        SQL.Add("                                  AND B.SEQ_TAB_IN_CODIGO = A.NF_SEQ_TAB_IN_CODIGO ")
        SQL.Add("                                  AND B.SEQ_IN_CODIGO     = A.NF_SEQ_IN_CODIGO     ")
        SQL.Add("                                  AND B.NOT_IN_CODIGO     = A.NF_NOT_IN_CODIGO     ")
        SQL.Add("WHERE A.PE_ORG_TAB_IN_CODIGO  = :pORG_TAB_IN_CODIGO                                ")
        SQL.Add("  AND A.PE_ORG_PAD_IN_CODIGO  = :pORG_PAD_IN_CODIGO                                ")
        SQL.Add("  AND A.PE_ORG_IN_CODIGO      = :pORG_IN_CODIGO                                    ")
        SQL.Add("  AND A.PE_ORG_TAU_ST_CODIGO  = :pORG_TAU_ST_CODIGO                                ")
        SQL.Add("  AND A.PE_SER_ST_CODIGO      = :pSER_ST_CODIGO                                    ")
        SQL.Add("  AND A.PE_PED_IN_CODIGO      = :pPED_IN_CODIGO                                    ")
        SQL.Add("  AND A.PE_ITP_IN_SEQUENCIA   = :pITP_IN_SEQUENCIA                                 ")
        SQL.Add("  AND A.PE_IPE_IN_SEQUENCIA   = :pIPE_IN_SEQUENCIA                                 ")
        SQL.Add("  AND A.EXP_SEQ_TAB_IN_CODIGO = :pSEQ_TAB_IN_CODIGO                                ")
        SQL.Add("  AND A.EXP_SEQ_IN_CODIGO     = :pSEQ_IN_CODIGO                                    ")
        SQL.Add("  AND A.EXP_IN_SEQUENCIA      = :pEXP_IN_SEQUENCIA                                 ")

        OnBeforeOpen = AddressOf Cl_NotaFiscal_OnBeforeOpen()
        OnAfterOpen  = AddressOf Cl_NotaFiscal_OnAfterOpen()

        '//Open thiago mazolli
      End With

      With Ds_NotaFiscal
        Name    = "Ds_NotaFiscal"
        DataSet = Cl_NotaFiscal
      End With

      '//Exclusão em Massa das OE's do Pedido de Venda - 15/06/2023 - Luan Oliveira
      With Cl_ExcluiOEPedido
        Name      = "Cl_ExcluiOEPedido"
        TableName = "VEN_EXPEDICAO"
        SQL.Add("SELECT A.ORG_TAB_IN_CODIGO,                                                              ")
        SQL.Add("       A.ORG_PAD_IN_CODIGO,                                                              ")
        SQL.Add("       A.ORG_IN_CODIGO,                                                                  ")
        SQL.Add("       A.ORG_TAU_ST_CODIGO,                                                              ")
        SQL.Add("       A.SER_ST_CODIGO,                                                                  ")
        SQL.Add("       A.PED_IN_CODIGO,                                                                  ")
        SQL.Add("       A.ITP_IN_SEQUENCIA,                                                               ")
        SQL.Add("       A.IPE_IN_SEQUENCIA,                                                               ")
        SQL.Add("       A.IPE_RE_QUANTIDADE,                                                              ")
        SQL.Add("       B.FIL_IN_CODIGO,                                                                  ")
        SQL.Add("       B.TRA_IN_CODIGO,                                                                  ")
        SQL.Add("       B.EXP_IN_CODIGO,                                                                  ")
        SQL.Add("       B.EXP_DT_EMISSAO                                                                  ")
        SQL.Add("  FROM VEN_PEDPROGENTREGA  A                                                             ")
        SQL.Add("  JOIN VEN_EXPEDICAO       B ON B.ORG_TAB_IN_CODIGO = A.ORG_TAB_IN_CODIGO                ")
        SQL.Add("                            AND B.ORG_PAD_IN_CODIGO = A.ORG_PAD_IN_CODIGO                ")
        SQL.Add("                            AND B.ORG_IN_CODIGO     = A.ORG_IN_CODIGO                    ")
        SQL.Add("                            AND B.ORG_TAU_ST_CODIGO = A.ORG_TAU_ST_CODIGO                ")
        SQL.Add("                            AND B.SER_ST_CODIGO     = A.SER_ST_CODIGO                    ")
        SQL.Add("                            AND B.PED_IN_CODIGO     = A.PED_IN_CODIGO                    ")
        SQL.Add("                            AND B.ITP_IN_SEQUENCIA  = A.ITP_IN_SEQUENCIA                 ")
        SQL.Add("                            AND B.IPE_IN_SEQUENCIA  = A.IPE_IN_SEQUENCIA                 ")
        SQL.Add("  JOIN VEN_ITEMPEDIDOVENDA C ON C.ORG_TAB_IN_CODIGO = A.ORG_TAB_IN_CODIGO                ")
        SQL.Add("                            AND C.ORG_PAD_IN_CODIGO = A.ORG_PAD_IN_CODIGO                ")
        SQL.Add("                            AND C.ORG_IN_CODIGO     = A.ORG_IN_CODIGO                    ")
        SQL.Add("                            AND C.ORG_TAU_ST_CODIGO = A.ORG_TAU_ST_CODIGO                ")
        SQL.Add("                            AND C.SER_ST_CODIGO     = A.SER_ST_CODIGO                    ")
        SQL.Add("                            AND C.PED_IN_CODIGO     = A.PED_IN_CODIGO                    ")
        SQL.Add("                            AND C.ITP_IN_SEQUENCIA  = A.ITP_IN_SEQUENCIA                 ")
        SQL.Add("  LEFT                                                                                   ")
        SQL.Add("  JOIN FS_ROMANEIO_OE_ITENS D ON D.ORG_TAB_IN_CODIGO = B.ORG_TAB_IN_CODIGO               ")
        SQL.Add("                             AND D.ORG_PAD_IN_CODIGO = B.ORG_PAD_IN_CODIGO               ")
        SQL.Add("                             AND D.ORG_IN_CODIGO     = B.ORG_IN_CODIGO                   ")
        SQL.Add("                             AND D.ORG_TAU_ST_CODIGO = B.ORG_TAU_ST_CODIGO               ")
        SQL.Add("                             AND D.SEQ_TAB_IN_CODIGO = B.SEQ_TAB_IN_CODIGO               ")
        SQL.Add("                             AND D.SEQ_IN_CODIGO     = B.SEQ_IN_CODIGO                   ")
        SQL.Add("                             AND D.EXP_IN_SEQUENCIA  = B.EXP_IN_SEQUENCIA                ")
        SQL.Add("  LEFT                                                                                   ")
        SQL.Add("  JOIN FS_ROMANEIO_OE       E ON E.COL_IN_ID         = D.COL_IN_ID                       ")
        SQL.Add("WHERE B.EXP_CH_STATUS            = 'N'                                                   ")
        SQL.Add("  AND NVL(E.COL_CH_STATUS,'N')   = 'N'                                                   ")
        SQL.Add("  AND C.ITP_ST_SITUACAO NOT IN('F','C')                                                  ")
        SQL.Add("  AND NOT EXISTS(SELECT 1                                                                ")
        SQL.Add("                   FROM FS_APT_APONTAORDEM X                                             ")
        SQL.Add("                  WHERE X.ORG_TAB_IN_CODIGO     = B.ORG_TAB_IN_CODIGO                    ")
        SQL.Add("                    AND X.ORG_PAD_IN_CODIGO     = B.ORG_PAD_IN_CODIGO                    ")
        SQL.Add("                    AND X.ORG_TAU_ST_CODIGO     = B.ORG_TAU_ST_CODIGO                    ")
        SQL.Add("                    AND X.ORG_IN_CODIGO         = B.ORG_IN_CODIGO                        ")
        SQL.Add("                    AND X.EXP_SEQ_TAB_IN_CODIGO = B.SEQ_TAB_IN_CODIGO                    ")
        SQL.Add("                    AND X.EXP_SEQ_IN_CODIGO     = B.SEQ_IN_CODIGO                        ")
        SQL.Add("                    AND X.EXP_IN_SEQUENCIA      = B.EXP_IN_SEQUENCIA)                    ")
        SQL.Add("  AND C.ORG_TAB_IN_CODIGO = :pORG_TAB_IN_CODIGO                                          ")
        SQL.Add("  AND C.ORG_PAD_IN_CODIGO = :pORG_PAD_IN_CODIGO                                          ")
        SQL.Add("  AND C.ORG_IN_CODIGO     = :pORG_IN_CODIGO                                              ")
        SQL.Add("  AND C.ORG_TAU_ST_CODIGO = :pORG_TAU_ST_CODIGO                                          ")
        SQL.Add("  AND C.SER_ST_CODIGO     = :pSER_ST_CODIGO                                              ")
        SQL.Add("  AND C.PED_IN_CODIGO     = :pPED_IN_CODIGO                                              ")
        OnBeforeOpen = AddressOf Cl_ExcluiOEPedido_OnBeforeOpen()
      End With
      '//Exclusão em Massa das OE's do Pedido de Venda - 15/06/2023 - Luan Oliveira - Fim

      '//Verifica se existe apontamento - 22/06/2023 - Luan Oliveira
      With Cl_FS_APT_APONTAORDEM
        Name      = "Cl_FS_APT_APONTAORDEM"
        PkFields  = "APT_IN_SEQUENCIA"
        TableName = "FS_APT_APONTAORDEM"
        SQL.Add("SELECT A.EXP_IN_SEQUENCIA                             ")
        SQL.Add("  FROM FS_APT_APONTAORDEM A                           ")
        SQL.Add(" WHERE A.ORG_TAB_IN_CODIGO     = :pORG_TAB_IN_CODIGO  ")
        SQL.Add("   AND A.ORG_PAD_IN_CODIGO     = :pORG_PAD_IN_CODIGO  ")
        SQL.Add("   AND A.ORG_TAU_ST_CODIGO     = :pORG_TAU_ST_CODIGO  ")
        SQL.Add("   AND A.ORG_IN_CODIGO         = :pORG_IN_CODIGO      ")
        SQL.Add("   AND A.EXP_SEQ_TAB_IN_CODIGO = :pSEQ_TAB_IN_CODIGO  ")
        SQL.Add("   AND A.EXP_SEQ_IN_CODIGO     = :pSEQ_IN_CODIGO      ")
        SQL.Add("   AND A.EXP_IN_SEQUENCIA      = :pEXP_IN_SEQUENCIA   ")
        OnBeforeOpen = AddressOf Cl_FS_APT_APONTAORDEM_OnBeforeOpen()
      End With

      With Cl_Update_Cl_FS_APT_APONTAORDEM
        Name      = "Cl_Update_Cl_FS_APT_APONTAORDEM"
        PkFields  = "APT_IN_SEQUENCIA"
        TableName = "FS_APT_APONTAORDEM"
        SQL.Add("BEGIN                                                   ")
        SQL.Add("  UPDATE FS_APT_APONTAORDEM A                           ")
        SQL.Add("     SET A.OE_CH_TIPOEXCLUSAO    = :pOE_CH_TIPOEXCLUSAO ")
        SQL.Add("   WHERE A.ORG_TAB_IN_CODIGO     = :pORG_TAB_IN_CODIGO  ")
        SQL.Add("     AND A.ORG_PAD_IN_CODIGO     = :pORG_PAD_IN_CODIGO  ")
        SQL.Add("     AND A.ORG_TAU_ST_CODIGO     = :pORG_TAU_ST_CODIGO  ")
        SQL.Add("     AND A.ORG_IN_CODIGO         = :pORG_IN_CODIGO      ")
        SQL.Add("     AND A.EXP_SEQ_TAB_IN_CODIGO = :pSEQ_TAB_IN_CODIGO  ")
        SQL.Add("     AND A.EXP_SEQ_IN_CODIGO     = :pSEQ_IN_CODIGO      ")
        SQL.Add("     AND A.EXP_IN_SEQUENCIA      = :pEXP_IN_SEQUENCIA;  ")
        SQL.Add("EXCEPTION                                               ")
        SQL.Add("  WHEN OTHERS THEN                                      ")
        SQL.Add("     RAISE_APPLICATION_ERROR(-20103,SQLERRM);           ")
        SQL.Add("END;                                                    ")
      End With
      '//Verifica se existe apontamento - 22/06/2023 - Luan Oliveira - Fim


      '//Altera data de Expedição  -- 24/07/2023 Luan Oliveira
      With Cl_FS_PRC_PEDPROGDATAEXP
        Name      = "Cl_FS_PRC_PEDPROGDATAEXP"
        TableName = "DUAL"
        Close
        SQL.Add("BEGIN                                                           ")
        SQL.Add("  FS_PCK_PEDIDOVENDA.FS_PRC_PEDPROGDATAEXP(:pORG_TAB_IN_CODIGO, ")
        SQL.Add("                                           :pORG_PAD_IN_CODIGO, ")
        SQL.Add("                                           :pORG_IN_CODIGO,     ")
        SQL.Add("                                           :pORG_TAU_ST_CODIGO, ")
        SQL.Add("                                           :pSER_ST_CODIGO,     ")
        SQL.Add("                                           :pPED_IN_CODIGO,     ")
        SQL.Add("                                           :pITP_IN_SEQUENCIA,  ")
        SQL.Add("                                           :pIPE_IN_SEQUENCIA,  ")
        SQL.Add("                                           :pIPE_DT_DATAENTREGA,")
        SQL.Add("                                           :pUSU_IN_CODIGO);    ")
        SQL.Add("END;                                                            ")
      End With

      With Cl_FS_RESERVAAUTO
        Name            = "Cl_FS_RESERVAAUTO"
        TableName       = "FS_RESERVAAUTO"
        PkFields        = "RES_IN_CODIGO"
        IndexFieldNames = "RES_IN_CODIGO"
        SQL.Add("SELECT  *             ")
        SQL.Add("  FROM FS_RESERVAAUTO ")
        SQL.Add(" WHERE  1=2           ")
        Open
      End With

      With Cl_FS_RESERVAAUTO_Update
        Name            = "Cl_FS_RESERVAAUTO_Update"
        TableName       = "DUAL"
        SQL.Add("BEGIN ")
        SQL.Add(" UPDATE FS_RESERVAAUTO                  ")
        SQL.Add("    SET RES_DT_FIM = SYSDATE            ")
        SQL.Add("  WHERE RES_IN_CODIGO = :pRES_IN_CODIGO;")
        SQL.Add("  COMMIT;")
        SQL.Add("END; ")
      End With

      With Cl_FS_SEQ_RESERVAAUTO
        Name            = "Cl_FS_SEQ_RESERVAAUTO"
        TableName       = "DUAL"
        Close
        SQL.Add("SELECT FS_SEQ_RESERVAAUTO.NEXTVAL SEQUENCIA")
        SQL.Add("  FROM DUAL                                ")
      End With

      '//Pedido de Venda
      With Tv_Dados
        '// DataController.DataModeController.GridMode = True
        DataController.DataSource = FormAtivo.Ds_Dados
        OptionsView.GroupByBox = False
        OptionsView.Indicator  = True
        OptionsData.Appending  = False
        OptionsData.Deleting   = False
        OptionsData.Inserting  = False
        OptionsData.Editing    = True
      End With

      Pn_Direito.Caption = ""

      With Pn_Grid
         Parent = FormAtivo.cPn_GridPedido
         Name = "Pn_Grid"
         Align = AlClient
         Caption = ""
      End With

      With Gd_Dados
        Name = "Gd_Dados"
        Parent = Pn_Grid
        Align = AlClient
        Levels.Add
        Levels.Items[0].GridView = Tv_Dados
      End With


      '//Ordens de Expedição
      With Tv_OrdemExpedicao
        '//DataController.DataModeController.GridMode = True
        DataController.DataSource  = Ds_OrdemExpedicao
        OptionsView.CellAutoHeight = False
        OptionsView.GroupByBox     = False
        OptionsView.Indicator      = True
        OptionsData.Appending      = False
        OptionsData.Deleting       = False
        OptionsData.Inserting      = False
        OptionsData.Editing        = False
      End With

      With Gd_OrdemExpedicao
        Name       = "Gd_OrdemExpedicao"
        Parent     = FormAtivo.Pn_OE_Geradas
        Align      = AlClient
        Levels.Add
        Levels.Items[0].GridView  = Tv_OrdemExpedicao
      End With


      '//Nota fiscal
      With Tv_NotaFiscal
        '//DataController.DataModeController.GridMode = True
        DataController.DataSource = Ds_NotaFiscal
        OptionsView.GroupByBox    = False
        OptionsView.Indicator     = True
        OptionsData.Appending     = False
        OptionsData.Deleting      = False
        OptionsData.Inserting     = False
        OptionsData.Editing       = False
      End With

      With Gd_NotaFiscal
        Name       = "Gd_NotaFiscal"
        Parent     = FormAtivo.Pn_NotaFiscal
        Align      = AlClient
        Levels.Add
        Levels.Items[0].GridView = Tv_NotaFiscal
      End With

      cCL_DataHorizonte = New TmgClientDataSet(FormAtivo)

      With cCL_DataHorizonte
        cCL_DataHorizonte.OnBeforeOpen = AddressOf cCL_DataHorizonte_OnBeforeOpen
        Name = "cCL_DataHorizonte"
        TableName = "dual"
        Sql.Add(" select TRUNC(sysdate +")
        Sql.Add("              FS_PCK_APT_NEW.FNC_OBTEM_DIAS_HORIZONTE(PCK_MEGA.ACHAPADRAODATABELA(FIL       => :PFIL_IN_CODIGO,")
        Sql.Add("                                                                                  TAB       => 100,")
        Sql.Add("                                                                                  DATAATUAL => sysdate),")
        Sql.Add("                                                      :PPRO_IN_CODIGO)) DATA_HORIZONTE")
        Sql.Add(" ")
        Sql.Add("   from DUAL")
      End With

    End With
End Sub

Sub OnFormShow
    With FormAtivo
      Gb_Status.Checked      = True
      Bt_ExcluirOE.Enabled   = False
      Bt_GerarOE.Enabled     = False
      vCl_DadosExecutaScroll = true
      '//Cl_Dados_OnAfterScroll(FormAtivo.Cl_Dados) thiago mazolli
    End With
End Sub

Sub QtdeProgrmada_OnAfterChange(sender as TMgStringField)
  Dim nSequenciaAnterior  = 0, _
      nSequenciaPosterior = 0, _
      nQtdeAtual          = 0, _
      nQtdeFaturar        = 0, _
      nQtdeTotalAtual     = 0, _
      nQtdeSaldo          = 0, _
      nSequencia          = 0, _
      nInseriu            = 0, _
      nQtdeDigitada       , _
      nOperacaoSaldo      , _
      nValorVerifica      , _
      nQtdeBaixa          , _
      nSequenciaBaixa     , _
      nSequenciaControle  , _
      nSequenciaAtual  = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value           , _
      nQtdeOriginal    = FormAtivo.Cl_Dados.FieldByName("ITP_RE_QUANTIDADE").Value          , _
      vGerencia        = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S") , _
      vRedistribui     = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S") , _
      vVisualiza       = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_VISUALIZA").Value   = "S") , _
      vValidaQtde      = (Cl_OrdemExpedicao.FieldByName("QTDE_RESERVADA").Value < FormAtivo.Cl_Dados.FieldByName("IPE_RE_QUANTIDADE").Value) , _
      vStatusProgEntr  = FormAtivo.Cl_Dados.FieldByName("IPE_CH_STATUS").Value

  vCl_DadosExecutaScroll = false

  TMgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_RE_QUANTIDADE")).OnAfterChange  = nil

  if(vValidaQtde AND (FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "F")) then
    if(vGerencia or vRedistribui)then
      With sender
        nQtdeDigitada = StrToFloat(Value)
        '// Verifica se o pedido aceita pedido parcial, caso não aceite não permite lançar.
        if nQtdeDigitada <> FormAtivo.Cl_Dados.FieldByName("ITP_RE_QUANTIDADE").Value then
          if FormAtivo.Cl_Dados.FieldByName("PED_BO_PARCIAL").Value = "N" then
            FormAtivo.Cl_Dados.Cancel
            vCl_DadosExecutaScroll = true
            RaiseException("Quantidade programada deve ser igual a quantidade itens lançados!" & CHR(10) & "Para este item não é aceito pedido parcial.")
          end if
        end if

        With Cl_DadosProgramadas
          Close
          ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
          ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
          ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
          ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
          ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
          ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
          ParamByName("pITP_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
          ParamByName("pIPE_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
          Open
          if RecordCount > 0 then
            nQtdeFaturar         = FieldByName("EXP_RE_QTDEFATURAR").Value
            nSequenciaAnterior   = FieldByName("ANTERIOR").Value
            nSequenciaPosterior  = FieldByName("POSTERIOR").Value
            nQtdeAtual           = FieldByName("QTDE_ATUAL").Value
            nQtdeTotalAtual      = FieldByName("IPE_RE_QUANTIDADE").Value
          end if
        End With

        If nQtdeFaturar >= nQtdeTotalAtual then
          FormAtivo.Cl_Dados.Cancel
          vCl_DadosExecutaScroll = true
          RaiseException("Quantidade não pode ser alterada! " & chr(13) & "Programação de Entrega não possue saldo disponível para essa operação.")
        End if

        if nQtdeDigitada <= 0 then
          nQtdeSaldo = nQtdeAtual
          if nSequenciaAnterior > 0 then
            nSequencia = nSequenciaAnterior
          else
            nSequencia = nSequenciaPosterior
          end if
          nOperacaoSaldo = "+"
        else
          If nQtdeDigitada < nQtdeAtual then
            nQtdeSaldo = nQtdeAtual - nQtdeDigitada
            if nSequenciaPosterior > 0 then
              nSequencia = nSequenciaPosterior
            end if
            nOperacaoSaldo = "+"
          else
            nQtdeSaldo = nQtdeDigitada - nQtdeAtual
            if nSequenciaAnterior > 0 then
              nSequencia = nSequenciaAnterior
            else
              if nSequenciaPosterior > 0 then
                nSequencia = nSequenciaPosterior
              End If
            end if
            nOperacaoSaldo = "-"
          end if
        end if

        nValorVerifica = ((nQtdeTotalAtual - nQtdeAtual)- nQtdeSaldo) + nQtdeDigitada

        if (nValorVerifica > nQtdeOriginal) or (nQtdeDigitada > nQtdeTotalAtual) or (nQtdeDigitada > nQtdeOriginal)  then
          FormAtivo.Cl_Dados.Cancel
          vCl_DadosExecutaScroll = true
          TMgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_RE_QTDECONVERTIDA")).OnAfterChange  = AddressOf QtdeProgrmada_OnAfterChange()
          RaiseException("Quantidade programada é maior que a quantidade de itens lançados!")
        End if

        if (nSequencia <= 0) and (nQtdeSaldo > 0) then
          if (messagedlg("Alteração da quantidade gerou um saldo de " & nQtdeSaldo & ".           " & Chr(10) & _
                        "Para continuar será gerado uma nova programação de entrega com o saldo. " & Chr(10) & _
                        "Deseja prosseguir com a alteração?                                      " , 3, 3, 0) = MrNo) Then
              FormAtivo.Cl_Dados.Cancel
              vCl_DadosExecutaScroll = true
              TMgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_RE_QTDECONVERTIDA")).OnAfterChange  = AddressOf QtdeProgrmada_OnAfterChange()
              Cl_DadosProgramadas.Cancel
              Cl_DadosProgramadas.Close
              Exit
          end if
        end if

        if nSequencia <= 0 then
          nSequencia = nSequenciaAtual + 1
        end if

        With Cl_Programacao
          Cl_Programacao_Open(FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value)

          if RecordCount > 0 then
            if nQtdeDigitada > 0 then
              Edit
              FieldByName("IPE_RE_QUANTIDADE").Value       = nQtdeDigitada
              FieldByName("IPE_RE_QTDECONVERTIDA").Value   = nQtdeDigitada
              Post
            else
              Cl_Programacao.Delete
            end if
          end if

          DMMega.GravaRegistro([Cl_Programacao])

          Cl_Programacao_Open(nSequencia)

          IF nQtdeSaldo > 0 THEN
            IF Cl_Programacao.RecordCount <= 0 Then
              With Cl_ProgramacaoInsere
                ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
                ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
                ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
                ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
                ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
                ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
                ParamByName("pITP_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
                ParamByName("pIPE_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
                ParamByName("pIPE_CH_STATUS").Value     = vStatusProgEntr
                ParamByName("pQUANTIDADE").Value        = nQtdeSaldo
                ParamByName("pSEQUENCIA").Value         = nSequencia
                ParamByName("pUSUARIO").Value           = DMMega.Usuario
                ExecSQL
              End With
              nInseriu   = 1
              nQtdeSaldo = 0
              '//Atualiza Dataset Programação de Entrega
              Cl_Programacao_Open(nSequencia)
            End if

            IF RecordCount > 0 THEN
              IF nQtdeSaldo > 0 THEN
                Cl_Programacao.Edit

                nSequenciaBaixa = nSequencia

                if nOperacaoSaldo = "+" then
                  FieldByName("IPE_RE_QUANTIDADE").Value       = FieldByName("IPE_RE_QUANTIDADE").Value + nQtdeSaldo
                  FieldByName("IPE_RE_QTDECONVERTIDA").Value   = FieldByName("IPE_RE_QUANTIDADE").Value
                Else
                  While nQtdeSaldo >= 0
                    If RecordCount > 0 then
                      If (FieldByName("IPE_RE_QUANTIDADE").Value < nQtdeSaldo) OR (FieldByName("IPE_RE_QUANTIDADE").Value = 0) then
                        If FieldByName("IPE_RE_QUANTIDADE").Value = 0 then
                          If nQtdeSaldo <= 0 then
                            nQtdeSaldo = - 1
                          End If
                          Cl_Programacao.Delete
                        Else
                          nQtdeSaldo  = nQtdeSaldo - FieldByName("IPE_RE_QUANTIDADE").Value
                          Cl_Programacao.Delete
                          DMMega.GravaRegistro([Cl_Programacao])

                          With Cl_DadosProgramadas
                            Close
                            ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
                            ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
                            ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
                            ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
                            ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
                            ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
                            ParamByName("pITP_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
                            ParamByName("pIPE_IN_SEQUENCIA").Value  = nSequenciaBaixa
                            Open
                            if RecordCount > 0 then
                              nSequenciaAnterior   = FieldByName("ANTERIOR").Value
                              nSequenciaPosterior  = FieldByName("POSTERIOR").Value
                            end if
                          End With

                          If (nSequenciaPosterior <> nSequencia) AND (nSequenciaPosterior > 0) then
                            Cl_Programacao_Open(nSequenciaPosterior)
                            If RecordCount = 0 then
                              If (nSequenciaAnterior <> nSequencia) AND (nSequenciaAnterior > 0) then
                                Cl_Programacao_Open(nSequenciaAnterior)
                              End if
                            End if
                          Else
                            If (nSequenciaAnterior <> nSequencia) AND (nSequenciaAnterior > 0) then
                              Cl_Programacao_Open(nSequenciaAnterior)
                            End if
                          End if

                          If RecordCount > 0 then
                            nSequenciaBaixa = ParamByName("pIPE_IN_SEQUENCIA").Value
                            Cl_Programacao.Edit
                          End if
                        End if
                      Else
                        If nQtdeSaldo <= 0 then
                          nQtdeSaldo = -1
                        Else
                          FieldByName("IPE_RE_QUANTIDADE").Value       = FieldByName("IPE_RE_QUANTIDADE").Value - nQtdeSaldo
                          FieldByName("IPE_RE_QTDECONVERTIDA").Value   = FieldByName("IPE_RE_QUANTIDADE").Value
                          nQtdeSaldo = 0
                        End if
                      End if
                    End If
                  Wend
                End if
                Insere_Ocorrencia("Q")
              Else
                If nInseriu = 0 then
                  Cl_Programacao.Delete
                  DMMega.GravaRegistro([Cl_Programacao])
                End If
              End If
            End if
          End if
        End With

        DMMega.GravaRegistro([Cl_Programacao])

        With Tv_Dados
          DataController.DataSource = Null
        End With

        vCl_OrdemExecutaScroll = false
        With FormAtivo.Cl_Dados
          Close
          Open
        End With
        vCl_OrdemExecutaScroll = true

        With Tv_Dados
          DataController.DataSource = FormAtivo.Ds_Dados
        End With
      End With
    Else
      FormAtivo.Cl_Dados.Cancel
      vCl_DadosExecutaScroll = true
      TMgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_RE_QTDECONVERTIDA")).OnAfterChange  = AddressOf QtdeProgrmada_OnAfterChange()
      RaiseException("Usuário sem permissão para este tipo de operação!")
    End If
  Else
    FormAtivo.Cl_Dados.Cancel
    vCl_DadosExecutaScroll = true
    TMgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_RE_QTDECONVERTIDA")).OnAfterChange  = AddressOf QtdeProgrmada_OnAfterChange()
    RaiseException("Alteração não pode ser realizada para esta programação de entrega!")
  End if
  vCl_DadosExecutaScroll = true
End Sub

Sub Prioridade_OnAfterChange(sender as TMgStringField)
  Dim idx, _
      CodPrioridade, _
      vGerencia    = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S"), _
      vRedistribui = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S"), _
      vVisualiza   = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_VISUALIZA").Value   = "S"), _
      vValidaQtde  = (Cl_OrdemExpedicao.FieldByName("QTDE_RESERVADA").Value < FormAtivo.Cl_Dados.FieldByName("IPE_RE_QUANTIDADE").Value)

  TMgStringField(FormAtivo.Cl_Dados.FieldByName("PRIORIDADE")).OnAfterChange = nil

  vCl_DadosExecutaScroll = False
  vCl_OrdemExecutaScroll = False
  if (vValidaQtde AND (FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "F"))then
    If (vGerencia or vRedistribui)then
      With sender
        if NOT Sl_Prioridade.Find(Trim(Value),0) then
          FormAtivo.Cl_Dados.Cancel
          vCl_DadosExecutaScroll = true
          RaiseException("Prioridade selecionada é inválida!")
        Else

          CodPrioridade = StrToInt(MgLeft(Value,1))
          '//Verifica se o Tipo de Mercado é Exportação para Prioridade Exportação
          If (CodPrioridade = 9) and (FormAtivo.Cl_Dados.FieldByName("EXPORTACAO").Value = "N") Then
            FormAtivo.Cl_Dados.Cancel
            vCl_DadosExecutaScroll = true
            RaiseException("Prioridade Exportação, só pode ser atribuida ao tipo de Mercado Exportação!")
          End If

          With Cl_Fs_PedidoVendaGer
            Close
            Open
            if RecordCount = 0 then
              Cl_Fs_PedidoVendaGer.Insert
              FieldByName("ORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
              FieldByName("ORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
              FieldByName("ORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
              FieldByName("ORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
              FieldByName("SER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
              FieldByName("PED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
              FieldByName("ITP_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
              FieldByName("IPE_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
            Else
              Cl_Fs_PedidoVendaGer.Edit
            End If

            FieldByName("PED_IN_PRIORIDADE").Value  = CodPrioridade
            Cl_Fs_PedidoVendaGer.Post
          End With
          DMMega.GravaRegistro([Cl_Fs_PedidoVendaGer])
          Insere_Ocorrencia("P")
        End If
      End With
    Else
      FormAtivo.Cl_Dados.Cancel
      vCl_DadosExecutaScroll = true
      TMgStringField(FormAtivo.Cl_Dados.FieldByName("PRIORIDADE")).OnAfterChange = AddressOf Prioridade_OnAfterChange()
      RaiseException("Usuário sem permissão para este tipo de operação!")
    End if
  Else
    FormAtivo.Cl_Dados.Cancel
    vCl_DadosExecutaScroll = true
    TMgStringField(FormAtivo.Cl_Dados.FieldByName("PRIORIDADE")).OnAfterChange = AddressOf Prioridade_OnAfterChange()
    RaiseException("Alteração não pode ser realizada para esta programação de entrega!")
  End if
  TMgStringField(FormAtivo.Cl_Dados.FieldByName("PRIORIDADE")).OnAfterChange = AddressOf Prioridade_OnAfterChange()
  '// vCl_DadosExecutaScroll = true
End Sub

Sub StatusPedido_OnAfterChange(sender as TMgStringField)
  Dim idx, _
      vGerencia    = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S"), _
      vRedistribui = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S"), _
      vVisualiza   = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_VISUALIZA").Value   = "S"), _
      vOcorrencia, _
      vGeraOE

  vCl_DadosExecutaScroll = false
  vCl_OrdemExecutaScroll = false
  if (FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "F") then
    If (vGerencia or vRedistribui)then
      If(MessageDlg("Deseja alterar o status de todos os itens do pedido: " & IntToStr(FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value) & "? ", 3, 3, 0) = MrNo) Then
        With sender
          vOcorrencia = MgLeft(Value,1)
          if NOT Sl_StatusEntrega.find(Value,idx) then
            FormAtivo.Cl_Dados.Cancel
            vCl_DadosExecutaScroll = true
            vCl_OrdemExecutaScroll = true
            RaiseException("Status selecionado é inválida!")
          Else
            With Cl_FS_PedProgEntrega
              Close
              Open
              IF RecordCount <= 0 Then
                Cl_FS_PedProgEntrega.Insert
                FieldByName("ORG_TAB_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
                FieldByName("ORG_PAD_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
                FieldByName("ORG_IN_CODIGO").Value         = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
                FieldByName("ORG_TAU_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
                FieldByName("SER_ST_CODIGO").Value         = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
                FieldByName("PED_IN_CODIGO").Value         = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
                FieldByName("ITP_IN_SEQUENCIA").Value      = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
                FieldByName("IPE_IN_SEQUENCIA").Value      = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
              Else
                Cl_FS_PedProgEntrega.Edit
              End If
              FieldByName("IPE_CH_STATUS").Value = vOcorrencia
            End With
          End if
          Insere_Ocorrencia(vOcorrencia)
          DMMEGA.GravaRegistro([Cl_FS_PedProgEntrega])
        End With

        With FormAtivo
          With Cl_Dados
            IF vOcorrencia = "L" THEN
              IF FieldByName("BLO_CH_STATUSOE").Value = "S" THEN
                vGeraOE = "S"
              ELSE
                vGeraOE = "N"
              END IF
            ELSE
              vGeraOE = "S"
            END IF
            Cl_Dados.Edit
            FieldByName("BLO_CH_GEROE").Value = vGeraOE
            Cl_Dados.Post
          End With
        End With
      Else
        vOcorrencia = MgLeft(sender.Value,1)
        if NOT Sl_StatusEntrega.find(sender.Value,idx) then
          FormAtivo.Cl_Dados.Cancel
          vCl_DadosExecutaScroll = true
          vCl_OrdemExecutaScroll = true
          RaiseException("Status selecionado é inválida!")
        Else
          With Cl_FS_PRC_PEDPROENTREGA
            ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
            ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
            ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
            ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
            ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
            ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
            ParamByName("pOCORRENCIA").Value        = vOcorrencia
            ParamByName("pMOTIVO").Value            = "Alteração de Status de Entrega no Pedido!"
            ParamByName("pUSUARIO").Value           = Dmmega.Usuario
            ExecSQL
          End With
          With FormAtivo
            With Cl_Dados
              Close
              Open
            End With
          End With
        End if
      End if
    Else
      FormAtivo.Cl_Dados.Cancel
      vCl_DadosExecutaScroll = true
      vCl_OrdemExecutaScroll = true
      RaiseException("Usuário sem permissão para este tipo de operação!")
    End if
  Else
    FormAtivo.Cl_Dados.Cancel
    vCl_DadosExecutaScroll = true
    vCl_OrdemExecutaScroll = true
    RaiseException("Alteração não pode ser realizada para esta programação de entrega!")
  End if
  vCl_DadosExecutaScroll = true
  vCl_OrdemExecutaScroll = true
End Sub

Sub PedidoParcial_OnAfterChange(sender as TMgStringField)
  Dim nORG_TAB_IN_CODIGO, _
      nORG_PAD_IN_CODIGO, _
      nORG_IN_CODIGO    , _
      cORG_TAU_ST_CODIGO, _
      cSER_ST_CODIGO    , _
      nPED_IN_CODIGO    , _
      cPED_BO_PARCIAL  AS String = sender.Value, _
      vGerencia    = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S"), _
      vRedistribui = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S"), _
      vVisualiza   = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_VISUALIZA").Value   = "S")

  TmgStringField(FormAtivo.Cl_Dados.FieldByName("PED_BO_PARCIAL")).OnAfterChange = nil

  vCl_DadosExecutaScroll = false
  If FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "F" then
    If (vGerencia or vRedistribui) then
      If(MessageDlg("Confirma alteração do status 'Aceita parcial?' do Pedido: " & IntToStr(FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value) & "? ", 3, 3, 0) = MrNo) Then
        FormAtivo.Cl_Dados.Cancel
        vCl_DadosExecutaScroll = true
        Exit
      Else
        nORG_TAB_IN_CODIGO = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
        nORG_PAD_IN_CODIGO = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
        nORG_IN_CODIGO     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
        cORG_TAU_ST_CODIGO = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
        cSER_ST_CODIGO     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
        nPED_IN_CODIGO     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value

        With Cl_Fs_PedidoVenda
          Close
          Open
          If RecordCount > 0 then
              Cl_Fs_PedidoVenda.Edit
              FieldByName("PED_BO_PARCIAL").Value = cPED_BO_PARCIAL
              Cl_Fs_PedidoVenda.Post
          Else
            Cl_Fs_PedidoVenda.Insert
            FieldByName("ORG_TAB_IN_CODIGO").Value = nORG_TAB_IN_CODIGO
            FieldByName("ORG_PAD_IN_CODIGO").Value = nORG_PAD_IN_CODIGO
            FieldByName("ORG_IN_CODIGO").Value     = nORG_IN_CODIGO
            FieldByName("ORG_TAU_ST_CODIGO").Value = cORG_TAU_ST_CODIGO
            FieldByName("SER_ST_CODIGO").Value     = cSER_ST_CODIGO
            FieldByName("PED_IN_CODIGO").Value     = nPED_IN_CODIGO
            FieldByName("PED_BO_PARCIAL").Value    = cPED_BO_PARCIAL
          End if
        End With

        DMMega.GravaRegistro([Cl_Fs_PedidoVenda])

        With FormAtivo
          With Cl_Dados
            Cl_Dados.First
            With Cl_Dados
              While NOT EOF
                If (FieldByName("ORG_TAB_IN_CODIGO").Value = nORG_TAB_IN_CODIGO) AND _
                   (FieldByName("ORG_PAD_IN_CODIGO").Value = nORG_PAD_IN_CODIGO) AND _
                   (FieldByName("ORG_IN_CODIGO").Value     = nORG_IN_CODIGO)     AND _
                   (FieldByName("ORG_TAU_ST_CODIGO").Value = cORG_TAU_ST_CODIGO) AND _
                   (FieldByName("SER_ST_CODIGO").Value     = cSER_ST_CODIGO)     AND _
                   (FieldByName("PED_IN_CODIGO").Value     = nPED_IN_CODIGO)     Then
                    Insere_Ocorrencia("M")
                    Cl_Dados.Edit
                    FieldByName("PED_BO_PARCIAL").Value = cPED_BO_PARCIAL
                    Cl_Dados.Post
                End If
                Cl_Dados.Next
              Wend
            End With
          End With
        End With
        MessageDlg("Operação Concluída!", mtInformation, mbOk, 0)
      End If
    Else
      FormAtivo.Cl_Dados.Cancel
      vCl_DadosExecutaScroll = true
      TmgStringField(FormAtivo.Cl_Dados.FieldByName("PED_BO_PARCIAL")).OnAfterChange = AddressOf PedidoParcial_OnAfterChange()
      RaiseException("Usuário sem permissão para este tipo de operação!")
    End If
  Else
    FormAtivo.Cl_Dados.Cancel
    vCl_DadosExecutaScroll = true
    TmgStringField(FormAtivo.Cl_Dados.FieldByName("PED_BO_PARCIAL")).OnAfterChange = AddressOf PedidoParcial_OnAfterChange()
    RaiseException("Alteração não pode ser realizada para esta programação de entrega!")
  End if
  vCl_DadosExecutaScroll = true
  TmgStringField(FormAtivo.Cl_Dados.FieldByName("PED_BO_PARCIAL")).OnAfterChange = AddressOf PedidoParcial_OnAfterChange()
End Sub

Sub DataEntrega_OnAfterChange(sender as TMgStringField)
  Dim idx, _
      vGerencia    = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S"), _
      vRedistribui = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S"), _
      vVisualiza   = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_VISUALIZA").Value   = "S")

  TMgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAENTREGA")).OnAfterChange = nil

  vCl_DadosExecutaScroll = false
  vCl_OrdemExecutaScroll = false
  if TMgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAENTREGA")).Value <> Null then
    If(FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "F") then
      If(vGerencia or vRedistribui)then
        If(MessageDlg("Deseja alterar a data de entrega de todos os itens do pedido: " & IntToStr(FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value) & "? ", 3, 3, 0) = MrNo) Then
          With sender
            With Cl_Programacao
              Close
              ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
              ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
              ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
              ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
              ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
              ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
              ParamByName("pITP_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
              ParamByName("pIPE_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
              Open
            End With
            Cl_Programacao.Edit
            Cl_Programacao.FieldByName("IPE_DT_DATAENTREGA").Value   = Value
            Cl_Programacao.FieldByName("IPE_DT_DATAEXPEDICAO").Value = Value
            Cl_Programacao.Post
            Insere_Ocorrencia("D")
          End With
          DMMega.GravaRegistro([Cl_Programacao])
        Else
          With sender
            With Cl_FS_PRC_PEDPROENTREGADATA
              ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
              ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
              ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
              ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
              ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
              ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
              ParamByName("pDATA_ENTREGA").Value      = sender.Value
              ParamByName("pUSUARIO").Value           = Dmmega.Usuario
              ExecSQL
            End With
          End With

          With FormAtivo
            With Cl_Dados
              Close
              Open
            End With
          End With

          MessageDlg("Operação Concluída!", mtInformation, mbOk, 0)

        End If
      Else
        FormAtivo.Cl_Dados.Cancel
        vCl_DadosExecutaScroll = true
        TmgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAENTREGA")).OnAfterChange = AddressOf DataEntrega_OnAfterChange()
        RaiseException("Usuário sem permissão para este tipo de operação!")
      End If
    Else
      FormAtivo.Cl_Dados.Cancel
      vCl_DadosExecutaScroll = true
      TmgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAENTREGA")).OnAfterChange = AddressOf DataEntrega_OnAfterChange()
      RaiseException("Alteração não pode ser realizada para esta programação de entrega!")
    End if
  Else
    FormAtivo.Cl_Dados.Cancel
    vCl_DadosExecutaScroll = true
    TmgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAENTREGA")).OnAfterChange = AddressOf DataEntrega_OnAfterChange()
    RaiseException("Data deve ser informada!")
  End If
  TmgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAENTREGA")).OnAfterChange = AddressOf DataEntrega_OnAfterChange()
  vCl_DadosExecutaScroll = true
End Sub

Sub DataCliente_OnAfterChange(sender as TMgStringField)
  Dim idx, _
      vGerencia    = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S"), _
      vRedistribui = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S"), _
      vVisualiza   = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_VISUALIZA").Value   = "S")

  TMgStringField(FormAtivo.Cl_Dados.FieldByName("DATA_CLIENTE")).OnAfterChange = nil

  vCl_DadosExecutaScroll = false
  vCl_OrdemExecutaScroll = false
  if TMgStringField(FormAtivo.Cl_Dados.FieldByName("DATA_CLIENTE")).Value <> Null then
    If(FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "F") then
      If(vGerencia or vRedistribui)then
        If(MessageDlg("Deseja alterar a data do Cliente de todos os itens do pedido: " & IntToStr(FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value) & "? ", 3, 3, 0) = MrYes) Then
          With sender
            With Cl_FS_PRC_PEDPROENTREGADATACLIENTE
              ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
              ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
              ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
              ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
              ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
              ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
              ParamByName("pITP_IN_SEQUENCIA").Value  = Null
              ParamByName("pIPE_IN_SEQUENCIA").Value  = Null
              ParamByName("pDATA_CLIENTE").Value      = sender.Value
              ParamByName("pUSUARIO").Value           = Dmmega.Usuario
              ExecSQL
            End With
          End With
        Else
          With sender
            With Cl_FS_PRC_PEDPROENTREGADATACLIENTE
              ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
              ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
              ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
              ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
              ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
              ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
              ParamByName("pITP_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
              ParamByName("pIPE_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
              ParamByName("pDATA_CLIENTE").Value      = sender.Value
              ParamByName("pUSUARIO").Value           = Dmmega.Usuario
              ExecSQL
            End With
          End With

          With FormAtivo
            With Cl_Dados
              Close
              Open
            End With
          End With

          MessageDlg("Operação Concluída!", mtInformation, mbOk, 0)

        End If
      Else
        FormAtivo.Cl_Dados.Cancel
        vCl_DadosExecutaScroll = true
        TmgStringField(FormAtivo.Cl_Dados.FieldByName("DATA_CLIENTE")).OnAfterChange = AddressOf DataCliente_OnAfterChange()
        RaiseException("Usuário sem permissão para este tipo de operação!")
      End If
    Else
      FormAtivo.Cl_Dados.Cancel
      vCl_DadosExecutaScroll = true
      TmgStringField(FormAtivo.Cl_Dados.FieldByName("DATA_CLIENTE")).OnAfterChange = AddressOf DataCliente_OnAfterChange()
      RaiseException("Alteração não pode ser realizada para esta programação de entrega!")
    End if
  Else
    FormAtivo.Cl_Dados.Cancel
    vCl_DadosExecutaScroll = true
    TmgStringField(FormAtivo.Cl_Dados.FieldByName("DATA_CLIENTE")).OnAfterChange = AddressOf DataCliente_OnAfterChange()
    RaiseException("Data deve ser informada!")
  End If
  TmgStringField(FormAtivo.Cl_Dados.FieldByName("DATA_CLIENTE")).OnAfterChange = AddressOf DataCliente_OnAfterChange()
  vCl_DadosExecutaScroll = true
End Sub

Sub DataExpedicao_OnAfterChange(sender as TMgStringField)
  Dim idx, _
      vGerencia    = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S"), _
      vRedistribui = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S"), _
      vVisualiza   = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_VISUALIZA").Value   = "S")

  TMgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAEXPEDICAO")).OnAfterChange = nil

  if TMgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAEXPEDICAO")).Value <> Null then
    vCl_DadosExecutaScroll = false
    vCl_OrdemExecutaScroll = false
    If(FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "F") then
      If(vGerencia or vRedistribui)then
        If(MessageDlg("Deseja alterar a data de expedição de todos os itens do pedido: " & IntToStr(FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value) & "? ", 3, 3, 0) = MrNo) Then
          With sender
            With Cl_FS_PRC_PEDPROGDATAEXP
              ParamByName("pORG_TAB_IN_CODIGO").Value   = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
              ParamByName("pORG_PAD_IN_CODIGO").Value   = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
              ParamByName("pORG_IN_CODIGO").Value       = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
              ParamByName("pORG_TAU_ST_CODIGO").Value   = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
              ParamByName("pSER_ST_CODIGO").Value       = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
              ParamByName("pPED_IN_CODIGO").Value       = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
              ParamByName("pITP_IN_SEQUENCIA").Value    = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
              ParamByName("pIPE_IN_SEQUENCIA").Value    = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
              ParamByName("IPE_DT_DATAEXPEDICAO").Value = sender.Value
              ParamByName("pUSU_IN_CODIGO").Value       = DMMega.Usuario
              ExecSQL
            End With
          End With
        Else
          With sender
            With Cl_FS_PRC_PEDPROGDATAEXP
              ParamByName("pORG_TAB_IN_CODIGO").Value    = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
              ParamByName("pORG_PAD_IN_CODIGO").Value    = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
              ParamByName("pORG_IN_CODIGO").Value        = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
              ParamByName("pORG_TAU_ST_CODIGO").Value    = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
              ParamByName("pSER_ST_CODIGO").Value        = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
              ParamByName("pPED_IN_CODIGO").Value        = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
              ParamByName("pITP_IN_SEQUENCIA").Value     = nil
              ParamByName("pIPE_IN_SEQUENCIA").Value     = nil
              ParamByName("pIPE_DT_DATAEXPEDICAO").Value = sender.Value
              ParamByName("pUSU_IN_CODIGO").Value        = DMMega.Usuario
              ExecSQL
            End With
          End With

          With FormAtivo
            With Cl_Dados
              Close
              Open
            End With
          End With

          MessageDlg("Operação Concluída!", mtInformation, mbOk, 0)

        End If
      Else
        FormAtivo.Cl_Dados.Cancel
        vCl_DadosExecutaScroll = true
        TmgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAEXPEDICAO")).OnAfterChange = AddressOf DataExpedicao_OnAfterChange()
        RaiseException("Usuário sem permissão para este tipo de operação!")
      End If
    Else
      FormAtivo.Cl_Dados.Cancel
      vCl_DadosExecutaScroll = true
      TmgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAEXPEDICAO")).OnAfterChange = AddressOf DataExpedicao_OnAfterChange()
      RaiseException("Alteração não pode ser realizada para esta programação de entrega!")
    End if
  Else
    FormAtivo.Cl_Dados.Cancel
    vCl_DadosExecutaScroll = true
    TmgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAEXPEDICAO")).OnAfterChange = AddressOf DataExpedicao_OnAfterChange()
    RaiseException("Data deve ser informada!")
  End If
  TmgStringField(FormAtivo.Cl_Dados.FieldByName("IPE_DT_DATAEXPEDICAO")).OnAfterChange = AddressOf DataExpedicao_OnAfterChange()
  vCl_DadosExecutaScroll = true
End Sub


Sub GeraOE(DataSet as TmgClientDataSet, pReservaAutomatica as String, pRES_IN_CODIGO AS INTEGER)
Dim vSEQ_IN_CODIGO_RET, vEXP_IN_SEQUENCIA_RET, vEXP_IN_CODIGO_RET
  With FormAtivo
    vCl_DadosExecutaScroll = false
    vCl_OrdemExecutaScroll = false
    Try
      With Cl_IntegraOe
        ParamByName("pORG_TAB_IN_CODIGO").Value    = DataSet.FieldByName("ORG_TAB_IN_CODIGO").Value
        ParamByName("pORG_PAD_IN_CODIGO").Value    = DataSet.FieldByName("ORG_PAD_IN_CODIGO").Value
        ParamByName("pORG_IN_CODIGO").Value        = DataSet.FieldByName("ORG_IN_CODIGO").Value
        ParamByName("pORG_TAU_ST_CODIGO").Value    = DataSet.FieldByName("ORG_TAU_ST_CODIGO").Value
        ParamByName("pFIL_IN_CODIGO").Value        = DataSet.FieldByName("FIL_IN_CODIGO").Value
        ParamByName("pSER_ST_CODIGO").Value        = DataSet.FieldByName("SER_ST_CODIGO").Value
        ParamByName("pPED_IN_CODIGO").Value        = DataSet.FieldByName("PED_IN_CODIGO").Value
        ParamByName("pITP_IN_SEQUENCIA").Value     = DataSet.FieldByName("ITP_IN_SEQUENCIA").Value
        ParamByName("pIPE_IN_SEQUENCIA").Value     = DataSet.FieldByName("IPE_IN_SEQUENCIA").Value
        ParamByName("pIPE_RE_QUANTIDADE").Value    = DataSet.FieldByName("IPE_RE_QUANTIDADE").Value
        ParamByName("pEXP_DT_EMISSAO").Value       = Date
        ParamByName("pTRA_IN_CODIGO").Value        = DataSet.FieldByName("TRA_IN_CODIGO").Value
        ParamByName("pEXP_IN_CODIGO").Value        = null
        ParamByName("pReservaAutomatica").Value    = pReservaAutomatica
        ParamByName("pUSU_IN_CODIGO").Value        = DMMega.Usuario
        ParamByName("pOPERACAO").Value             = "I"
        ParamByName("pRES_IN_CODIGO").Value        = pRES_IN_CODIGO
        ParamByName("pSEQ_IN_CODIGO_RET").Value    = vSEQ_IN_CODIGO_RET
        ParamByName("pEXP_IN_SEQUENCIA_RET").Value = vEXP_IN_SEQUENCIA_RET
        ParamByName("pEXP_IN_CODIGO_RET").Value    = vEXP_IN_CODIGO_RET
        ExecSQL
      End With
    Catch
      IF pReservaAutomatica = "N" Then
        MessageDlg("Não foi possível gerar OE! Verifique o histórico de ocorrências.", mtError, mbOk, 0)
        vCl_DadosExecutaScroll = true
        vCl_OrdemExecutaScroll = true
        Exit
      End If
      vCl_DadosExecutaScroll = true
      vCl_OrdemExecutaScroll = true
    End Try
  End With
End Sub

Sub Insere_Ocorrencia(TipoOcorrencia as String)
  Dim Sequencia = 0
  vCl_OrdemExecutaScroll = false
  With Cl_FS_PedProgEntregaOco
    Close
    Open
    Last
    If FieldByName("IPE_IN_OCORRENCIA").Value > 0 Then
      Sequencia = FieldByName("IPE_IN_OCORRENCIA").Value
    end if
    Sequencia = Sequencia + 1
    Cl_FS_PedProgEntregaOco.Insert
    FieldByName("ORG_TAB_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
    FieldByName("ORG_PAD_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
    FieldByName("ORG_IN_CODIGO").Value         = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
    FieldByName("ORG_TAU_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
    FieldByName("SER_ST_CODIGO").Value         = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
    FieldByName("PED_IN_CODIGO").Value         = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
    FieldByName("ITP_IN_SEQUENCIA").Value      = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
    FieldByName("IPE_IN_SEQUENCIA").Value      = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
    FieldByName("IPE_CH_TIPOOCORRENCIA").Value = TipoOcorrencia
    FieldByName("IPE_IN_OCORRENCIA").Value     = Sequencia
    FieldByName("IPE_DT_OCORRENCIA").Value     = Now
    FieldByName("USU_IN_CODIGO").Value         = DMMega.Usuario

    If(TipoOcorrencia="B") OR (TipoOcorrencia = "L") then
      ExecutaForm("FORM_FS_PEDPROGENTREGA_OCORRENCIA").ShowModal
    Else
      With Cl_TipoOcorrencias
        Close
        ParamByName("pTipoOcorrencia").Value = TipoOcorrencia
        Open
      End With
      if Cl_TipoOcorrencias.RecordCount > 0 then
        IF TipoOcorrencia = "M" THEN
          if FormAtivo.Cl_Dados.FieldByName("PED_BO_PARCIAL").Value = "N" THEN
            FieldByName("IPE_ST_OCORRENCIA").Value = "Pedido alterado para não aceitar parcial."
          else
            FieldByName("IPE_ST_OCORRENCIA").Value = "Pedido alterado para aceitar parcial."
          end if
        Else
          FieldByName("IPE_ST_OCORRENCIA").Value = Cl_TipoOcorrencias.FieldByName("MOTIVO").Value
        End If
      end if
    End If
  End With
  Dmmega.GravaRegistro([Cl_FS_PedProgEntregaOco])
End Sub

Sub Cl_Programacao_Open(sequencia)
  Dim Idx
  vCl_OrdemExecutaScroll = false
  With Cl_Programacao
    Close
    ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
    ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
    ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
    ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
    ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
    ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
    ParamByName("pITP_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
    ParamByName("pIPE_IN_SEQUENCIA").Value  = sequencia
    Open
  End With
End Sub

Sub Cl_OnBeforeOpen(sender as TMgClientDataSet)
  vCl_OrdemExecutaScroll = false
  With sender
    ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
    ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
    ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
    ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
    ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
    ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
    ParamByName("pITP_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
    ParamByName("pIPE_IN_SEQUENCIA").Value  = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
  End With
End Sub

Sub Cl_Dados_OnAfterScroll(sender as TmgClientDataSet)
  if vCl_DadosExecutaScroll then
    vCl_OrdemExecutaScroll = false
    With Cl_OrdemExpedicao
      Close
      Open
    End With
    With Cl_NotaFiscal
      Close
      Open
    End With
    vCl_OrdemExecutaScroll = true
    Cl_OrdemExpedicao_OnAfterScroll(Cl_OrdemExpedicao)
  End If
End Sub

Sub Cl_OrdemExpedicao_OnBeforeOpen(sender as TmgClientDataSet)
  vCl_OrdemExecutaScroll = false
  With sender
    DisableControls
    ParamByName("pORG_TAB_IN_CODIGO").Value  = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
    ParamByName("pORG_PAD_IN_CODIGO").Value  = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
    ParamByName("pORG_IN_CODIGO").Value      = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
    ParamByName("pORG_TAU_ST_CODIGO").Value  = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
    ParamByName("pSER_ST_CODIGO").Value      = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
    ParamByName("pPED_IN_CODIGO").Value      = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
    ParamByName("pITP_IN_SEQUENCIA").Value   = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
    ParamByName("pIPE_IN_SEQUENCIA").Value   = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
  End With
End Sub

Sub Cl_NotaFiscal_OnAfterOpen(sender as TmgClientDataSet)
  Dim nField, nIdx
  With sender
    For nField=0 to FieldCount - 1
      Fields[nField].Visible = false
    Next

    nIdx =  0
    FieldByName("NOT_IN_NUMERO").DisplayLabel = "Nº da Nota"
    FieldByName("NOT_IN_NUMERO").DisplayWidth = 15
    FieldByName("NOT_IN_NUMERO").Visible      = true
    FieldByName("NOT_IN_NUMERO").Index        = nIdx

    nIdx = nIdx + 1
    FieldByName("NOT_DT_EMISSAO").DisplayLabel = "Dt. Emissão"
    FieldByName("NOT_DT_EMISSAO").DisplayWidth = 15
    FieldByName("NOT_DT_EMISSAO").Visible      = true
    FieldByName("NOT_DT_EMISSAO").Index        = nIdx

    nIdx = nIdx + 1
    FieldByName("NOT_RE_VALORTOTAL").DisplayLabel = "Valor Total"
    FieldByName("NOT_RE_VALORTOTAL").DisplayWidth = 15
    FieldByName("NOT_RE_VALORTOTAL").Visible      = true
    FieldByName("NOT_RE_VALORTOTAL").Index        = nIdx
    TmgFloatField(FieldByName("NOT_RE_VALORTOTAL")).DisplayFormat = "###,##0.00"

    Tv_NotaFiscal.DataController.CreateAllItems(True)

  End With
End Sub

Sub Cl_OrdemExpedicao_OnAfterOpen(sender as TmgClientDataSet)
  Dim nField, nIdx
  With sender
    For nField=0 to FieldCount - 1
      Fields[nField].Visible = false
    Next

    nIdx =  0
    FieldByName("EXP_IN_CODIGO").DisplayLabel = "Cód. OE"
    FieldByName("EXP_IN_CODIGO").DisplayWidth = 10
    FieldByName("EXP_IN_CODIGO").Visible      = true
    FieldByName("EXP_IN_CODIGO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("EXP_IN_SEQUENCIA").DisplayLabel = "Seq. OE"
    FieldByName("EXP_IN_SEQUENCIA").DisplayWidth = 10
    FieldByName("EXP_IN_SEQUENCIA").Visible      = true
    FieldByName("EXP_IN_SEQUENCIA").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("EXP_DT_EMISSAO").DisplayLabel = "Dt. Emissão"
    FieldByName("EXP_DT_EMISSAO").DisplayWidth = 10
    FieldByName("EXP_DT_EMISSAO").Visible      = true
    FieldByName("EXP_DT_EMISSAO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("EXP_RE_QTDEFATURAR").DisplayLabel = "Qtde. Faturar"
    FieldByName("EXP_RE_QTDEFATURAR").DisplayWidth = 13
    FieldByName("EXP_RE_QTDEFATURAR").Visible      = true
    FieldByName("EXP_RE_QTDEFATURAR").Index        = nIdx
    TmgFloatField(FieldByName("EXP_RE_QTDEFATURAR")).DisplayFormat = "###,##0.00"

    nIdx =  nIdx + 1
    FieldByName("EXP_RE_QTDEFATURADA").DisplayLabel = "Qtde. Faturada"
    FieldByName("EXP_RE_QTDEFATURADA").DisplayWidth = 13
    FieldByName("EXP_RE_QTDEFATURADA").Visible      = true
    FieldByName("EXP_RE_QTDEFATURADA").Index        = nIdx
    TmgFloatField(FieldByName("EXP_RE_QTDEFATURADA")).DisplayFormat = "###,##0.00"

    nIdx =  nIdx + 1
    FieldByName("ORDEM_COLETA").DisplayLabel = "Cód. Coleta"
    FieldByName("ORDEM_COLETA").DisplayWidth = 10
    FieldByName("ORDEM_COLETA").Visible      = true
    FieldByName("ORDEM_COLETA").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("STATUS_OE").DisplayLabel = "Status da OE"
    FieldByName("STATUS_OE").DisplayWidth = 20
    FieldByName("STATUS_OE").Visible      = true
    FieldByName("STATUS_OE").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("STATUS_COLETA").DisplayLabel = "Status Romaneio"
    FieldByName("STATUS_COLETA").DisplayWidth = 20
    FieldByName("STATUS_COLETA").Visible      = true
    FieldByName("STATUS_COLETA").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("QTDE_TESTA").DisplayLabel = "Qtde. Testa"
    FieldByName("QTDE_TESTA").DisplayWidth = 11
    FieldByName("QTDE_TESTA").Visible      = true
    FieldByName("QTDE_TESTA").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("QTDE_ESTOQUE").DisplayLabel = "Qtde. Estoque"
    FieldByName("QTDE_ESTOQUE").DisplayWidth = 11
    FieldByName("QTDE_ESTOQUE").Visible      = true
    FieldByName("QTDE_ESTOQUE").Index        = nIdx

    Tv_OrdemExpedicao.DataController.CreateAllItems(True)

    vCl_OrdemExecutaScroll = true
    EnableControls
  End With

End Sub

Sub Cl_Lk_Representante_OnAfterOpen(sender as TmgClientDataSet)
  Dim nIdx
  With sender
    For nIdx=0 to FieldCount - 1
      Fields[nIdx].Visible = false
    Next

    nIdx = 0
    FieldByName("AGN_IN_CODIGO").DisplayLabel = "Cód. Representante"
    FieldByName("AGN_IN_CODIGO").Visible      = true
    FieldByName("AGN_IN_CODIGO").Index        = nIdx

    nIdx = nIdx + 1
    FieldByName("AGN_ST_NOME").DisplayLabel = "Nome Representante"
    FieldByName("AGN_ST_NOME").Visible      = true
    FieldByName("AGN_ST_NOME").Index        = nIdx
  End With
End Sub

Sub Cl_OrdemExpedicao_OnAfterScroll(sender as TmgClientDataSet)
  if vCl_OrdemExecutaScroll then
    Dim vGerencia    = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S"), _
        vRedistribui = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S"), _
        vVisualiza   = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_VISUALIZA").Value   = "S"), _
        '// vValidaQtde  = (FormAtivo.Cl_Dados.FieldByName("IPE_RE_QUANTIDADE").Value > sender.FieldByName("QTDE_RESERVADA").Value)
        Dim vValidaQtde = FormAtivo.Cl_Dados.FieldByName("IPE_RE_SALDO").Value  > 0

        FormAtivo.Bt_Reserva.Enabled          = (vGerencia or vRedistribui)
        FormAtivo.Bt_AlteraEmbalagem.Enabled  = (vGerencia or vRedistribui)

    With sender
      IF((FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "F") AND _
         (FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "C") AND _
         (FormAtivo.Cl_Dados.FieldByName("PED_CH_STATUS").Value <> "B")) Then
        IF FieldByName("EXP_CH_STATUS").Value = "N" THEN
          IF FieldByName("COL_CH_STATUS").Value = "N" THEN
            FormAtivo.Bt_ExcluirOE.Enabled         = (vGerencia or vRedistribui)
            FormAtivo.Bt_DistribuirReserva.Enabled = (vGerencia or vRedistribui)
          ELSE
            FormAtivo.Bt_ExcluirOE.Enabled         = false
            FormAtivo.Bt_DistribuirReserva.Enabled = false
          END IF
          FormAtivo.Bt_GerarOE.Enabled           = vValidaQtde
        Else
          FormAtivo.Bt_GerarOE.Enabled           = (vValidaQtde AND (vGerencia or vRedistribui))
          FormAtivo.Bt_ExcluirOE.Enabled         = false
          FormAtivo.Bt_DistribuirReserva.Enabled = false
        End If
      Else
          FormAtivo.Bt_ExcluirOE.Enabled         = false
          FormAtivo.Bt_DistribuirReserva.Enabled = false
          FormAtivo.Bt_GerarOE.Enabled           = false
          FormAtivo.Bt_Reserva.Enabled           = false
      End If
    End With
    With Cl_NotaFiscal
      Close
      Open
    End With
  End If
End Sub

Sub Cl_Dados_OnAfterOpen(sender as TMgClientDataSet)
  Dim nField, nIdx

  vCl_DadosExecutaScroll = false

  With sender

    TMgStringField(FieldByName("PRIORIDADE")).OnAfterChange           = nil
    TMgStringField(FieldByName("IPE_ST_STATUS")).OnAfterChange        = nil
    TMgStringField(FieldByName("IPE_DT_DATAENTREGA")).OnAfterChange   = nil
    TMgStringField(FieldByName("IPE_DT_DATAEXPEDICAO")).OnAfterChange = nil
    TMgStringField(FieldByName("IPE_RE_QUANTIDADE")).OnAfterChange    = nil
    TMgStringField(FieldByName("PED_BO_PARCIAL")).OnAfterChange       = nil

    For nField=0 to FieldCount - 1
      Fields[nField].Visible = false
    Next

    nIdx =  0
    FieldByName("MERCADO").DisplayLabel = "Mercado"
    FieldByName("MERCADO").DisplayWidth = 10
    FieldByName("MERCADO").Visible      = true
    FieldByName("MERCADO").Index        = nIdx

    nIdx =  nIdx + 1

    FieldByName("PED_IN_CODIGO").DisplayLabel = "Nº. Pedido"
    FieldByName("PED_IN_CODIGO").DisplayWidth = 10
    FieldByName("PED_IN_CODIGO").Visible      = true
    FieldByName("PED_IN_CODIGO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("TPD_ST_DESCRICAO").DisplayLabel = "Tipo de Pedido"
    FieldByName("TPD_ST_DESCRICAO").DisplayWidth = 25
    FieldByName("TPD_ST_DESCRICAO").Visible      = true
    FieldByName("TPD_ST_DESCRICAO").Index        = nIdx


    nIdx =  nIdx + 1
    FieldByName("PED_CH_SITUACAO").DisplayLabel = "Status"
    FieldByName("PED_CH_SITUACAO").Visible      = true
    FieldByName("PED_CH_SITUACAO").Index        = nIdx
    FieldByName("PED_CH_SITUACAO").DisplayWidth = 25

    nIdx =  nIdx + 1
    FieldByName("PED_DT_EMISSAO").DisplayLabel   = "Emissão"
    FieldByName("PED_DT_EMISSAO").DisplayWidth   = 10
    FieldByName("PED_DT_EMISSAO").Visible        = true
    FieldByName("PED_DT_EMISSAO").Index          = nIdx


    nIdx =  nIdx + 1
    FieldByName("VEN_AGN_IN_CODIGO").DisplayLabel = "Vend."
    FieldByName("VEN_AGN_IN_CODIGO").DisplayWidth = 5
    FieldByName("VEN_AGN_IN_CODIGO").Visible      = true
    FieldByName("VEN_AGN_IN_CODIGO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("VEN_AGN_ST_NOME").DisplayLabel = "Nome Vend."
    FieldByName("VEN_AGN_ST_NOME").DisplayWidth = 20
    FieldByName("VEN_AGN_ST_NOME").Visible      = true
    FieldByName("VEN_AGN_ST_NOME").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("CLI_IN_CODIGO").DisplayLabel = "Cód.Cli"
    FieldByName("CLI_IN_CODIGO").DisplayWidth = 5
    FieldByName("CLI_IN_CODIGO").Visible      = true
    FieldByName("CLI_IN_CODIGO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("CLI_ST_NOME").DisplayLabel = "Nome Cli."
    FieldByName("CLI_ST_NOME").DisplayWidth = 20
    FieldByName("CLI_ST_NOME").Visible      = true
    FieldByName("CLI_ST_NOME").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("UF_ST_SIGLA").DisplayLabel = "UF"
    FieldByName("UF_ST_SIGLA").DisplayWidth = 2
    FieldByName("UF_ST_SIGLA").Visible      = true
    FieldByName("UF_ST_SIGLA").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("MUN_ST_NOME").DisplayLabel = "Mun."
    FieldByName("MUN_ST_NOME").DisplayWidth = 15
    FieldByName("MUN_ST_NOME").Visible      = true
    FieldByName("MUN_ST_NOME").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("COND_ST_NOME").DisplayLabel = "Cond.Pag."
    FieldByName("COND_ST_NOME").DisplayWidth = 10
    FieldByName("COND_ST_NOME").Visible      = true
    FieldByName("COND_ST_NOME").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("PED_ST_TIPOFRETE").DisplayLabel = "Frete"
    FieldByName("PED_ST_TIPOFRETE").DisplayWidth = 5
    FieldByName("PED_ST_TIPOFRETE").Visible      = true
    FieldByName("PED_ST_TIPOFRETE").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("TRA_ST_NOME").DisplayLabel = "Transp."
    FieldByName("TRA_ST_NOME").DisplayWidth = 20
    FieldByName("TRA_ST_NOME").Visible      = true
    FieldByName("TRA_ST_NOME").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("ITP_IN_SEQUENCIA").DisplayLabel = "Seq.Item"
    FieldByName("ITP_IN_SEQUENCIA").DisplayWidth = 5
    FieldByName("ITP_IN_SEQUENCIA").Visible      = true
    FieldByName("ITP_IN_SEQUENCIA").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("PRO_IN_CODIGO").DisplayLabel = "Cód.Item"
    FieldByName("PRO_IN_CODIGO").DisplayWidth = 5
    FieldByName("PRO_IN_CODIGO").Visible      = true
    FieldByName("PRO_IN_CODIGO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("PRO_ST_ALTERNATIVO").DisplayLabel = "Cód.Alt."
    FieldByName("PRO_ST_ALTERNATIVO").DisplayWidth = 10
    FieldByName("PRO_ST_ALTERNATIVO").Visible      = true
    FieldByName("PRO_ST_ALTERNATIVO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("PRO_ST_DESCRICAO").DisplayLabel = "Desc.Item"
    FieldByName("PRO_ST_DESCRICAO").DisplayWidth = 25
    FieldByName("PRO_ST_DESCRICAO").Visible      = true
    FieldByName("PRO_ST_DESCRICAO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("UNI_ST_UNIDADE").DisplayLabel = "Un."
    FieldByName("UNI_ST_UNIDADE").DisplayWidth = 5
    FieldByName("UNI_ST_UNIDADE").Visible      = true
    FieldByName("UNI_ST_UNIDADE").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("EMB_IN_CODIGO").DisplayLabel = "Cód.Emb."
    FieldByName("EMB_IN_CODIGO").DisplayWidth = 5
    FieldByName("EMB_IN_CODIGO").Visible      = true
    FieldByName("EMB_IN_CODIGO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("EMB_ST_DESCRICAO").DisplayLabel = "Embalagem"
    FieldByName("EMB_ST_DESCRICAO").DisplayWidth = 25
    FieldByName("EMB_ST_DESCRICAO").Visible      = true
    FieldByName("EMB_ST_DESCRICAO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("PEDIDO_INDISPONIVEL").DisplayLabel = "Indisponível"
    FieldByName("PEDIDO_INDISPONIVEL").DisplayWidth = 25
    FieldByName("PEDIDO_INDISPONIVEL").Visible      = true
    FieldByName("PEDIDO_INDISPONIVEL").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("NCM_ST_EXTENSO").DisplayLabel = "NCM do Item"
    FieldByName("NCM_ST_EXTENSO").DisplayWidth = 25
    FieldByName("NCM_ST_EXTENSO").Visible      = true
    FieldByName("NCM_ST_EXTENSO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("PED_BO_PARCIAL").DisplayLabel = "Parcial?"
    FieldByName("PED_BO_PARCIAL").DisplayWidth = 5
    FieldByName("PED_BO_PARCIAL").Visible      = true
    FieldByName("PED_BO_PARCIAL").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("MINIMO_3PC").DisplayLabel = "Min.3 Pçs"
    FieldByName("MINIMO_3PC").DisplayWidth = 3
    FieldByName("MINIMO_3PC").Visible      = true
    FieldByName("MINIMO_3PC").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("ITP_RE_QUANTIDADE").DisplayLabel = "Qtde.Ori"
    FieldByName("ITP_RE_QUANTIDADE").DisplayWidth = 10
    FieldByName("ITP_RE_QUANTIDADE").Visible      = true
    FieldByName("ITP_RE_QUANTIDADE").Index        = nIdx
    TmgFloatField(FieldByName("ITP_RE_QUANTIDADE")).DisplayFormat = "###,##0.0000"

    '//nIdx =  nIdx + 1
    '//FieldByName("IPE_RE_QUANTIDADE").DisplayLabel = "Qtde.Prog."
    '//FieldByName("IPE_RE_QUANTIDADE").DisplayWidth = 10
    '//FieldByName("IPE_RE_QUANTIDADE").Visible      = true
    '//FieldByName("IPE_RE_QUANTIDADE").Index        = nIdx
    '//TmgFloatField(FieldByName("IPE_RE_QUANTIDADE")).DisplayFormat = "###,##0.0000"

    nIdx =  nIdx + 1
    FieldByName("IPE_RE_QTDECONVERTIDA").DisplayLabel = "Qtde.Prog."
    FieldByName("IPE_RE_QTDECONVERTIDA").DisplayWidth = 10
    FieldByName("IPE_RE_QTDECONVERTIDA").Visible      = true
    FieldByName("IPE_RE_QTDECONVERTIDA").Index        = nIdx
    TmgFloatField(FieldByName("IPE_RE_QTDECONVERTIDA")).DisplayFormat = "###,##0.0000"

    nIdx =  nIdx + 1
    FieldByName("GER_RE_QUANTIDADE").DisplayLabel = "Qtde.Res"
    FieldByName("GER_RE_QUANTIDADE").DisplayWidth = 10
    FieldByName("GER_RE_QUANTIDADE").Visible      = true
    FieldByName("GER_RE_QUANTIDADE").Index        = nIdx
    TmgFloatField(FieldByName("GER_RE_QUANTIDADE")).DisplayFormat = "###,##0.0000"

    nIdx =  nIdx + 1
    FieldByName("IPE_RE_SALDO").DisplayLabel = "Qtde a Reservar"
    FieldByName("IPE_RE_SALDO").DisplayWidth = 15
    FieldByName("IPE_RE_SALDO").Visible      = true
    FieldByName("IPE_RE_SALDO").Index        = nIdx
    TmgFloatField(FieldByName("IPE_RE_SALDO")).DisplayFormat = "###,##0.0000"

    nIdx =  nIdx + 1
    FieldByName("ITP_RE_VALORUNITARIO").DisplayLabel = "Vlr Unitário"
    FieldByName("ITP_RE_VALORUNITARIO").DisplayWidth = 15
    FieldByName("ITP_RE_VALORUNITARIO").Visible      = true
    FieldByName("ITP_RE_VALORUNITARIO").Index        = nIdx
    TmgFloatField(FieldByName("ITP_RE_VALORUNITARIO")).DisplayFormat = "###,##0.0000"

    nIdx =  nIdx + 1
    FieldByName("IPE_RE_QTDEFATURADA").DisplayLabel = "Qtde. Faturada"
    FieldByName("IPE_RE_QTDEFATURADA").DisplayWidth = 10
    FieldByName("IPE_RE_QTDEFATURADA").Visible      = true
    FieldByName("IPE_RE_QTDEFATURADA").Index        = nIdx
    TmgFloatField(FieldByName("IPE_RE_QTDEFATURADA")).DisplayFormat = "###,##0.0000"

    nIdx =  nIdx + 1
    FieldByName("IPE_RE_QTDESALDO").DisplayLabel = "Qtde.a Faturar"
    FieldByName("IPE_RE_QTDESALDO").DisplayWidth = 10
    FieldByName("IPE_RE_QTDESALDO").Visible      = true
    FieldByName("IPE_RE_QTDESALDO").Index        = nIdx
    TmgFloatField(FieldByName("IPE_RE_QTDESALDO")).DisplayFormat = "###,##0.0000"

    nIdx =  nIdx + 1
    FieldByName("IPE_RE_QTDERESFAT").DisplayLabel = "Qtde.Res. a Fat."
    FieldByName("IPE_RE_QTDERESFAT").DisplayWidth = 10
    FieldByName("IPE_RE_QTDERESFAT").Visible      = true
    FieldByName("IPE_RE_QTDERESFAT").Index        = nIdx
    TmgFloatField(FieldByName("IPE_RE_QTDERESFAT")).DisplayFormat = "###,##0.0000"


    '// Matheus H. - Inclusão coluna em grid principal. | 22/04/2026
    nIdx =  nIdx + 1
    FieldByName("VALOR_RESERVADO_A_FATURAR").DisplayLabel = "Vlr. Reservado a Faturar"
    FieldByName("VALOR_RESERVADO_A_FATURAR").DisplayWidth = 20
    FieldByName("VALOR_RESERVADO_A_FATURAR").Visible      = true
    FieldByName("VALOR_RESERVADO_A_FATURAR").Index        = nIdx
    TmgFloatField(FieldByName("VALOR_RESERVADO_A_FATURAR")).DisplayFormat = "###,##0.0000"
    '// Matheus H. - Inclusão coluna em grid principal. | 22/04/2026

    nIdx =  nIdx + 1
    FieldByName("IPE_RE_SALDOMERCADORIA").DisplayLabel = "Saldo em R$"
    FieldByName("IPE_RE_SALDOMERCADORIA").DisplayWidth = 10
    FieldByName("IPE_RE_SALDOMERCADORIA").Visible      = true
    FieldByName("IPE_RE_SALDOMERCADORIA").Index        = nIdx
    TmgFloatField(FieldByName("IPE_RE_SALDOMERCADORIA")).DisplayFormat = "###,##0.0000"

    nIdx =  nIdx + 1
    FieldByName("IPE_DT_DATAENTREGA").DisplayLabel = "Dt.Ent."
    FieldByName("IPE_DT_DATAENTREGA").DisplayWidth = 10
    FieldByName("IPE_DT_DATAENTREGA").Visible      = true
    FieldByName("IPE_DT_DATAENTREGA").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("DATA_CLIENTE").DisplayLabel = "Dt.Cliente"
    FieldByName("DATA_CLIENTE").DisplayWidth = 10
    FieldByName("DATA_CLIENTE").Visible      = true
    FieldByName("DATA_CLIENTE").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("CTD_CH_DATA_HORIZONTE").DisplayLabel = "Dt.Horiz.?"
    FieldByName("CTD_CH_DATA_HORIZONTE").DisplayWidth = 10
    FieldByName("CTD_CH_DATA_HORIZONTE").Visible      = true
    FieldByName("CTD_CH_DATA_HORIZONTE").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("DATA_HORIZONTE").DisplayLabel = "Dt.Horiz."
    FieldByName("DATA_HORIZONTE").DisplayWidth = 10
    FieldByName("DATA_HORIZONTE").Visible      = true
    FieldByName("DATA_HORIZONTE").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("IPE_ST_TIPOENTREGA").DisplayLabel = "Tip.Ent."
    FieldByName("IPE_ST_TIPOENTREGA").DisplayWidth = 10
    FieldByName("IPE_ST_TIPOENTREGA").Visible      = true
    FieldByName("IPE_ST_TIPOENTREGA").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("IPE_DT_DATAEXPEDICAO").DisplayLabel = "Dt.Exp."
    FieldByName("IPE_DT_DATAEXPEDICAO").DisplayWidth = 10
    FieldByName("IPE_DT_DATAEXPEDICAO").Visible      = true
    FieldByName("IPE_DT_DATAEXPEDICAO").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("IPE_ST_STATUS").DisplayLabel = "Status Fat."
    FieldByName("IPE_ST_STATUS").DisplayWidth = 15
    FieldByName("IPE_ST_STATUS").Visible      = true
    FieldByName("IPE_ST_STATUS").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("PRIORIDADE").DisplayLabel = "Prioridade"
    FieldByName("PRIORIDADE").Visible      = true
    FieldByName("PRIORIDADE").Index        = nIdx

    /*Aqui*/
    nIdx =  nIdx + 1
    FieldByName("ITP_ST_PEDIDOCLIENTE").DisplayLabel = "OC. Cliente"
    FieldByName("ITP_ST_PEDIDOCLIENTE").DisplayWidth = 15
    FieldByName("ITP_ST_PEDIDOCLIENTE").Visible      = true
    FieldByName("ITP_ST_PEDIDOCLIENTE").Index        = nIdx

    nIdx =  nIdx + 1
    FieldByName("SALDO_ALM_DISP").DisplayLabel = "Disponível Oe"
    FieldByName("SALDO_ALM_DISP").DisplayWidth = 15
    FieldByName("SALDO_ALM_DISP").Visible      = true
    FieldByName("SALDO_ALM_DISP").Index        = nIdx

    TMgStringField(FieldByName("PRIORIDADE")).OnAfterChange            = AddressOf Prioridade_OnAfterChange()
    TMgStringField(FieldByName("IPE_ST_STATUS")).OnAfterChange         = AddressOf StatusPedido_OnAfterChange()
    TMgStringField(FieldByName("IPE_DT_DATAENTREGA")).OnAfterChange    = AddressOf DataEntrega_OnAfterChange()
    TMgStringField(FieldByName("DATA_CLIENTE")).OnAfterChange          = AddressOf DataCliente_OnAfterChange()
    TMgStringField(FieldByName("IPE_DT_DATAEXPEDICAO")).OnAfterChange  = AddressOf DataExpedicao_OnAfterChange()
    TMgStringField(FieldByName("IPE_RE_QTDECONVERTIDA")).OnAfterChange = AddressOf QtdeProgrmada_OnAfterChange()
    TMgStringField(FieldByName("PED_BO_PARCIAL")).OnAfterChange        = AddressOf PedidoParcial_OnAfterChange()

    '//Tv_Dados.DataController.DataModeController.GridMode = false
    Tv_Dados.DataController.CreateAllItems(True)

    '//MONTA AS COLUNAS CHECKBOX
    subDesabilitaEdicao(Sender, Tv_Dados)

    OnAfterScroll = AddressOf Cl_Dados_OnAfterScroll
    Cl_Dados_OnAfterScroll(sender)
    EnableControls
  End With
End Sub

Sub Cl_Lk_Clientes_OnAfterOpen(sender as TMgClientDataSet)
  With sender
    FieldByName("AGN_IN_CODIGO").DisplayLabel = "Código"
    FieldByName("AGN_ST_NOME").DisplayLabel   = "Cliente"
  End With
End Sub

Sub Cl_Lk_Grupos_OnAfterOpen(sender as TMgClientDataSet)
  Dim nIdx
  With sender
    For nIdx=0 to FieldCount - 1
      Fields[nIdx].Visible = false
    Next

    nIdx = 0
    FieldByName("GRU_IN_CODIGO").DisplayLabel = "Código"
    FieldByName("GRU_IN_CODIGO").Visible      = True
    FieldByName("GRU_IN_CODIGO").Index        = nIdx
    nIdx = nIdx + 1
    FieldByName("GRU_ST_NOME").DisplayLabel   = "Nome"
    FieldByName("GRU_ST_NOME").Visible        = True
    FieldByName("GRU_ST_NOME").Index          = nIdx
  End With
End Sub

'//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 3 - Fim
Sub cCl_GrupoCliente_OnAfterOpen(Sender as TMgClientDataSet)
  Dim i As Integer
  Dim auxIndex As Integer

  With Sender
    For i = 0 To Fields.Count - 1
      Fields[i].Visible = False
    Next

    auxIndex = 0
    With FieldByName("FCC_IN_CODIGO")
      Visible      = True
      DisplayLabel = "Cód. Grupo Cliente"
      Index        = auxIndex
    End With

    auxIndex = auxIndex + 1
    With FieldByName("FCC_ST_ALTERNATIVO")
      Visible      = True
      DisplayLabel = "Cód. Alternativo"
      Index        = auxIndex
    End With

    auxIndex = auxIndex + 1
    With FieldByName("FCC_ST_DESCRICAO")
      Visible      = True
      DisplayLabel = "Grupo Cliente"
      Index        = auxIndex
    End With
  End With
End Sub
'//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 3 - Fim

Sub Cl_Lk_SubGrupos_OnAfterOpen(sender as TMgClientDataSet)
  Dim nIdx

  With sender
    For nIdx=0 to FieldCount - 1
      Fields[nIdx].Visible = false
    Next

    nIdx = 0
    FieldByName("GRU_IN_CODIGO").DisplayLabel = "Código"
    FieldByName("GRU_IN_CODIGO").Visible      = True
    FieldByName("GRU_IN_CODIGO").Index        = nIdx

    nIdx = nIdx + 1
    FieldByName("GRU_ST_NOME").DisplayLabel   = "Nome"
    FieldByName("GRU_ST_NOME").Visible        = True
    FieldByName("GRU_ST_NOME").Index          = nIdx
  End With
End Sub

Sub Cl_Lk_Itens_OnAfterOpen(sender as TMgClientDataSet)
  Dim nIdx

  With sender
    For nIdx=0 to FieldCount - 1
      Fields[nIdx].Visible = false
    Next

    nIdx = 0
    FieldByName("PRO_ST_ALTERNATIVO").DisplayLabel = "Cód. Alternativo"
    FieldByName("PRO_ST_ALTERNATIVO").Visible      = true
    FieldByName("PRO_ST_ALTERNATIVO").Index        = nIdx

    nIdx = nIdx + 1
    FieldByName("PRO_ST_DESCRICAO").DisplayLabel = "Descrição"
    FieldByName("PRO_ST_DESCRICAO").Visible      = true
    FieldByName("PRO_ST_DESCRICAO").Index        = nIdx

    nIdx = nIdx + 1
    FieldByName("PRO_IN_CODIGO").DisplayLabel = "Código"
    FieldByName("PRO_IN_CODIGO").Visible      = true
    FieldByName("PRO_IN_CODIGO").Index        = nIdx

  End With
End Sub

Sub Cl_Lk_SubGrupos_OnBeforeOpen(sender as TMgClientDataSet)
    With sender
       if FormAtivo.Gb_Grupos.Checked then
          ParamByName("pGRUPO_INICIAL").Value  = FormAtivo.Ed_GruposInicial.Text
          ParamByName("pGRUPO_FINAL").Value    = FormAtivo.Ed_GruposFinal.Text
       else
          ParamByName("pGRUPO_INICIAL").Value  = null
          ParamByName("pGRUPO_FINAL").Value    = null
       end if
    End With
End Sub

Sub Cl_Lk_Itens_OnBeforeOpen(sender as TMgClientDataSet)
    With sender
       if FormAtivo.Gb_SubGrupos.Checked then
          ParamByName("pSUBGRUPO_INICIAL").Value  = FormAtivo.Ed_SubGruposInicial.Text
          ParamByName("pSUBGRUPO_FINAL").Value    = FormAtivo.Ed_SubGruposFinal.Text
       else
          ParamByName("pSUBGRUPO_INICIAL").Value  = null
          ParamByName("pSUBGRUPO_FINAL").Value    = null
       end if
    End With
End Sub

'// Alterar aqui Herbert - Data horizonte
Sub Bt_GerarOE_OnBeforeClick()

  Dim vGerencia    = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S"), _
      vRedistribui = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S"), _
      vVisualiza   = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_VISUALIZA").Value   = "S")

  vCl_DadosExecutaScroll = false
  vCl_OrdemExecutaScroll = false
  If (vGerencia or vRedistribui)then
    if (Messagedlg("Confirma a Geração da Ordem de Expedição?", 3, 3, 0) = MrYes) Then
      With FormAtivo
        Cl_SaldoDisponivelItem.Close
        Cl_SaldoDisponivelItem.Open
        If Cl_SaldoDisponivelItem.RecordCount > 0 then
          IF Cl_SaldoDisponivelItem.FieldByName("DISPONIVEL").Value <= 0  then
            vCl_DadosExecutaScroll = true
            vCl_OrdemExecutaScroll = true
            MessageDlg("Saldo indisponível para geração de OE, pedido não aceita parcial!", mtError, mbOk, 0)
            Exit
          End if
        End If

        '// Logica Data horizonte - Herbert
        /*
        cCL_DataHorizonte.Close
        cCL_DataHorizonte.Open

        If (  not(cCL_DataHorizonte.FieldByName("DATA_HORIZONTE").IsNull) and  _
                ( StrToDate(Cl_Dados.FieldByName("IPE_DT_DATAENTREGA").AsString) > _
                  StrToDate(cCL_DataHorizonte.FieldByName("DATA_HORIZONTE").AsString)  )) Then
         vCl_DadosExecutaScroll = true
           vCl_OrdemExecutaScroll = true
          MgMessageDlg("Pedido Fora da Data Horizonte: " + cCL_DataHorizonte.FieldByName("DATA_HORIZONTE").AsString, mtError, mbOk, 0)
          Exit
        End If
        */

        vCl_DadosExecutaScroll = false
        vCl_OrdemExecutaScroll = false
        GeraOE(Cl_Dados,"N",0)

        With Cl_OrdemExpedicao
          Close
          Open
        End With

        With Cl_Dados
          Close
          Open
        End With

      End With
      MessageDlg("Operação Concluída!", mtInformation, mbOk, 0)
    Else
      vCl_DadosExecutaScroll = true
      vCl_OrdemExecutaScroll = true
    End if
  Else
    vCl_DadosExecutaScroll = true
    vCl_OrdemExecutaScroll = true
    Cl_Dados_OnAfterScroll(FormAtivo.Cl_Dados)
    Cl_OrdemExpedicao_OnAfterScroll(Cl_OrdemExpedicao)
    RaiseException("Usuário sem permissão para este tipo de operação!")
  End if
  vCl_DadosExecutaScroll = true
  Cl_Dados_OnAfterScroll(FormAtivo.Cl_Dados)
  Cl_OrdemExpedicao_OnAfterScroll(Cl_OrdemExpedicao)
End Sub

Sub Bt_ExcluirOE_OnBeforeClick()
  Dim vSEQ_IN_CODIGO_RET, vEXP_IN_SEQUENCIA_RET, vEXP_IN_CODIGO_RET
  Dim pReservaAutomatica = "N"
  if (Messagedlg("Confirma a Exclusão da Ordem de Expedição?", 3, 3, 0) = MrYes) Then
    vCl_DadosExecutaScroll = false
    With Cl_FS_APT_APONTAORDEM
      Close
      Open
      If RecordCount > 0 then
        vCl_DadosExecutaScroll = true
        pReservaAutomatica = "L"
        RaiseException("Não é possível excluir a OE, pois existem lotes apontados pela sala de pano. Entre em contato com a Expedição!")
      End If
    End With

    With FormAtivo
        With Cl_IntegraOe
          ParamByName("pORG_TAB_IN_CODIGO").Value    = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
          ParamByName("pORG_PAD_IN_CODIGO").Value    = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
          ParamByName("pORG_IN_CODIGO").Value        = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
          ParamByName("pORG_TAU_ST_CODIGO").Value    = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
          ParamByName("pFIL_IN_CODIGO").Value        = FormAtivo.Cl_Dados.FieldByName("FIL_IN_CODIGO").Value
          ParamByName("pSER_ST_CODIGO").Value        = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
          ParamByName("pPED_IN_CODIGO").Value        = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
          ParamByName("pITP_IN_SEQUENCIA").Value     = FormAtivo.Cl_Dados.FieldByName("ITP_IN_SEQUENCIA").Value
          ParamByName("pTRA_IN_CODIGO").Value        = FormAtivo.Cl_Dados.FieldByName("TRA_IN_CODIGO").Value
          ParamByName("pIPE_IN_SEQUENCIA").Value     = FormAtivo.Cl_Dados.FieldByName("IPE_IN_SEQUENCIA").Value
          ParamByName("pIPE_RE_QUANTIDADE").Value    = Cl_OrdemExpedicao.FieldByName("EXP_RE_QTDEFATURAR").Value
          ParamByName("pEXP_DT_EMISSAO").Value       = Cl_OrdemExpedicao.FieldByName("EXP_DT_EMISSAO").Value
          ParamByName("pEXP_IN_CODIGO").Value        = Cl_OrdemExpedicao.FieldByName("EXP_IN_CODIGO").Value
          ParamByName("pReservaAutomatica").Value    = pReservaAutomatica
          ParamByName("pOPERACAO").Value             = "D"
          ParamByName("pUSU_IN_CODIGO").Value        = Dmmega.Usuario
          ParamByName("pSEQ_IN_CODIGO_RET").Value    = vSEQ_IN_CODIGO_RET
          ParamByName("pEXP_IN_SEQUENCIA_RET").Value = vEXP_IN_SEQUENCIA_RET
          ParamByName("pEXP_IN_CODIGO_RET").Value    = vEXP_IN_CODIGO_RET
          ExecSQL
        End With

        if Cl_FS_APT_APONTAORDEM.RecordCount > 0 then
          With Cl_Update_Cl_FS_APT_APONTAORDEM
            ParamByName("pORG_TAB_IN_CODIGO").Value  = Cl_OrdemExpedicao.FieldByName("ORG_TAB_IN_CODIGO").Value
            ParamByName("pORG_PAD_IN_CODIGO").Value  = Cl_OrdemExpedicao.FieldByName("ORG_PAD_IN_CODIGO").Value
            ParamByName("pORG_IN_CODIGO").Value      = Cl_OrdemExpedicao.FieldByName("ORG_IN_CODIGO").Value
            ParamByName("pORG_TAU_ST_CODIGO").Value  = Cl_OrdemExpedicao.FieldByName("ORG_TAU_ST_CODIGO").Value
            ParamByName("pSEQ_TAB_IN_CODIGO").Value  = Cl_OrdemExpedicao.FieldByName("SEQ_TAB_IN_CODIGO").Value
            ParamByName("pSEQ_IN_CODIGO").Value      = Cl_OrdemExpedicao.FieldByName("SEQ_IN_CODIGO").Value
            ParamByName("pEXP_IN_SEQUENCIA").Value   = Cl_OrdemExpedicao.FieldByName("EXP_IN_SEQUENCIA").Value
            ParamByName("pOE_CH_TIPOEXCLUSAO").Value = "E"
            ExecSQL
          End With
        end if

        With Cl_OrdemExpedicao
          vCl_OrdemExecutaScroll = false
          Close
          Open
          vCl_OrdemExecutaScroll = true
        End With

        With Cl_Dados
          Close
          Open
        End With

        MessageDlg("Operação Concluída!", mtInformation, mbOk, 0)
    End With
  End If
  vCl_DadosExecutaScroll = true
  Cl_Dados_OnAfterScroll(FormAtivo.Cl_Dados)
  Cl_OrdemExpedicao_OnAfterScroll(Cl_OrdemExpedicao)
End Sub

'// Aqui2
Sub Cl_Dados_OnBeforeOpen(sender as TMgClientDataSet)
  Dim pTodos
  With sender
    DisableControls
      SQL.Clear

      Sql.Add(" select T.*,")
      Sql.Add("         /* Tag_usuario " + vTag_User +"*/")
      Sql.Add("        'N' CONFIRMAR,")
      Sql.Add("        (T.IPE_RE_QTDECONVERTIDA - T.GER_RE_QUANTIDADE) IPE_RE_SALDO,")
      Sql.Add("        ((T.IPE_RE_QTDECONVERTIDA - T.GER_RE_QUANTIDADE) *")
      Sql.Add("        ITP_RE_VALORUNITARIOCONV) IPE_RE_SALDOMERCADORIA,")
      Sql.Add("        (T.GER_RE_QUANTIDADE - T.IPE_RE_QTDEFATURADA) IPE_RE_QTDERESFAT,")

      Sql.Add("(T.ITP_RE_VALORUNITARIOCONV * ")
      Sql.Add("(T.GER_RE_QUANTIDADE - T.IPE_RE_QTDEFATURADA)) VALOR_RESERVADO_A_FATURAR,")   '// Matheus H. - Inclusão coluna em grid principal. | 22/04/2026

      Sql.Add("        NVL(CUS_PCK_DADOSESTITEM.F_SALDO_GERAL_OE(T.ORG_IN_CODIGO,")
      Sql.Add("                                                  T.FIL_IN_CODIGO,")
      Sql.Add("                                                  T.PRO_PAD_IN_CODIGO,")
      Sql.Add("                                                  T.PRO_IN_CODIGO),")
      Sql.Add("            0) SALDO_ALM_DISP")
      Sql.Add("   from (select DADOS.ORG_TAB_IN_CODIGO,")
      Sql.Add("                 DADOS.ORG_PAD_IN_CODIGO,")
      Sql.Add("                 DADOS.ORG_IN_CODIGO,")
      Sql.Add("                 DADOS.ORG_TAU_ST_CODIGO,")
      Sql.Add("                 DADOS.SER_ST_CODIGO,")
      Sql.Add("                 DADOS.PED_IN_CODIGO,")
      Sql.Add("                 DADOS.FIL_IN_CODIGO,")
      Sql.Add("                 DADOS.TPD_IN_CODIGO,")
      Sql.Add("                 DADOS.TPD_ST_DESCRICAO,")
      Sql.Add("                 DADOS.PED_CH_STATUS,")
      Sql.Add("                 DADOS.PED_DT_EMISSAO,")
      Sql.Add("                 DADOS.CLI_TAB_IN_CODIGO,")
      Sql.Add("                 DADOS.CLI_PAD_IN_CODIGO,")
      Sql.Add("                 DADOS.CLI_IN_CODIGO,")
      Sql.Add("                 DADOS.CLI_TAU_ST_CODIGO,")
      Sql.Add("                 DADOS.CLI_ST_NOME,")
      Sql.Add("                 DADOS.UF_ST_SIGLA,")
      Sql.Add("                 DADOS.MUN_IN_CODIGO,")
      Sql.Add("                 DADOS.MUN_ST_NOME,")
      Sql.Add("                 DADOS.COND_ST_CODIGO,")
      Sql.Add("                 DADOS.COND_ST_NOME,")
      Sql.Add("                 DADOS.TRA_IN_CODIGO,")
      Sql.Add("                 DADOS.TRA_ST_NOME,")
      Sql.Add("                 DADOS.PRO_TAB_IN_CODIGO,")
      Sql.Add("                 DADOS.PRO_PAD_IN_CODIGO,")
      Sql.Add("                 DADOS.PRO_IN_CODIGO,")
      Sql.Add("                 DADOS.GRU_TAB_IN_CODIGO,")
      Sql.Add("                 DADOS.GRU_PAD_IN_CODIGO,")
      Sql.Add("                 DADOS.GRU_IDE_ST_CODIGO,")
      Sql.Add("                 DADOS.GRU_IN_CODIGO,")
      Sql.Add("                 DADOS.SUB_GRUPO,")
      Sql.Add("                 DADOS.PRO_ST_ALTERNATIVO,")
      Sql.Add("                 DADOS.PRO_ST_DESCRICAO,")
      Sql.Add("                 DADOS.UNI_ST_ORIGINAL UNI_ST_UNIDADE,")

      Sql.Add("                 FS_FNC_CONVERTE_M2_PC(DADOS.PRO_TAB_IN_CODIGO,")
      Sql.Add("                                       DADOS.PRO_PAD_IN_CODIGO,")
      Sql.Add("                                       DADOS.PRO_IN_CODIGO,")
      Sql.Add("                                       DADOS.UNI_ST_ORIGINAL,")
      Sql.Add("                                       DADOS.UNI_ST_UNIDADE,")
      Sql.Add("                                       DADOS.ITP_RE_QUANTIDADE) ITP_RE_QUANTIDADE,")


      Sql.Add("                 DADOS.ITP_IN_SEQUENCIA,")
      Sql.Add("                 DADOS.IPE_IN_SEQUENCIA,")
      Sql.Add("                 DADOS.IPE_RE_QUANTIDADE,")
      Sql.Add("                 DADOS.IPE_DT_DATAENTREGA,")
      Sql.Add("                 ")
      Sql.Add("                 FS_FNC_CONVERTE_M2_PC(DADOS.PRO_TAB_IN_CODIGO,")
      Sql.Add("                                       DADOS.PRO_PAD_IN_CODIGO,")
      Sql.Add("                                       DADOS.PRO_IN_CODIGO,")
      Sql.Add("                                       DADOS.UNI_ST_ORIGINAL,")
      Sql.Add("                                       DADOS.UNI_ST_UNIDADE,")
      Sql.Add("                                       DADOS.GER_RE_QUANTIDADE) GER_RE_QUANTIDADE,")
      Sql.Add("                 ")
      Sql.Add("                 FS_FNC_CONVERTE_M2_PC(DADOS.PRO_TAB_IN_CODIGO,")
      Sql.Add("                                       DADOS.PRO_PAD_IN_CODIGO,")
      Sql.Add("                                       DADOS.PRO_IN_CODIGO,")
      Sql.Add("                                       DADOS.UNI_ST_ORIGINAL,")
      Sql.Add("                                       DADOS.UNI_ST_UNIDADE,")
      Sql.Add("                                       DADOS.GER_RE_QTDEDISPONIVEL) GER_RE_QTDEDISPONIVEL,")
      Sql.Add("                 ")
      Sql.Add("                 -- DADOS.GER_RE_QUANTIDADE,                      ")
      Sql.Add("                 --  DADOS.GER_RE_QTDEDISPONIVEL,")
      Sql.Add("                 DADOS.PED_IN_FRETEPCONTA,")
      Sql.Add("                 DADOS.VEN_AGN_ST_NOME,")
      Sql.Add("                 DADOS.VEN_AGN_IN_CODIGO,")
      Sql.Add("                 DADOS.USU_IN_CODIGO,")
      Sql.Add("                 DADOS.IPE_CH_STATUS,")
      Sql.Add("                 DADOS.PED_BO_PARCIAL,")
      Sql.Add("                 DADOS.PED_IN_PRIORIDADE,")
      Sql.Add("                 DADOS.GRUPO,")
      Sql.Add("                 DADOS.B2B,")
      Sql.Add("                 DADOS.B2C,")
      Sql.Add("                 DADOS.EXPORTACAO,")
      Sql.Add("                 DADOS.OUTROS,")
      Sql.Add("                 DADOS.HIBRIDO,")
      Sql.Add("                 DADOS.INDEFINIDO,")
      Sql.Add("                 DADOS.PED_CH_SITUACAO,")
      Sql.Add("                 DADOS.PED_ST_SITUACAO,")
      Sql.Add("                 DADOS.PRIORIDADE,")
      Sql.Add("                 DADOS.IPE_ST_STATUS,")
      Sql.Add("                 DADOS.PED_ST_TIPOFRETE,")
      Sql.Add("                 DADOS.B2B_IN_NIVEL,")
      Sql.Add("                 DADOS.B2C_IN_NIVEL,")
      Sql.Add("                 DADOS.EXP_IN_NIVEL,")
      Sql.Add("                 DADOS.OUT_IN_NIVEL,")
      Sql.Add("                 DADOS.EMB_TAB_IN_CODIGO,")
      Sql.Add("                 DADOS.EMB_PAD_IN_CODIGO,")
      Sql.Add("                 DADOS.EMB_IN_CODIGO,")
      Sql.Add("                 DADOS.EMB_UNI_TAB_IN_CODIGO,")
      Sql.Add("                 DADOS.EMB_UNI_PAD_IN_CODIGO,")
      Sql.Add("                 DADOS.EMB_UNI_ST_UNIDADE,")
      Sql.Add("                 DADOS.EMB_ST_DESCRICAO,")
      Sql.Add("                 DADOS.NCM_ST_EXTENSO,")
      Sql.Add("                 DADOS.DATA_CLIENTE,")
      Sql.Add("                 DADOS.PEDIDO_INDISPONIVEL,")
      Sql.Add("                 DADOS.IPE_CH_SITUACAO,")
      Sql.Add("                 DADOS.MINIMO_3PC,")
      Sql.Add("                 DADOS.IPE_ST_TIPOENTREGA,")
      Sql.Add("                 DADOS.ITP_RE_VALORUNITARIO,")
      Sql.Add("                 DADOS.IPE_RE_QTDECONVERTIDA,")
      Sql.Add("                 DADOS.IPE_RE_QTDEFATURADA,")
      Sql.Add("                 DADOS.ITP_RE_VALORUNITARIOCONV,")
      Sql.Add("                 --  DADOS.IPE_RE_QTDESALDO,")
      Sql.Add("                 ")
      Sql.Add("                 FS_FNC_CONVERTE_M2_PC(DADOS.PRO_TAB_IN_CODIGO,")
      Sql.Add("                                       DADOS.PRO_PAD_IN_CODIGO,")
      Sql.Add("                                       DADOS.PRO_IN_CODIGO,")
      Sql.Add("                                       DADOS.UNI_ST_ORIGINAL,")
      Sql.Add("                                       DADOS.UNI_ST_UNIDADE,")
      Sql.Add("                                       DADOS.IPE_RE_QTDESALDO) IPE_RE_QTDESALDO,")
      Sql.Add("                 ")
      Sql.Add("                 DADOS.IPE_DT_DATAEXPEDICAO,")
      Sql.Add("                 DECODE(DADOS.B2B,")
      Sql.Add("                        'S',")
      Sql.Add("                        'B2B',")
      Sql.Add("                        DECODE(DADOS.B2C,")
      Sql.Add("                               'S',")
      Sql.Add("                               'B2C',")
      Sql.Add("                               DECODE(DADOS.EXPORTACAO,")
      Sql.Add("                                      'S',")
      Sql.Add("                                      'EXPORTACAO',")
      Sql.Add("                                      DECODE(DADOS.OUTROS,")
      Sql.Add("                                             'S',")
      Sql.Add("                                             'OUTROS',")
      Sql.Add("                                             DECODE(DADOS.HIBRIDO,")
      Sql.Add("                                                    'S',")
      Sql.Add("                                                    'HIBRIDO',")
      Sql.Add("                                                    DECODE(DADOS.INDEFINIDO,")
      Sql.Add("                                                           'S',")
      Sql.Add("                                                           'INDEFINIDO')))))) MERCADO,")
      Sql.Add("                 ")
      Sql.Add("                 case")
      Sql.Add("                   when ((DADOS.PED_BO_PARCIAL in ('N') or")
      Sql.Add("                        DADOS.EXPORTACAO = 'S') and")
      Sql.Add("                        (IPE_RE_QUANTIDADE <> ITP_RE_QUANTIDADE)) then")
      Sql.Add("                    'S'")
      Sql.Add("                   when DADOS.PED_CH_STATUS not in ('A', 'P', 'B') then")
      Sql.Add("                    'S'")
      Sql.Add("                   when DADOS.IPE_CH_STATUS in ('B') then")
      Sql.Add("                    'S'")
      Sql.Add("                   else")
      Sql.Add("                    'N'")
      Sql.Add("                 end BLO_CH_GEROE,")
      Sql.Add("                 case")
      Sql.Add("                   when DADOS.IPE_CH_SITUACAO = 'B' then")
      Sql.Add("                    'S'")
      Sql.Add("                   else")
      Sql.Add("                    'N'")
      Sql.Add("                 end BLO_CH_EDICAO,")
      Sql.Add("                 ")
      Sql.Add("                 case")
      Sql.Add("                   when DADOS.B2B = 'S' then")
      Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 2, 'S', 'N')")
      Sql.Add("                   when DADOS.B2C = 'S' then")
      Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 2, 'S', 'N')")
      Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
      Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 2, 'S', 'N')")
      Sql.Add("                   when DADOS.OUTROS = 'S' then")
      Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 2, 'S', 'N')")
      Sql.Add("                   else")
      Sql.Add("                    'N'")
      Sql.Add("                 end NIV_CH_GERENCIA,")
      Sql.Add("                 ")
      Sql.Add("                 case")
      Sql.Add("                   when DADOS.B2B = 'S' then")
      Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 3, 'S', 'N')")
      Sql.Add("                   when DADOS.B2C = 'S' then")
      Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 3, 'S', 'N')")
      Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
      Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 3, 'S', 'N')")
      Sql.Add("                   when DADOS.OUTROS = 'S' then")
      Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 3, 'S', 'N')")
      Sql.Add("                   else")
      Sql.Add("                    'N'")
      Sql.Add("                 end NIV_CH_REDISTRIBUI,")
      Sql.Add("                 ")
      Sql.Add("                 case")
      Sql.Add("                   when DADOS.B2B = 'S' then")
      Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 1, 'S', 'N')")
      Sql.Add("                   when DADOS.B2C = 'S' then")
      Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 1, 'S', 'N')")
      Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
      Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 1, 'S', 'N')")
      Sql.Add("                   when DADOS.OUTROS = 'S' then")
      Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 1, 'S', 'N')")
      Sql.Add("                   else")
      Sql.Add("                    'N'")
      Sql.Add("                 end NIV_CH_VISUALIZA,")
      Sql.Add("                 ")
      Sql.Add("                 case")
      Sql.Add("                   when DADOS.B2B = 'S' then")
      Sql.Add("                    DECODE(DADOS.B2B_IN_NIVEL, 0, 'S', 'N')")
      Sql.Add("                   when DADOS.B2C = 'S' then")
      Sql.Add("                    DECODE(DADOS.B2C_IN_NIVEL, 0, 'S', 'N')")
      Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
      Sql.Add("                    DECODE(DADOS.EXP_IN_NIVEL, 0, 'S', 'N')")
      Sql.Add("                   when DADOS.OUTROS = 'S' then")
      Sql.Add("                    DECODE(DADOS.OUT_IN_NIVEL, 0, 'S', 'N')")
      Sql.Add("                   else")
      Sql.Add("                    'N'")
      Sql.Add("                 end NIV_CH_NENHUM,")
      Sql.Add("                 case")
      Sql.Add("                   when (select count(B.EXP_IN_CODIGO) EXP_IN_CODIGO")
      Sql.Add("                           from VEN_PEDIDOVENDA A")
      Sql.Add("                           join VEN_EXPEDICAO B")
      Sql.Add("                             on B.ORG_TAB_IN_CODIGO = A.ORG_TAB_IN_CODIGO")
      Sql.Add("                            and B.ORG_PAD_IN_CODIGO = A.ORG_PAD_IN_CODIGO")
      Sql.Add("                            and B.ORG_IN_CODIGO = A.ORG_IN_CODIGO")
      Sql.Add("                            and B.ORG_TAU_ST_CODIGO = A.ORG_TAU_ST_CODIGO")
      Sql.Add("                            and B.SER_ST_CODIGO = A.SER_ST_CODIGO")
      Sql.Add("                            and B.PED_IN_CODIGO = A.PED_IN_CODIGO")
      Sql.Add("                          where A.ORG_TAB_IN_CODIGO = DADOS.ORG_TAB_IN_CODIGO")
      Sql.Add("                            and A.ORG_PAD_IN_CODIGO = DADOS.ORG_PAD_IN_CODIGO")
      Sql.Add("                            and A.ORG_IN_CODIGO = DADOS.ORG_IN_CODIGO")
      Sql.Add("                            and A.ORG_TAU_ST_CODIGO = DADOS.ORG_TAU_ST_CODIGO")
      Sql.Add("                            and A.SER_ST_CODIGO = DADOS.SER_ST_CODIGO")
      Sql.Add("                            and A.PED_IN_CODIGO = DADOS.PED_IN_CODIGO) > 0 then")
      Sql.Add("                    'S'")
      Sql.Add("                   when DADOS.EXPORTACAO = 'S' then")
      Sql.Add("                    'S'")
      Sql.Add("                   when DADOS.PED_CH_STATUS not in ('A', 'P', 'B') then")
      Sql.Add("                    'S'")
      Sql.Add("                   else")
      Sql.Add("                    'N'")
      Sql.Add("                 end BLO_CH_PARCIAL,")
      Sql.Add("                 DADOS.ITP_ST_PEDIDOCLIENTE,")
      Sql.Add("                 case")
      Sql.Add("                   when ((DADOS.PED_BO_PARCIAL in ('N') or")
      Sql.Add("                        DADOS.EXPORTACAO = 'S') and")
      Sql.Add("                        (IPE_RE_QUANTIDADE <> ITP_RE_QUANTIDADE)) then")
      Sql.Add("                    'S'")
      Sql.Add("                   when DADOS.PED_CH_STATUS not in ('A', 'P', 'B') then")
      Sql.Add("                    'S'")
      Sql.Add("                   else")
      Sql.Add("                    'N'")
      Sql.Add("                 end BLO_CH_STATUSOE,")
      Sql.Add("                 CASE")
      Sql.Add("                   WHEN DADOS.GER_RE_QUANTIDADE > 0 AND (DADOS.IPE_RE_QTDECONVERTIDA - DADOS.GER_RE_QUANTIDADE) > 0 THEN")
      Sql.Add("                     0")
      Sql.Add("                   ELSE")
      Sql.Add("                     1")
      Sql.Add("                 END ORDEM_OE_INICIADA,")
      Sql.Add("                 DADOS.CTD_CH_DATA_HORIZONTE,")
      Sql.Add("                 CASE")
      Sql.Add("                   WHEN DADOS.CTD_CH_DATA_HORIZONTE = 'S' THEN")
      Sql.Add("                     TRUNC(sysdate +")
      Sql.Add("                           FS_PCK_APT_NEW.FNC_OBTEM_DIAS_HORIZONTE(PCK_MEGA.ACHAPADRAODATABELA(FIL       => DADOS.FIL_IN_CODIGO,")
      Sql.Add("                                                                                               TAB       => 100,")
      Sql.Add("                                                                                               DATAATUAL => sysdate),")
      Sql.Add("                                                                                               DADOS.PRO_IN_CODIGO))")
      Sql.Add("                   ELSE")
      Sql.Add("                     NULL")
      Sql.Add("                 END DATA_HORIZONTE")
      Sql.Add("         ")
      Sql.Add("           from (select PED.ORG_TAB_IN_CODIGO ORG_TAB_IN_CODIGO,")
      Sql.Add("                         PED.ORG_PAD_IN_CODIGO ORG_PAD_IN_CODIGO,")
      Sql.Add("                         PED.ORG_IN_CODIGO ORG_IN_CODIGO,")
      Sql.Add("                         PED.ORG_TAU_ST_CODIGO ORG_TAU_ST_CODIGO,")
      Sql.Add("                         PED.SER_ST_CODIGO SER_ST_CODIGO,")
      Sql.Add("                         PED.PED_IN_CODIGO PED_IN_CODIGO,")
      Sql.Add("                         PED.FIL_IN_CODIGO FIL_IN_CODIGO,")
      Sql.Add("                         TPD.TPD_IN_CODIGO TPD_IN_CODIGO,")
      Sql.Add("                         TPD.TPD_ST_DESCRICAO TPD_ST_DESCRICAO,")
      Sql.Add("                         ITE.ITP_ST_SITUACAO PED_CH_STATUS,")
      Sql.Add("                         PED.PED_DT_EMISSAO PED_DT_EMISSAO,")
      Sql.Add("                         PED.CLI_TAB_IN_CODIGO CLI_TAB_IN_CODIGO,")
      Sql.Add("                         PED.CLI_PAD_IN_CODIGO CLI_PAD_IN_CODIGO,")
      Sql.Add("                         PED.CLI_IN_CODIGO CLI_IN_CODIGO,")
      Sql.Add("                         PED.CLI_TAU_ST_CODIGO CLI_TAU_ST_CODIGO,")
      Sql.Add("                         CLI.AGN_ST_NOME CLI_ST_NOME,")
      Sql.Add("                         MUN.UF_ST_SIGLA UF_ST_SIGLA,")
      Sql.Add("                         MUN.MUN_IN_CODIGO MUN_IN_CODIGO,")
      Sql.Add("                         MUN.MUN_ST_NOME MUN_ST_NOME,")
      Sql.Add("                         PED.COND_ST_CODIGO COND_ST_CODIGO,")
      Sql.Add("                         CON.COND_ST_NOME COND_ST_NOME,")
      Sql.Add("                         TRA.AGN_IN_CODIGO TRA_IN_CODIGO,")
      Sql.Add("                         TRA.AGN_ST_NOME TRA_ST_NOME,")
      Sql.Add("                         PRO.PRO_TAB_IN_CODIGO PRO_TAB_IN_CODIGO,")
      Sql.Add("                         PRO.PRO_PAD_IN_CODIGO PRO_PAD_IN_CODIGO,")
      Sql.Add("                         PRO.PRO_IN_CODIGO PRO_IN_CODIGO,")
      Sql.Add("                         PRO.GRU_TAB_IN_CODIGO GRU_TAB_IN_CODIGO,")
      Sql.Add("                         PRO.GRU_PAD_IN_CODIGO GRU_PAD_IN_CODIGO,")
      Sql.Add("                         PRO.GRU_IDE_ST_CODIGO GRU_IDE_ST_CODIGO,")
      Sql.Add("                         PRO.GRU_IN_CODIGO GRU_IN_CODIGO,")
      Sql.Add("                         PRO.GRU_IN_CODIGO SUB_GRUPO,")
      Sql.Add("                         PRO.PRO_ST_ALTERNATIVO PRO_ST_ALTERNATIVO,")
      Sql.Add("                         PRO.PRO_ST_DESCRICAO PRO_ST_DESCRICAO,")
      Sql.Add("                         ITE.UNI_ST_UNIDADE UNI_ST_UNIDADE,")
      Sql.Add("                         ITE.ITP_RE_QUANTIDADE ITP_RE_QUANTIDADE,")
      Sql.Add("                         ITE.ITP_IN_SEQUENCIA ITP_IN_SEQUENCIA,")
      Sql.Add("                         ITE.ITP_ST_PEDIDOCLIENTE,")
      Sql.Add("                         PRG.IPE_IN_SEQUENCIA IPE_IN_SEQUENCIA,")
      Sql.Add("                         PRG.IPE_RE_QUANTIDADE IPE_RE_QUANTIDADE,")
      Sql.Add("                         PRG.IPE_DT_DATAENTREGA IPE_DT_DATAENTREGA,")
      Sql.Add("                         PRG.IPE_DT_DATAEXPEDICAO IPE_DT_DATAEXPEDICAO,")
      Sql.Add("                         NVL((select sum(NVL(EXP.EXP_RE_QTDEFATURAR, 0))")
      Sql.Add("                               from VEN_EXPEDICAO EXP")
      Sql.Add("                              where EXP.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
      Sql.Add("                                and EXP.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
      Sql.Add("                                and EXP.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
      Sql.Add("                                and EXP.ORG_TAU_ST_CODIGO = PED.ORG_TAU_ST_CODIGO")
      Sql.Add("                                and EXP.SER_ST_CODIGO = PED.SER_ST_CODIGO")
      Sql.Add("                                and EXP.PED_IN_CODIGO = PED.PED_IN_CODIGO")
      Sql.Add("                                and EXP.ITP_IN_SEQUENCIA = ITE.ITP_IN_SEQUENCIA")
      Sql.Add("                                and EXP.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA),")
      Sql.Add("                             0) GER_RE_QUANTIDADE,")
      Sql.Add("                         NVL((select sum(NVL(EXP1.EXP_RE_QTDEFATURAR, 0))")
      Sql.Add("                               from VEN_EXPEDICAO EXP1")
      Sql.Add("                               left join FS_ROMANEIO_OE_ITENS RIT")
      Sql.Add("                                 on RIT.ORG_TAB_IN_CODIGO = EXP1.ORG_TAB_IN_CODIGO")
      Sql.Add("                                and RIT.ORG_PAD_IN_CODIGO = EXP1.ORG_PAD_IN_CODIGO")
      Sql.Add("                                and RIT.ORG_IN_CODIGO = EXP1.ORG_IN_CODIGO")
      Sql.Add("                                and RIT.ORG_TAU_ST_CODIGO = EXP1.ORG_TAU_ST_CODIGO")
      Sql.Add("                                and RIT.SEQ_TAB_IN_CODIGO = EXP1.SEQ_TAB_IN_CODIGO")
      Sql.Add("                                and RIT.SEQ_IN_CODIGO = EXP1.SEQ_IN_CODIGO")
      Sql.Add("                                and RIT.EXP_IN_SEQUENCIA = EXP1.EXP_IN_SEQUENCIA")
      Sql.Add("                               left join FS_ROMANEIO_OE ROE")
      Sql.Add("                                 on ROE.COL_IN_ID = RIT.COL_IN_ID")
      Sql.Add("                              where EXP1.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
      Sql.Add("                                and EXP1.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
      Sql.Add("                                and EXP1.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
      Sql.Add("                                and EXP1.ORG_TAU_ST_CODIGO = PED.ORG_TAU_ST_CODIGO")
      Sql.Add("                                and EXP1.SER_ST_CODIGO = PED.SER_ST_CODIGO")
      Sql.Add("                                and EXP1.PED_IN_CODIGO = PED.PED_IN_CODIGO")
      Sql.Add("                                and EXP1.ITP_IN_SEQUENCIA = ITE.ITP_IN_SEQUENCIA")
      Sql.Add("                                and EXP1.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
      Sql.Add("                                and EXP1.EXP_CH_STATUS = 'N'")
      Sql.Add("                                and NVL(ROE.COL_CH_STATUS, 'N') = 'N'),")
      Sql.Add("                             0) GER_RE_QTDEDISPONIVEL,")
      Sql.Add("                         PED.PED_IN_FRETEPCONTA PED_IN_FRETEPCONTA,")
      Sql.Add("                         AGN.AGN_ST_NOME VEN_AGN_ST_NOME,")
      Sql.Add("                         AGN.AGN_IN_CODIGO VEN_AGN_IN_CODIGO,")
      Sql.Add("                         GRU.GRU_IN_CODIGO USU_IN_CODIGO,")
      Sql.Add("                         NVL(FPRG.IPE_CH_STATUS, 'L') IPE_CH_STATUS,")
      Sql.Add("                         NVL(FPE.PED_BO_PARCIAL, 'N') PED_BO_PARCIAL,")
      Sql.Add("                         NVL(GER.PED_IN_PRIORIDADE, 0) PED_IN_PRIORIDADE,")
      Sql.Add("                         (select J.GRU_IN_CODIGO")
      Sql.Add("                            from EST_PRODUTOS      F,")
      Sql.Add("                                 GLO_IDENTIFICADOR G,")
      Sql.Add("                                 EST_GRUPOS        H,")
      Sql.Add("                                 EST_GRUPOS        I,")
      Sql.Add("                                 EST_GRUPOS        J")
      Sql.Add("                           where F.GRU_TAB_IN_CODIGO = G.TAB_IN_CODIGO")
      Sql.Add("                             and F.GRU_PAD_IN_CODIGO = G.PAD_IN_CODIGO")
      Sql.Add("                             and F.GRU_IDE_ST_CODIGO = G.IDE_ST_CODIGO")
      Sql.Add("                             and F.GRU_TAB_IN_CODIGO = H.GRU_TAB_IN_CODIGO")
      Sql.Add("                             and F.GRU_PAD_IN_CODIGO = H.GRU_PAD_IN_CODIGO")
      Sql.Add("                             and F.GRU_IDE_ST_CODIGO = H.GRU_IDE_ST_CODIGO")
      Sql.Add("                             and F.GRU_IN_CODIGO = H.GRU_IN_CODIGO")
      Sql.Add("                             and H.PAI_GRU_TAB_IN_CODIGO = I.GRU_TAB_IN_CODIGO")
      Sql.Add("                             and H.PAI_GRU_PAD_IN_CODIGO = I.GRU_PAD_IN_CODIGO")
      Sql.Add("                             and H.PAI_GRU_IDE_ST_CODIGO = I.GRU_IDE_ST_CODIGO")
      Sql.Add("                             and H.PAI_GRU_IN_CODIGO = I.GRU_IN_CODIGO")
      Sql.Add("                             and I.PAI_GRU_TAB_IN_CODIGO = J.GRU_TAB_IN_CODIGO")
      Sql.Add("                             and I.PAI_GRU_PAD_IN_CODIGO = J.GRU_PAD_IN_CODIGO")
      Sql.Add("                             and I.PAI_GRU_IDE_ST_CODIGO = J.GRU_IDE_ST_CODIGO")
      Sql.Add("                             and I.PAI_GRU_IN_CODIGO = J.GRU_IN_CODIGO")
      Sql.Add("                             and F.PRO_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
      Sql.Add("                             and F.PRO_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
      Sql.Add("                             and F.PRO_IN_CODIGO = PRO.PRO_IN_CODIGO")
      Sql.Add("                           group by J.GRU_IN_CODIGO) GRUPO,")
      Sql.Add("                         ")
      Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
      Sql.Add("                           when 'B2B' then")
      Sql.Add("                            'S'")
      Sql.Add("                           else")
      Sql.Add("                            'N'")
      Sql.Add("                         end B2B,")
      Sql.Add("                         ")
      Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
      Sql.Add("                           when 'B2C' then")
      Sql.Add("                            'S'")
      Sql.Add("                           else")
      Sql.Add("                            'N'")
      Sql.Add("                         end B2C,")
      Sql.Add("                         ")
      Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
      Sql.Add("                           when 'EXPORTAÇÃO' then")
      Sql.Add("                            'S'")
      Sql.Add("                           else")
      Sql.Add("                            'N'")
      Sql.Add("                         end EXPORTACAO,")
      Sql.Add("                         ")
      Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
      Sql.Add("                           when 'OUTROS' then")
      Sql.Add("                            'S'")
      Sql.Add("                           else")
      Sql.Add("                            'N'")
      Sql.Add("                         end OUTROS,")
      Sql.Add("                         ")
      Sql.Add("                         case UPPER(trim(MER.FCC_ST_DESCRICAO))")
      Sql.Add("                           when 'HIBRIDO' then")
      Sql.Add("                            'S'")
      Sql.Add("                           else")
      Sql.Add("                            'N'")
      Sql.Add("                         end HIBRIDO,")
      Sql.Add("                         ")
      Sql.Add("                         case")
      Sql.Add("                           when UPPER(trim(MER.FCC_ST_DESCRICAO)) not in")
      Sql.Add("                                ('HIBRIDO', 'OUTROS', 'EXPORTAÇÃO', 'B2C', 'B2B') then")
      Sql.Add("                            'S'")
      Sql.Add("                           else")
      Sql.Add("                            'N'")
      Sql.Add("                         end INDEFINIDO,")
      Sql.Add("                         case ITE.ITP_ST_SITUACAO")
      Sql.Add("                           when 'P' then")
      Sql.Add("                            'Pedido em Aberto'")
      Sql.Add("                           when 'B' then")
      Sql.Add("                            'Pedido Bloqueado'")
      Sql.Add("                           when 'A' then")
      Sql.Add("                            'Pedido Aprovado'")
      Sql.Add("                           when 'F' then")
      Sql.Add("                            'Pedido Faturado Totalmente'")
      Sql.Add("                           when 'R' then")
      Sql.Add("                            'Pedido Faturado Parcialmente'")
      Sql.Add("                           when 'C' then")
      Sql.Add("                            'Pedido Cancelado'")
      Sql.Add("                           when 'V' then")
      Sql.Add("                            'Documento Vencido'")
      Sql.Add("                           when 'E' then")
      Sql.Add("                            'Documento Encerrado'")
      Sql.Add("                         end PED_CH_SITUACAO,")
      Sql.Add("                         ")
      Sql.Add("                         case ITE.ITP_ST_SITUACAO")
      Sql.Add("                           when 'P' then")
      Sql.Add("                            'Pedido em Aberto'")
      Sql.Add("                           when 'B' then")
      Sql.Add("                            'Pedido Bloqueado'")
      Sql.Add("                           when 'A' then")
      Sql.Add("                            'Pedido em Aberto'")
      Sql.Add("                           when 'F' then")
      Sql.Add("                            'Pedido Faturado Totalmente'")
      Sql.Add("                           when 'R' then")
      Sql.Add("                            'Pedido Faturado Parcialmente'")
      Sql.Add("                           when 'C' then")
      Sql.Add("                            'Pedido Cancelado'")
      Sql.Add("                           when 'V' then")
      Sql.Add("                            'Documento Vencido'")
      Sql.Add("                           when 'E' then")
      Sql.Add("                            'Documento Encerrado'")
      Sql.Add("                         end PED_ST_SITUACAO,")
      Sql.Add("                         ")
      Sql.Add("                         cast(case NVL(GER.PED_IN_PRIORIDADE, 0)")
      Sql.Add("                                when 9 then")
      Sql.Add("                                 '9-Exportação'")
      Sql.Add("                                when 3 then")
      Sql.Add("                                 '3-Prioridade Alta'")
      Sql.Add("                                when 2 then")
      Sql.Add("                                 '2-Prioridade Média'")
      Sql.Add("                                when 1 then")
      Sql.Add("                                 '1-Prioridade Baixa'")
      Sql.Add("                                when 0 then")
      Sql.Add("                                 '0-Prioridade Não definida'")
      Sql.Add("                              end as varchar2(30)) PRIORIDADE,")
      Sql.Add("                         ")
      Sql.Add("                         case NVL(FPRG.IPE_CH_STATUS, 'L')")
      Sql.Add("                           when 'L' then")
      Sql.Add("                            'Liberado'")
      Sql.Add("                           when 'B' then")
      Sql.Add("                            'Bloqueado'")
      Sql.Add("                         end IPE_ST_STATUS,")
      Sql.Add("                         ")
      Sql.Add("                         case PED.PED_IN_FRETEPCONTA")
      Sql.Add("                           when 1 then")
      Sql.Add("                            'CIF'")
      Sql.Add("                           when 2 then")
      Sql.Add("                            'FOB'")
      Sql.Add("                           when 3 then")
      Sql.Add("                            'Terceiros'")
      Sql.Add("                           when 4 then")
      Sql.Add("                            'Sem Frete'")
      Sql.Add("                           when 5 then")
      Sql.Add("                            'Remetente Próprio'")
      Sql.Add("                           when 6 then")
      Sql.Add("                            'Destinatário Próprio'")
      Sql.Add("                         end PED_ST_TIPOFRETE,")
      Sql.Add("                         ")
      Sql.Add("                         NIV.B2B_IN_NIVEL,")
      Sql.Add("                         NIV.B2C_IN_NIVEL,")
      Sql.Add("                         NIV.EXP_IN_NIVEL,")
      Sql.Add("                         NIV.OUT_IN_NIVEL,")
      Sql.Add("                         ITE.EMB_TAB_IN_CODIGO,")
      Sql.Add("                         ITE.EMB_PAD_IN_CODIGO,")
      Sql.Add("                         ITE.EMB_IN_CODIGO,")
      Sql.Add("                         ITE.EMB_UNI_TAB_IN_CODIGO,")
      Sql.Add("                         ITE.EMB_UNI_PAD_IN_CODIGO,")
      Sql.Add("                         ITE.EMB_UNI_ST_UNIDADE,")
      Sql.Add("                         EMB.PRO_ST_DESCRICAOPDV EMB_ST_DESCRICAO,")
      Sql.Add("                         NCM.NCM_ST_EXTENSO,")
      Sql.Add("                         PRDT.IPE_DT_DATAENTREGA DATA_CLIENTE,")
      Sql.Add("                         DECODE(PVI.PED_IN_CODIGO, null, '', 'SIM') PEDIDO_INDISPONIVEL,")
      Sql.Add("                         PRG.IPE_CH_SITUACAO,")
      Sql.Add("                         NVL(FPE.PED_BO_MIN3PC, 'N') MINIMO_3PC,")
      Sql.Add("                         ITE.ITP_RE_VALORUNITARIOCONV,")
      Sql.Add("                         /*")
      Sql.Add("                         NVL((select 'S' MINIMO_3PC")
      Sql.Add("                               from FS_TB_CLASSIFICADORES_CLIENTE CLIC")
      Sql.Add("                              where CLIC.FTT_IN_CODIGO = 2")
      Sql.Add("                                and CLIC.FTC_IN_CODIGO = 13")
      Sql.Add("                                and CLIC.AGN_TAB_IN_CODIGO = PED.CLI_TAB_IN_CODIGO")
      Sql.Add("                                and CLIC.AGN_PAD_IN_CODIGO = PED.CLI_PAD_IN_CODIGO")
      Sql.Add("                                and CLIC.AGN_IN_CODIGO = PED.CLI_IN_CODIGO")
      Sql.Add("                                and CLIC.AGN_TAU_ST_CODIGO = PED.CLI_TAU_ST_CODIGO),")
      Sql.Add("                             '') MINIMO_3PC,")
      Sql.Add("                         */")
      Sql.Add("                         case PRG.IPE_CH_TIPOENTREGA")
      Sql.Add("                           when 'A' then")
      Sql.Add("                            'Até a Data'")
      Sql.Add("                           when 'S' then")
      Sql.Add("                            'Somente na Data'")
      Sql.Add("                           when 'P' then")
      Sql.Add("                            'Após a Data'")
      Sql.Add("                         end IPE_ST_TIPOENTREGA,")
      Sql.Add("                         ")
      Sql.Add("                         (ITE.ITP_RE_VALORUNITARIO -")
      Sql.Add("                         (ITE.ITP_RE_VALORDESCRATEIO / ITE.ITP_RE_QUANTIDADE)) ITP_RE_VALORUNITARIO,")
      Sql.Add("                         PRG.IPE_RE_QTDECONVERTIDA,")
      Sql.Add("                         PRO.UNI_ST_UNIDADE UNI_ST_ORIGINAL,")
      Sql.Add("                         PRG.IPE_RE_QTDEFATURADA,")
      Sql.Add("                         PRG.IPE_RE_QUANTIDADE - PRG.IPE_RE_QTDEFATURADA IPE_RE_QTDESALDO,")
      Sql.Add("                         NVL(CPT.CTD_CH_DATA_HORIZONTE, 'N') CTD_CH_DATA_HORIZONTE")
      Sql.Add("                  ")
      Sql.Add("                    from VEN_PEDIDOVENDA PED")
      Sql.Add("                    left join FS_VEN_TIPODOCUMENTO_CLASSIFICADOR CLA")
      Sql.Add("                      on CLA.TPD_TAB_IN_CODIGO = PED.TPD_TAB_IN_CODIGO")
      Sql.Add("                     and CLA.TPD_PAD_IN_CODIGO = PED.TPD_PAD_IN_CODIGO")
      Sql.Add("                     and CLA.TPD_IN_CODIGO = PED.TPD_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join FS_TB_CLASSIFICADORES MER")
      Sql.Add("                      on MER.FTT_IN_CODIGO = CLA.FTT_IN_CODIGO")
      Sql.Add("                     and MER.FTC_IN_CODIGO = CLA.FTC_IN_CODIGO")
      Sql.Add("                     and MER.FCC_IN_CODIGO = CLA.FCC_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join FS_PEDIDOVENDA FPE")
      Sql.Add("                      on FPE.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
      Sql.Add("                     and FPE.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
      Sql.Add("                     and FPE.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
      Sql.Add("                     and FPE.ORG_TAU_ST_CODIGO = PED.ORG_TAU_ST_CODIGO")
      Sql.Add("                     and FPE.SER_ST_CODIGO = PED.SER_ST_CODIGO")
      Sql.Add("                     and FPE.PED_IN_CODIGO = PED.PED_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join FS_ROMANEIO_PEDVEN_INCOMPLETOS PVI")
      Sql.Add("                      on PED.ORG_TAB_IN_CODIGO = PVI.ORG_TAB_IN_CODIGO")
      Sql.Add("                     and PED.ORG_PAD_IN_CODIGO = PVI.ORG_PAD_IN_CODIGO")
      Sql.Add("                     and PED.ORG_IN_CODIGO = PVI.ORG_IN_CODIGO")
      Sql.Add("                     and PED.ORG_TAU_ST_CODIGO = PVI.ORG_TAU_ST_CODIGO")
      Sql.Add("                     and PED.SER_ST_CODIGO = PVI.SER_ST_CODIGO")
      Sql.Add("                     and PED.PED_IN_CODIGO = PVI.PED_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join GLO_AGENTES AGN")
      Sql.Add("                      on PED.REP_TAB_IN_CODIGO = AGN.AGN_TAB_IN_CODIGO")
      Sql.Add("                     and PED.REP_PAD_IN_CODIGO = AGN.AGN_PAD_IN_CODIGO")
      Sql.Add("                     and PED.REP_IN_CODIGO = AGN.AGN_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join GLO_GRUPO_USUARIO GRU")
      Sql.Add("                      on GRU.GRU_IN_CODIGO = :PUSU_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join GLO_GRUPO_USUARIOCMPESP NIV")
      Sql.Add("                      on NIV.GRU_IN_CODIGO = GRU.GRU_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    join GLO_CONDPAGTO CON")
      Sql.Add("                      on CON.COND_TAB_IN_CODIGO = PED.COND_TAB_IN_CODIGO")
      Sql.Add("                     and CON.COND_PAD_IN_CODIGO = PED.COND_PAD_IN_CODIGO")
      Sql.Add("                     and CON.COND_ST_CODIGO = PED.COND_ST_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    join VEN_TIPODOCUMENTO TPD")
      Sql.Add("                      on TPD.TPD_TAB_IN_CODIGO = PED.TPD_TAB_IN_CODIGO")
      Sql.Add("                     and TPD.TPD_PAD_IN_CODIGO = PED.TPD_PAD_IN_CODIGO")
      Sql.Add("                     and TPD.TPD_IN_CODIGO = PED.TPD_IN_CODIGO")
      Sql.Add("                     and TPD.TPD_CH_TIPODOCUMENTO = 'P'")
      Sql.Add("                  ")
      Sql.Add("                    left join FS_VEN_TIPODOCUMENTO CPT")
      Sql.Add("                      on CPT.TPD_TAB_IN_CODIGO = TPD.TPD_TAB_IN_CODIGO")
      Sql.Add("                     and CPT.TPD_PAD_IN_CODIGO = TPD.TPD_PAD_IN_CODIGO")
      Sql.Add("                     and CPT.TPD_IN_CODIGO = TPD.TPD_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                  --- CLIENTE DO PEDIDO")
      Sql.Add("                    join GLO_AGENTES_ID CLD")
      Sql.Add("                      on CLD.AGN_TAB_IN_CODIGO = PED.CLI_TAB_IN_CODIGO")
      Sql.Add("                     and CLD.AGN_PAD_IN_CODIGO = PED.CLI_PAD_IN_CODIGO")
      Sql.Add("                     and CLD.AGN_IN_CODIGO = PED.CLI_IN_CODIGO")
      Sql.Add("                     and CLD.AGN_TAU_ST_CODIGO = PED.CLI_TAU_ST_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    join GLO_AGENTES CLI")
      Sql.Add("                      on CLI.AGN_TAB_IN_CODIGO = CLD.AGN_TAB_IN_CODIGO")
      Sql.Add("                     and CLI.AGN_PAD_IN_CODIGO = CLD.AGN_PAD_IN_CODIGO")
      Sql.Add("                     and CLI.AGN_IN_CODIGO = CLD.AGN_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join GLO_MUNICIPIO MUN")
      Sql.Add("                      on MUN.UF_ST_SIGLA = CLI.UF_ST_SIGLA")
      Sql.Add("                     and MUN.MUN_IN_CODIGO = CLI.MUN_IN_CODIGO")
      Sql.Add("                  --- ITENS DO PEDIDO")
      Sql.Add("                    join VEN_ITEMPEDIDOVENDA ITE")
      Sql.Add("                      on ITE.ORG_TAB_IN_CODIGO = PED.ORG_TAB_IN_CODIGO")
      Sql.Add("                     and ITE.ORG_PAD_IN_CODIGO = PED.ORG_PAD_IN_CODIGO")
      Sql.Add("                     and ITE.ORG_IN_CODIGO = PED.ORG_IN_CODIGO")
      Sql.Add("                     and ITE.PED_IN_CODIGO = PED.PED_IN_CODIGO")
      Sql.Add("                  --- EMBALAGEM DO PRODUTO")
      Sql.Add("                    left join EST_PRODUTOS EMB")
      Sql.Add("                      on EMB.PRO_TAB_IN_CODIGO = ITE.EMB_TAB_IN_CODIGO")
      Sql.Add("                     and EMB.PRO_PAD_IN_CODIGO = ITE.EMB_PAD_IN_CODIGO")
      Sql.Add("                     and EMB.PRO_IN_CODIGO = ITE.EMB_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join VEN_PEDPROGENTREGA PRG")
      Sql.Add("                      on PRG.ORG_TAB_IN_CODIGO = ITE.ORG_TAB_IN_CODIGO")
      Sql.Add("                     and PRG.ORG_PAD_IN_CODIGO = ITE.ORG_PAD_IN_CODIGO")
      Sql.Add("                     and PRG.ORG_IN_CODIGO = ITE.ORG_IN_CODIGO")
      Sql.Add("                     and PRG.ORG_TAU_ST_CODIGO = ITE.ORG_TAU_ST_CODIGO")
      Sql.Add("                     and PRG.SER_ST_CODIGO = ITE.SER_ST_CODIGO")
      Sql.Add("                     and PRG.PED_IN_CODIGO = ITE.PED_IN_CODIGO")
      Sql.Add("                     and PRG.ITP_IN_SEQUENCIA = ITE.ITP_IN_SEQUENCIA")
      Sql.Add("                  ")
      Sql.Add("                    left join FS_PEDPROGENTREGA FPRG")
      Sql.Add("                      on FPRG.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
      Sql.Add("                     and FPRG.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
      Sql.Add("                     and FPRG.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
      Sql.Add("                     and FPRG.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
      Sql.Add("                     and FPRG.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
      Sql.Add("                     and FPRG.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
      Sql.Add("                     and FPRG.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
      Sql.Add("                     and FPRG.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
      Sql.Add("                  ")
      Sql.Add("                    left join FS_PEDPROGENTREGA_DATACLI PRDT")
      Sql.Add("                      on PRDT.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
      Sql.Add("                     and PRDT.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
      Sql.Add("                     and PRDT.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
      Sql.Add("                     and PRDT.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
      Sql.Add("                     and PRDT.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
      Sql.Add("                     and PRDT.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
      Sql.Add("                     and PRDT.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
      Sql.Add("                     and PRDT.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
      Sql.Add("                  ")
      Sql.Add("                    join EST_PRODUTOS PRO")
      Sql.Add("                      on PRO.PRO_TAB_IN_CODIGO = ITE.PRO_TAB_IN_CODIGO")
      Sql.Add("                     and PRO.PRO_PAD_IN_CODIGO = ITE.PRO_PAD_IN_CODIGO")
      Sql.Add("                     and PRO.PRO_IN_CODIGO = ITE.PRO_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                  --- NCM")
      Sql.Add("                    left join TRF_NCM NCM")
      Sql.Add("                      on PRO.NCM_TAB_IN_CODIGO = NCM.NCM_TAB_IN_CODIGO")
      Sql.Add("                     and PRO.NCM_PAD_IN_CODIGO = NCM.NCM_PAD_IN_CODIGO")
      Sql.Add("                     and PRO.NCM_IN_CODIGO = NCM.NCM_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join VEN_ITEMPEDI_VEN_ITEMNOT NFI")
      Sql.Add("                      on NFI.PE_ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
      Sql.Add("                     and NFI.PE_ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
      Sql.Add("                     and NFI.PE_ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
      Sql.Add("                     and NFI.PE_ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
      Sql.Add("                     and NFI.PE_SER_ST_CODIGO = PRG.SER_ST_CODIGO")
      Sql.Add("                     and NFI.PE_PED_IN_CODIGO = PRG.PED_IN_CODIGO")
      Sql.Add("                     and NFI.PE_ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
      Sql.Add("                     and NFI.PE_IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
      Sql.Add("                  ")
      Sql.Add("                  --- TRANSPORTADOR")
      Sql.Add("                    left join GLO_AGENTES TRA")
      Sql.Add("                      on TRA.AGN_TAB_IN_CODIGO = PED.TRA_TAB_IN_CODIGO")
      Sql.Add("                     and TRA.AGN_PAD_IN_CODIGO = PED.TRA_PAD_IN_CODIGO")
      Sql.Add("                     and TRA.AGN_IN_CODIGO = PED.TRA_IN_CODIGO")
      Sql.Add("                  ")
      Sql.Add("                    left join FS_PEDIDOVENDAGER GER")
      Sql.Add("                      on GER.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
      Sql.Add("                     and GER.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
      Sql.Add("                     and GER.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
      Sql.Add("                     and GER.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
      Sql.Add("                     and GER.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
      Sql.Add("                     and GER.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
      Sql.Add("                     and GER.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
      Sql.Add("                     and GER.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
      Sql.Add("                   where PED.FIL_IN_CODIGO = :PFIL_IN_CODIGO")
      Sql.Add("                        ")

      If FormAtivo.Gb_ITP_ST_PEDIDOCLIENTE.Checked then
        Sql.Add("                     and ((:PITP_ST_PEDIDOCLIENTE is null and 1 = 1) or")
        Sql.Add("                         (:PITP_ST_PEDIDOCLIENTE is not null and")
        Sql.Add("                         ITE.ITP_ST_PEDIDOCLIENTE = :PITP_ST_PEDIDOCLIENTE))")
        Sql.Add("                        ")
      End If

      if FormAtivo.Gb_Representante.Checked then
        Sql.Add("                     and PED.REP_IN_CODIGO =")
        Sql.Add("                         NVL(:PREP_IN_CODIGO, PED.REP_IN_CODIGO)")
        Sql.Add("                        ")
      end if

      if FormAtivo.Gb_TipoDoc.Checked then
        Sql.Add("                     and PED.TPD_IN_CODIGO =")
        Sql.Add("                         NVL(:PTPD_IN_CODIGO, PED.TPD_IN_CODIGO)")
        Sql.Add("                        ")
      end if

      if FormAtivo.Gb_Entrega.Checked then
        Sql.Add("                     and PRG.IPE_DT_DATAENTREGA between")
        Sql.Add("                         TO_DATE(:PENTREGA_INICIAL, 'dd/mm/rrrr') and")
        Sql.Add("                         TO_DATE(:PENTREGA_FINAL, 'dd/mm/rrrr')")
      end if


      if FormAtivo.Gb_DataCliente.Checked then
        Sql.Add("                     and NVL(PRDT.IPE_DT_DATAENTREGA, TRUNC(sysdate)) between")
        Sql.Add("                         TO_DATE(:PDATA_CLIENTE_INICIAL, 'dd/mm/rrrr') and")
        Sql.Add("                         TO_DATE(:PDATA_CLIENTE_FINAL, 'dd/mm/rrrr')")
      end if

      if FormAtivo.Gb_Emissao.Checked then
        Sql.Add("                     and PED.PED_DT_EMISSAO between")
        Sql.Add("                         TO_DATE(:PEMISSAO_INICIAL, 'dd/mm/rrrr') and")
        Sql.Add("                         TO_DATE(:PEMISSAO_FINAL, 'dd/mm/rrrr')")
      end if


      if FormAtivo.Gb_Pedido.Checked then
        Sql.Add("                     and PED.PED_IN_CODIGO between NVL(:PPEDIDO_INICIAL, 0) and")
        Sql.Add("                         NVL(:PPEDIDO_FINAL, 99999999)")
      end if


      Sql.Add("                     and PRO.PRO_IN_CODIGO between NVL(:PITEM_INICIAL, 0) and")
      Sql.Add("                         NVL(:PITEM_FINAL, 99999999)")

      if FormAtivo.Gb_CodItem.Checked then
        Sql.Add("                     and PRO.PRO_IN_CODIGO between NVL(:PITEM_INICIAL, 0) and")
        Sql.Add("                         NVL(:PITEM_FINAL, 99999999)")
      end if

      if FormAtivo.Gb_Grupos.Checked then
        Sql.Add("                     and exists")
        Sql.Add("                   (select J.GRU_IN_CODIGO")
        Sql.Add("                            from EST_PRODUTOS      F,")
        Sql.Add("                                 GLO_IDENTIFICADOR G,")
        Sql.Add("                                 EST_GRUPOS        H,")
        Sql.Add("                                 EST_GRUPOS        I,")
        Sql.Add("                                 EST_GRUPOS        J")
        Sql.Add("                           where F.GRU_TAB_IN_CODIGO = G.TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = G.PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = G.IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_TAB_IN_CODIGO = H.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and F.GRU_PAD_IN_CODIGO = H.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and F.GRU_IDE_ST_CODIGO = H.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and F.GRU_IN_CODIGO = H.GRU_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_TAB_IN_CODIGO = I.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_PAD_IN_CODIGO = I.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IDE_ST_CODIGO = I.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and H.PAI_GRU_IN_CODIGO = I.GRU_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_TAB_IN_CODIGO = J.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_PAD_IN_CODIGO = J.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IDE_ST_CODIGO = J.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and I.PAI_GRU_IN_CODIGO = J.GRU_IN_CODIGO")
        Sql.Add("                             and F.PRO_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
        Sql.Add("                             and F.PRO_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
        Sql.Add("                             and F.PRO_IN_CODIGO = PRO.PRO_IN_CODIGO")
        Sql.Add("                             and J.GRU_IN_CODIGO between NVL(:PGRUPO_INICIAL, 0) and")
        Sql.Add("                                 NVL(:PGRUPO_FINAL, 999999)")
        Sql.Add("                           group by J.GRU_IN_CODIGO)")
        Sql.Add("                        ")
      end if

      '//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 4 - Início
      if FormAtivo.Gb_GrupoCliente.Checked then
        Sql.Add("                    and EXISTS (")
        Sql.Add("                         SELECT 1")
        Sql.Add("                         FROM MEGA.FS_TB_CLASSIFICADORES_CLIENTE CCL")
        Sql.Add("                         WHERE CCL.AGN_TAB_IN_CODIGO = PED.CLI_TAB_IN_CODIGO")
        Sql.Add("                           AND CCL.AGN_PAD_IN_CODIGO = PED.CLI_PAD_IN_CODIGO")
        Sql.Add("                           AND CCL.AGN_IN_CODIGO     = PED.CLI_IN_CODIGO")
        Sql.Add("                           AND CCL.FTT_IN_CODIGO     = 2")
        Sql.Add("                           AND CCL.FTC_IN_CODIGO     = 6")
        Sql.Add("                           AND CCL.FCC_IN_CODIGO BETWEEN :PGRUPOCLIENTE_INICIAL AND :PGRUPOCLIENTE_FINAL)")
      end if
      '//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 4 - Fim

      if FormAtivo.Gb_SubGrupos.Checked then
        Sql.Add("                     and exists")
        Sql.Add("                   (select D.GRU_IN_CODIGO")
        Sql.Add("                            from EST_PRODUTOS A")
        Sql.Add("                            join EST_GRUPOS B")
        Sql.Add("                              on B.GRU_TAB_IN_CODIGO = A.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and B.GRU_PAD_IN_CODIGO = A.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and B.GRU_IDE_ST_CODIGO = A.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and B.GRU_IN_CODIGO = A.GRU_IN_CODIGO")
        Sql.Add("                            join EST_GRUPOS C")
        Sql.Add("                              on C.GRU_TAB_IN_CODIGO = B.GRU_TAB_IN_CODIGO")
        Sql.Add("                             and C.GRU_PAD_IN_CODIGO = B.GRU_PAD_IN_CODIGO")
        Sql.Add("                             and C.GRU_IDE_ST_CODIGO = B.GRU_IDE_ST_CODIGO")
        Sql.Add("                             and C.GRU_IN_CODIGO = B.GRU_IN_CODIGO")
        Sql.Add("                            join EST_GRUPOS D")
        Sql.Add("                              on D.GRU_TAB_IN_CODIGO = C.PAI_GRU_TAB_IN_CODIGO")
        Sql.Add("                             and D.GRU_PAD_IN_CODIGO = C.PAI_GRU_PAD_IN_CODIGO")
        Sql.Add("                             and D.GRU_IDE_ST_CODIGO = C.PAI_GRU_IDE_ST_CODIGO")
        Sql.Add("                             and D.GRU_IN_CODIGO = C.PAI_GRU_IN_CODIGO")
        Sql.Add("                           where A.PRO_TAB_IN_CODIGO = PRO.PRO_TAB_IN_CODIGO")
        Sql.Add("                             and A.PRO_PAD_IN_CODIGO = PRO.PRO_PAD_IN_CODIGO")
        Sql.Add("                             and A.PRO_IN_CODIGO = PRO.PRO_IN_CODIGO")
        Sql.Add("                             and D.GRU_IN_CODIGO between")
        Sql.Add("                                 NVL(:PSUBGRUPO_INICIAL, 0) and")
        Sql.Add("                                 NVL(:PSUBGRUPO_FINAL, 999999)")
        Sql.Add("                           group by D.GRU_IN_CODIGO)")
        Sql.Add("                        ")
      end if

      if FormAtivo.Gb_Cliente.Checked then
        Sql.Add("                     and PED.CLI_IN_CODIGO between NVL(:PCLIENTE_INICIAL, 0) and")
        Sql.Add("                         NVL(:PCLIENTE_FINAL, 999999)")
        Sql.Add("                        ")
      end if

      if FormAtivo.Gb_NotaFiscal.Checked then
        Sql.Add("                     and ((:PNOTA_INICIAL is null and 1 = 1) or")
        Sql.Add("                         PED.PED_IN_CODIGO in")
        Sql.Add("                         (select IT.PE_PED_IN_CODIGO")
        Sql.Add("                             from VEN_NOTAFISCAL NF")
        Sql.Add("                             join VEN_ITEMPEDI_VEN_ITEMNOT IT")
        Sql.Add("                               on IT.NF_ORG_TAB_IN_CODIGO = NF.ORG_TAB_IN_CODIGO")
        Sql.Add("                              and IT.NF_ORG_PAD_IN_CODIGO = NF.ORG_PAD_IN_CODIGO")
        Sql.Add("                              and IT.NF_ORG_IN_CODIGO = NF.ORG_IN_CODIGO")
        Sql.Add("                              and IT.NF_ORG_TAU_ST_CODIGO = NF.ORG_TAU_ST_CODIGO")
        Sql.Add("                              and IT.NF_SEQ_TAB_IN_CODIGO = NF.SEQ_TAB_IN_CODIGO")
        Sql.Add("                              and IT.NF_SEQ_IN_CODIGO = NF.SEQ_IN_CODIGO")
        Sql.Add("                              and IT.NF_NOT_IN_CODIGO = NF.NOT_IN_CODIGO")
        Sql.Add("                            where NF.NOT_IN_NUMERO between :PNOTA_INICIAL and :PNOTA_FINAL")
        Sql.Add("                              and IT.PE_ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                              and IT.PE_ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                              and IT.PE_ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                              and IT.PE_ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                              and IT.PE_SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                              and IT.PE_PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                              and IT.PE_ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                              and IT.PE_IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                            group by IT.PE_PED_IN_CODIGO))")
        Sql.Add("                        ")
      end if




      if FormAtivo.Gb_Prioridade.Checked then
        Sql.Add("                     and NVL(GER.PED_IN_PRIORIDADE, 0) between")
        Sql.Add("                         NVL(:PPRIORIDADE, 0) and NVL(:PPRIORIDADE, 9)")
      End If


      Sql.Add("                        ")

      if FormAtivo.Gb_StatusEntrega.Checked then
        Sql.Add("                     and (case NVL(FPRG.IPE_CH_STATUS, 'L')")
        Sql.Add("                           when 'L' then")
        Sql.Add("                            'Liberado'")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            'Bloqueado'")
        Sql.Add("                         end = :PSTATUSENTREGA or")
        Sql.Add("                         NVL(:PSTATUSENTREGA, 'S') = 'S')")
        Sql.Add("                        ")
      end if

      If FormAtivo.Gb_Status.Checked then
        Sql.Add("                     and ((case ITE.ITP_ST_SITUACAO")
        Sql.Add("                           when 'P' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'B' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto Pedido Bloqueado',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'A' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'R' then")
        Sql.Add("                            DECODE(PRG.IPE_CH_SITUACAO,")
        Sql.Add("                                   'A',")
        Sql.Add("                                   'Pedido em Aberto Pedido Faturado Parcialmente',")
        Sql.Add("                                   'N')")
        Sql.Add("                           when 'F' then")
        Sql.Add("                            'Pedido Faturado Totalmente'")
        Sql.Add("                           when 'C' then")
        Sql.Add("                            'Pedido Cancelado'")
        Sql.Add("                           when 'V' then")
        Sql.Add("                            'Documento Vencido'")
        Sql.Add("                           when 'E' then")
        Sql.Add("                            'Documento Encerrado'")
        Sql.Add("                         end like '%' || :PSTATUS || '%') or")
        Sql.Add("                         NVL(:PSTATUS, 'S') = 'S')")
        Sql.Add("                        ")
      End If



      Sql.Add("                     and NVL(FPE.PED_BO_PARCIAL, 'N') =")
      Sql.Add("                         DECODE(NVL(:PPARCIAL, 'T'),")
      Sql.Add("                                'T',")
      Sql.Add("                                NVL(FPE.PED_BO_PARCIAL, 'N'),")
      Sql.Add("                                NVL(:PPARCIAL, 'T'))")
      Sql.Add("                        ")
      Sql.Add("                     and GRU.GRU_IN_CODIGO = :PUSU_IN_CODIGO")
      Sql.Add("                        ")
      Sql.Add("                     and ((:PIPE_IN_SEQUENCIA is null and 1 = 1) or")
      Sql.Add("                         (:PIPE_IN_SEQUENCIA is not null and")
      Sql.Add("                         PRG.IPE_IN_SEQUENCIA = :PIPE_IN_SEQUENCIA))")
      Sql.Add("                        ")

      if FormAtivo.Gb_StatusOE.Checked then
        Sql.Add("                     and ((:PSTATUSOE is null and 1 = 1) or")
        Sql.Add("                         (exists")
        Sql.Add("                          (select 1")
        Sql.Add("                              from VEN_EXPEDICAO EXP")
        Sql.Add("                             where EXP.ORG_TAB_IN_CODIGO = PRG.ORG_TAB_IN_CODIGO")
        Sql.Add("                               and EXP.ORG_PAD_IN_CODIGO = PRG.ORG_PAD_IN_CODIGO")
        Sql.Add("                               and EXP.ORG_IN_CODIGO = PRG.ORG_IN_CODIGO")
        Sql.Add("                               and EXP.ORG_TAU_ST_CODIGO = PRG.ORG_TAU_ST_CODIGO")
        Sql.Add("                               and EXP.SER_ST_CODIGO = PRG.SER_ST_CODIGO")
        Sql.Add("                               and EXP.PED_IN_CODIGO = PRG.PED_IN_CODIGO")
        Sql.Add("                               and EXP.ITP_IN_SEQUENCIA = PRG.ITP_IN_SEQUENCIA")
        Sql.Add("                               and EXP.IPE_IN_SEQUENCIA = PRG.IPE_IN_SEQUENCIA")
        Sql.Add("                               and case EXP.EXP_CH_STATUS")
        Sql.Add("                                     when 'N' then")
        Sql.Add("                                      'Aguardando Separação'")
        Sql.Add("                                     when 'B' then")
        Sql.Add("                                      'Bloqueado'")
        Sql.Add("                                     when 'L' then")
        Sql.Add("                                      'Liberadas para faturamento'")
        Sql.Add("                                     when 'F' then")
        Sql.Add("                                      'Faturado'")
        Sql.Add("                                     when 'C' then")
        Sql.Add("                                      'Cancelado'")
        Sql.Add("                                   end = :PSTATUSOE)))")
        Sql.Add("                  ")
      end if

      Sql.Add("                   group by PED.ORG_TAB_IN_CODIGO,")
      Sql.Add("                            PED.ORG_PAD_IN_CODIGO,")
      Sql.Add("                            PED.ORG_IN_CODIGO,")
      Sql.Add("                            PED.ORG_TAU_ST_CODIGO,")
      Sql.Add("                            PED.SER_ST_CODIGO,")
      Sql.Add("                            PED.PED_IN_CODIGO,")
      Sql.Add("                            PED.FIL_IN_CODIGO,")
      Sql.Add("                            TPD.TPD_IN_CODIGO,")
      Sql.Add("                            TPD.TPD_ST_DESCRICAO,")
      Sql.Add("                            PED.PED_DT_EMISSAO,")
      Sql.Add("                            PED.PED_DT_EMISSAO,")
      Sql.Add("                            PED.CLI_TAB_IN_CODIGO,")
      Sql.Add("                            PED.CLI_PAD_IN_CODIGO,")
      Sql.Add("                            PED.CLI_IN_CODIGO,")
      Sql.Add("                            PED.CLI_TAU_ST_CODIGO,")
      Sql.Add("                            CLI.AGN_ST_NOME,")
      Sql.Add("                            MUN.UF_ST_SIGLA,")
      Sql.Add("                            MUN.MUN_IN_CODIGO,")
      Sql.Add("                            MUN.MUN_ST_NOME,")
      Sql.Add("                            PED.COND_ST_CODIGO,")
      Sql.Add("                            CON.COND_ST_NOME,")
      Sql.Add("                            TRA.AGN_IN_CODIGO,")
      Sql.Add("                            TRA.AGN_ST_NOME,")
      Sql.Add("                            PRO.PRO_TAB_IN_CODIGO,")
      Sql.Add("                            PRO.PRO_PAD_IN_CODIGO,")
      Sql.Add("                            PRO.PRO_IN_CODIGO,")
      Sql.Add("                            PRO.GRU_TAB_IN_CODIGO,")
      Sql.Add("                            PRO.GRU_PAD_IN_CODIGO,")
      Sql.Add("                            PRO.GRU_IDE_ST_CODIGO,")
      Sql.Add("                            PRO.GRU_IN_CODIGO,")
      Sql.Add("                            PRO.PRO_ST_ALTERNATIVO,")
      Sql.Add("                            PRO.PRO_ST_DESCRICAO,")
      Sql.Add("                            ITE.UNI_ST_UNIDADE,")
      Sql.Add("                            ITE.ITP_RE_QUANTIDADE,")
      Sql.Add("                            ITE.ITP_IN_SEQUENCIA,")
      Sql.Add("                            ITE.ITP_ST_SITUACAO,")
      Sql.Add("                            ITE.ITP_RE_VALORUNITARIO,")
      Sql.Add("                            ITE.ITP_RE_VALORUNITARIOCONV,")
      Sql.Add("                            ITE.ITP_RE_VALORDESCRATEIO,")
      Sql.Add("                            PRG.IPE_IN_SEQUENCIA,")
      Sql.Add("                            PRG.IPE_RE_QUANTIDADE,")
      Sql.Add("                            PRG.IPE_DT_DATAENTREGA,")
      Sql.Add("                            PRG.IPE_RE_QTDECONVERTIDA,")
      Sql.Add("                            PRG.IPE_DT_DATAEXPEDICAO,")
      Sql.Add("                            AGN.AGN_ST_NOME,")
      Sql.Add("                            AGN.AGN_IN_CODIGO,")
      Sql.Add("                            GRU.GRU_IN_CODIGO,")
      Sql.Add("                            GRU.GRU_ST_NOME,")
      Sql.Add("                            PED.PED_CH_SITUACAO,")
      Sql.Add("                            GER.PED_IN_PRIORIDADE,")
      Sql.Add("                            GER.PED_IN_CODIGO,")
      Sql.Add("                            FPRG.IPE_CH_STATUS,")
      Sql.Add("                            FPE.PED_BO_PARCIAL,")
      Sql.Add("                            PED.PED_IN_FRETEPCONTA,")
      Sql.Add("                            MER.FCC_ST_DESCRICAO,")
      Sql.Add("                            NIV.B2B_IN_NIVEL,")
      Sql.Add("                            NIV.B2C_IN_NIVEL,")
      Sql.Add("                            NIV.EXP_IN_NIVEL,")
      Sql.Add("                            NIV.OUT_IN_NIVEL,")
      Sql.Add("                            ITE.EMB_TAB_IN_CODIGO,")
      Sql.Add("                            ITE.EMB_PAD_IN_CODIGO,")
      Sql.Add("                            ITE.EMB_IN_CODIGO,")
      Sql.Add("                            ITE.EMB_UNI_TAB_IN_CODIGO,")
      Sql.Add("                            ITE.EMB_UNI_PAD_IN_CODIGO,")
      Sql.Add("                            ITE.EMB_UNI_ST_UNIDADE,")
      Sql.Add("                            EMB.PRO_ST_DESCRICAOPDV,")
      Sql.Add("                            NCM.NCM_ST_EXTENSO,")
      Sql.Add("                            PRDT.IPE_DT_DATAENTREGA,")
      Sql.Add("                            DECODE(PVI.PED_IN_CODIGO, null, '', 'SIM'),")
      Sql.Add("                            PRG.IPE_CH_SITUACAO,")
      Sql.Add("                            FPE.PED_BO_MIN3PC,")
      Sql.Add("                            PRG.IPE_CH_TIPOENTREGA,")
      Sql.Add("                            ITE.ITP_RE_QTDECONVERTIDA,")
      Sql.Add("                            PRO.UNI_ST_UNIDADE,")
      Sql.Add("                            ITE.ITP_ST_PEDIDOCLIENTE,")
      Sql.Add("                            PRG.IPE_RE_QTDEFATURADA,")
      Sql.Add("                            CPT.CTD_CH_DATA_HORIZONTE) DADOS")
      Sql.Add("         ")


      If not (FormAtivo.Cl_Parametros.FieldByName("B2B").isnull and _
         FormAtivo.Cl_Parametros.FieldByName("B2C").isnull and _
         FormAtivo.Cl_Parametros.FieldByName("EXPORTACAO").isnull and _
         FormAtivo.Cl_Parametros.FieldByName("OUTROS").isnull and _
         FormAtivo.Cl_Parametros.FieldByName("HIBRIDO").isnull and _
         FormAtivo.Cl_Parametros.FieldByName("INDEFINIDO").isnull and _
         pTodos) Then

        Sql.Add("          where ((DADOS.B2B =")
        Sql.Add("                DECODE(:PB2B, 'N', DECODE(DADOS.B2B, 'N', 'S', 'N'), 'S') or")
        Sql.Add("                DADOS.B2C =")
        Sql.Add("                DECODE(:PB2C, 'N', DECODE(DADOS.B2C, 'N', 'S', 'N'), 'S') or")
        Sql.Add("                DADOS.EXPORTACAO =")
        Sql.Add("                DECODE(:PEXPORTACAO,")
        Sql.Add("                         'N',")
        Sql.Add("                         DECODE(DADOS.EXPORTACAO, 'N', 'S', 'N'),")
        Sql.Add("                         'S') or")
        Sql.Add("                DADOS.OUTROS = DECODE(:POUTROS,")
        Sql.Add("                                        'N',")
        Sql.Add("                                        DECODE(DADOS.OUTROS, 'N', 'S', 'N'),")
        Sql.Add("                                        'S') or")
        Sql.Add("                DADOS.HIBRIDO = DECODE(:PHIBRIDO,")
        Sql.Add("                                         'N',")
        Sql.Add("                                         DECODE(DADOS.HIBRIDO, 'N', 'S', 'N'),")
        Sql.Add("                                         'S') or")
        Sql.Add("                DADOS.INDEFINIDO =")
        Sql.Add("                DECODE(:PINDEFINIDO,")
        Sql.Add("                         'N',")
        Sql.Add("                         DECODE(DADOS.INDEFINIDO, 'N', 'S', 'N'),")
        Sql.Add("                         'S') or :PTODOS = 'S'))")
        Sql.Add("         ")

      End If

      Sql.Add("         ) T")
      Sql.Add("  where ((T.B2B = 'S' and T.B2B_IN_NIVEL >= 1) or")
      Sql.Add("        (T.B2C = 'S' and T.B2C_IN_NIVEL >= 1) or")
      Sql.Add("        (T.EXPORTACAO = 'S' and T.EXP_IN_NIVEL >= 1) or")
      Sql.Add("        (T.OUTROS = 'S' and T.OUT_IN_NIVEL >= 1))")


      Sql.Add("    and ((:PCARREGATELA = 'N' and 1 = 1) or (:PCARREGATELA = 'S' and 1 = 2))")

      Sql.Add("order by T.PED_IN_PRIORIDADE desc,")
      Sql.Add("         TO_NUMBER(TO_CHAR(T.IPE_DT_DATAEXPEDICAO, 'YYYYMMDD')),")
      Sql.Add("         T.PED_IN_CODIGO,")
      Sql.Add("         T.ORDEM_OE_INICIADA,")
      Sql.Add("         T.ITP_IN_SEQUENCIA,")
      Sql.Add("         T.IPE_IN_SEQUENCIA")
  End With

  With FormAtivo
    IF NOT Ck_B2B.Checked and NOT Ck_B2C.Checked AND NOT Ck_Exportacao.Checked AND NOT Ck_HIBRIDO.Checked AND NOT Ck_OUTROS.Checked AND NOT Ck_Indefinido.Checked then
      pTodos = "S"
    Else
      pTodos = "N"
    End If
  End With

  With sender
    Filtered = false
    ParamByName("pCarregaTela").Value = vAbreTela
    ParamByName("pORG_IN_CODIGO").Value = DMMega.Organizacao
    If FormAtivo.Op_Sim.Checked then
      ParamByName("pParcial").Value = "S"
    Else
      If FormAtivo.Op_Nao.Checked then
        ParamByName("pParcial").Value = "N"
      Else
        If FormAtivo.Op_Todos.Checked then
          ParamByName("pParcial").Value = "T"
        End If
      End if
    End If


    if FormAtivo.Gb_Prioridade.Checked then
      ParamByName("pPrioridade").Value = StrToInt(Mgleft(FormAtivo.Cb_Prioridade.Text,1))
    else
      ParamByName("pPrioridade").Value = Null
    End If

    if FormAtivo.Gb_StatusEntrega.Checked then
       ParamByName("pStatusEntrega").Value = FormAtivo.Cb_EntregaStatus.Text
    else
       ParamByName("pStatusEntrega").Value = Null
    end if

    '// --- filtro de representante
    if (FormAtivo.Gb_Representante.Checked and (FormAtivo.Ed_REP_IN_CODIGO.Text <> "")) then
      ParamByName("pREP_IN_CODIGO").Value = StrToInt(FormAtivo.Ed_REP_IN_CODIGO.Text)
    else
      ParamByName("pREP_IN_CODIGO").Value = Null
    end if

    '// --- filtro de Tipo Documento
    if (FormAtivo.Gb_TipoDoc.Checked and (FormAtivo.Ed_TipoDoc.Text <> "")) then
      ParamByName("pTPD_IN_CODIGO").Value = StrToInt(FormAtivo.Ed_TipoDoc.Text)
    else
      ParamByName("pTPD_IN_CODIGO").Value = Null
    end if

    if FormAtivo.Gb_Entrega.Checked then
       ParamByName("pENTREGA_INICIAL").Value = FormAtivo.Cl_Parametros.FieldByName("ENTREGA_INICIAL").Value
       ParamByName("pENTREGA_FINAL").Value   = FormAtivo.Cl_Parametros.FieldByName("ENTREGA_FINAL").Value
    else
       ParamByName("pENTREGA_INICIAL").Value = Null
       ParamByName("pENTREGA_FINAL").Value   = Null
    end if

    if FormAtivo.Gb_DataCliente.Checked then
       ParamByName("pDATA_CLIENTE_INICIAL").Value = FormAtivo.Cl_Parametros.FieldByName("DATA_CLIENTE_INICIAL").Value
       ParamByName("pDATA_CLIENTE_FINAL").Value   = FormAtivo.Cl_Parametros.FieldByName("DATA_CLIENTE_FINAL").Value
    else
       ParamByName("pDATA_CLIENTE_INICIAL").Value = Null
       ParamByName("pDATA_CLIENTE_FINAL").Value   = Null
    end if

    if FormAtivo.Gb_Emissao.Checked then
       ParamByName("pEMISSAO_INICIAL").Value = FormAtivo.Cl_Parametros.FieldByName("EMISSAO_INICIAL").Value
       ParamByName("pEMISSAO_FINAL").Value   = FormAtivo.Cl_Parametros.FieldByName("EMISSAO_FINAL").Value
    else
       ParamByName("pEMISSAO_INICIAL").Value = Null
       ParamByName("pEMISSAO_FINAL").Value   = Null
    end if

    if FormAtivo.Gb_Pedido.Checked then
       ParamByName("pPEDIDO_INICIAL").Value = FormAtivo.Cl_Parametros.FieldByName("PEDIDO_INICIAL").Value
       ParamByName("pPEDIDO_FINAL").Value   = FormAtivo.Cl_Parametros.FieldByName("PEDIDO_FINAL").Value
    else
       ParamByName("pPEDIDO_INICIAL").Value = Null
       ParamByName("pPEDIDO_FINAL").Value   = Null
    end if

    if FormAtivo.Gb_CodItem.Checked then
       ParamByName("pITEM_INICIAL").Value   = FormAtivo.Ed_CodItemInicial.Text
       ParamByName("pITEM_FINAL").Value     = FormAtivo.Ed_CodItemFinal.Text
    else
       ParamByName("pITEM_INICIAL").Value   = null
       ParamByName("pITEM_FINAL").Value     = null
    end if

    if FormAtivo.Gb_Grupos.Checked then
       ParamByName("pGRUPO_INICIAL").Value  = FormAtivo.Ed_GruposInicial.Text
       ParamByName("pGRUPO_FINAL").Value    = FormAtivo.Ed_GruposFinal.Text
    else
       ParamByName("pGRUPO_INICIAL").Value  = null
       ParamByName("pGRUPO_FINAL").Value    = null
    end if

    '//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 5 - Início
    if FormAtivo.Gb_GrupoCliente.Checked then
       ParamByName("PGRUPOCLIENTE_INICIAL").Value = FormAtivo.Ed_GrupoClienteInicial.Text
       ParamByName("PGRUPOCLIENTE_FINAL").Value   = FormAtivo.Ed_GrupoClienteFinal.Text
    else
       ParamByName("PGRUPOCLIENTE_INICIAL").Value = null
       ParamByName("PGRUPOCLIENTE_FINAL").Value   = null
    end if
    '//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 5 - Fim

    if FormAtivo.Gb_SubGrupos.Checked then
       ParamByName("pSUBGRUPO_INICIAL").Value  = FormAtivo.Ed_SubGruposInicial.Text
       ParamByName("pSUBGRUPO_FINAL").Value    = FormAtivo.Ed_SubGruposFinal.Text
    else
       ParamByName("pSUBGRUPO_INICIAL").Value  = null
       ParamByName("pSUBGRUPO_FINAL").Value    = null
    end if

   /* if FormAtivo.Gb_Cliente.Checked then
       ParamByName("pCLIENTE_INICIAL").Value  = FormAtivo.Ed_ClienteInicial.Text
       ParamByName("pCLIENTE_FINAL").Value    = FormAtivo.Ed_ClienteFinal.Text*/

   '//Gustavo 18/03/2026
    if FormAtivo.Gb_Cliente.Checked then
     dim x = FormAtivo.Ed_ClienteInicial.Text
     dim y = FormAtivo.Ed_ClienteFinal.Text

      Try
       ParamByName("pCLIENTE_INICIAL").Value  = IntToStr(x)
       ParamByName("pCLIENTE_FINAL").Value    = IntToStr(y)
       Catch
      End Try
    else
       ParamByName("pCLIENTE_INICIAL").Value  = Null
       ParamByName("pCLIENTE_FINAL").Value    = Null
    end if

    if FormAtivo.Gb_NotaFiscal.Checked then
       ParamByName("pNOTA_INICIAL").Value  = FormAtivo.Cl_Parametros.FieldByName("NOTA_INICIAL").Value
       ParamByName("pNOTA_FINAL").Value    = FormAtivo.Cl_Parametros.FieldByName("NOTA_FINAL").Value
    else
       ParamByName("pNOTA_INICIAL").Value  = Null
       ParamByName("pNOTA_FINAL").Value    = Null
    end if

    if FormAtivo.Gb_StatusOE.Checked then
       ParamByName("pStatusOE").Value  = FormAtivo.Cb_StatusOE.Text
    else
       ParamByName("pStatusOE").Value  = Null
    end if

    If FormAtivo.Gb_Status.Checked then
      ParamByName("pStatus").Value  = FormAtivo.Cb_StatusPedido.Text
    Else
      ParamByName("pStatus").Value  = Null
    End If

    IF FormAtivo.Gb_ITP_ST_PEDIDOCLIENTE.Checked then
      ParamByName("pITP_ST_PEDIDOCLIENTE").Value  = FormAtivo.Cl_Parametros.FieldByName("ITP_ST_PEDIDOCLIENTE").Value
    Else
      ParamByName("pITP_ST_PEDIDOCLIENTE").Value  = Null
    End If

    ParamByName("pB2B").Value          = FormAtivo.Cl_Parametros.FieldByName("B2B").Value
    ParamByName("pB2C").Value          = FormAtivo.Cl_Parametros.FieldByName("B2C").Value
    ParamByName("pEXPORTACAO").Value   = FormAtivo.Cl_Parametros.FieldByName("EXPORTACAO").Value
    ParamByName("pOUTROS").Value       = FormAtivo.Cl_Parametros.FieldByName("OUTROS").Value
    ParamByName("pHIBRIDO").Value      = FormAtivo.Cl_Parametros.FieldByName("HIBRIDO").Value
    ParamByName("pINDEFINIDO").Value   = FormAtivo.Cl_Parametros.FieldByName("INDEFINIDO").Value
    ParamByName("pTodos").Value        = pTodos

    ParamByName("pFIL_IN_CODIGO").Value = DMMega.Filial
    ParamByName("pUSU_IN_CODIGO").Value = DMMega.Usuario

    Sender.OnAfterScroll = nil

  End With

End Sub

Sub Cl_SaldoDisponivel_OnBeforeOpen(sender as TMgClientDataSet)
  With sender
    ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
    ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
    ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
    ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
    ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
    ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
  End With
End Sub

Sub Cl_SaldoDisponivelItem_OnBeforeOpen(sender as TMgClientDataSet)
  With sender
    ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
    ParamByName("pFIL_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("FIL_IN_CODIGO").Value
    ParamByName("pPRO_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("PRO_TAB_IN_CODIGO").Value
    ParamByName("pPRO_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("PRO_PAD_IN_CODIGO").Value
    ParamByName("pPRO_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PRO_IN_CODIGO").Value
  End With
End Sub

Sub Cl_NotaFiscal_OnBeforeOpen(sender as TmgClientDataSet)
  With sender
    ParamByName("pORG_TAB_IN_CODIGO").Value = Cl_OrdemExpedicao.FieldByName("ORG_TAB_IN_CODIGO").Value
    ParamByName("pORG_PAD_IN_CODIGO").Value = Cl_OrdemExpedicao.FieldByName("ORG_PAD_IN_CODIGO").Value
    ParamByName("pORG_IN_CODIGO").Value     = Cl_OrdemExpedicao.FieldByName("ORG_IN_CODIGO").Value
    ParamByName("pORG_TAU_ST_CODIGO").Value = Cl_OrdemExpedicao.FieldByName("ORG_TAU_ST_CODIGO").Value
    ParamByName("pSER_ST_CODIGO").Value     = Cl_OrdemExpedicao.FieldByName("SER_ST_CODIGO").Value
    ParamByName("pPED_IN_CODIGO").Value     = Cl_OrdemExpedicao.FieldByName("PED_IN_CODIGO").Value
    ParamByName("pITP_IN_SEQUENCIA").Value  = Cl_OrdemExpedicao.FieldByName("ITP_IN_SEQUENCIA").Value
    ParamByName("pIPE_IN_SEQUENCIA").Value  = Cl_OrdemExpedicao.FieldByName("IPE_IN_SEQUENCIA").Value
    ParamByName("pSEQ_TAB_IN_CODIGO").Value = Cl_OrdemExpedicao.FieldByName("SEQ_TAB_IN_CODIGO").Value
    ParamByName("pSEQ_IN_CODIGO").Value     = Cl_OrdemExpedicao.FieldByName("SEQ_IN_CODIGO").Value
    ParamByName("pEXP_IN_SEQUENCIA").Value  = Cl_OrdemExpedicao.FieldByName("EXP_IN_SEQUENCIA").Value
  End With
End Sub

Sub Bt_Filtrar_OnAfterClick()
  With FormAtivo

    vAbreTela = "N"

    vCl_DadosExecutaScroll = false
    vCl_OrdemExecutaScroll = false

    With Cl_Dados
      Close
      Open
    End With
    With PageControl1
      ActivePage = FormAtivo.Ts_Geral
    End With

    vCl_OrdemExecutaScroll = true
    vCl_DadosExecutaScroll = true
    Cl_Dados_OnAfterScroll(FormAtivo.Cl_Dados)
    Cl_OrdemExpedicao_OnAfterScroll(Cl_OrdemExpedicao)

  End With
End Sub

Sub Bt_ClassCliente_OnAfterClick()
    ExecutaForm("FORM_FS_CONSULTA_CLASS_CLIENTES").ShowModal
End Sub

Sub Bt_ClassItem_OnAfterClick()
    ExecutaForm("FORM_FS_CONSULTA_CLASS_ITEMS").ShowModal
End Sub

Sub Bt_ClassClientesItens_OnAfterClick()
    ExecutaForm("FORM_FS_CONSULTA_CLASS_CLI_ITENS").ShowModal
End Sub

Sub Bt_Saldos_OnAfterClick()
'//  if(DMMega.Usuario = 278) then
'//    ExecutaForm("FORM_FS_CONSULTA_SALDO_COELHO").ShowModal
'//  else
    ExecutaForm("FORM_FS_CONSULTA_SALDO").ShowModal
'//  end if
End Sub

Sub Bt_Historico_OnAfterClick()
    ExecutaForm("FORM_FS_PEDPROGENTREGA_HISTORICO").ShowModal
End Sub

Sub Bt_OcorrenciaFin_OnAfterClick()
    ExecutaForm("FORM_FS_OCORRENCIAS_FIN").ShowModal
End Sub

Sub cBt_HistAltProgEntrega_OnAfterClick()
    ExecutaForm("FORM_FS_ALT_PROG_ENTREGA").ShowModal
End Sub

  '// Matheus H. 09/04/2026 - Início
Sub cBt_LogLiberacao_OnAfterClick
  ExecutaForm("FORM_JSM_LOGLIBERACAOOE").ShowModal
End Sub
  '// Matheus H. 09/04/2026 - Início

  '// Matheus H. 09/04/2026 - Início
Sub cBt_LogLiberacaoPed_OnAfterClick
  ExecutaForm("FORM_JSM_LOGLIBERACAOPED").ShowModal
End Sub
 '// Matheus H. 09/04/2026 - Fim


Sub Bt_DistribuirReserva_OnAfterClick()
  vCl_DadosExecutaScroll = false
  vCl_OrdemExecutaScroll = false

  With Cl_FS_APT_APONTAORDEM
    Close
    Open
    If RecordCount > 0 then
      if (Messagedlg("Já existem lotes vinculados a esse Pedido e será necessário trocar as etiquetas. Confirma a operação?", 3, 3, 0) = MrNo) Then
        vCl_DadosExecutaScroll = true
        vCl_OrdemExecutaScroll = true
        RaiseException("Operação Cancelada pelo Usuário!")
      End If
    End If
  End With

  ExecutaForm("FORM_FS_DISTRIBUIR_RESERVA").ShowModal
  vCl_DadosExecutaScroll = true
  vCl_OrdemExecutaScroll = true
End Sub

Sub Bt_SaldosGrupo_OnAfterClick()
    ExecutaForm("FORM_FS_CONSULTA_SALDO_GRUPO").ShowModal
End Sub

Sub Bt_AlteraEmbalagem_OnBeforeClick()
  vCl_DadosExecutaScroll = false
  vCl_OrdemExecutaScroll = false
  ExecutaForm("FORM_FS_PEDIDOVENDA_EMBALAGEM").ShowModal
  vCl_DadosExecutaScroll = true
  vCl_OrdemExecutaScroll = true
End Sub

Sub Bt_LogCriacaoRomaneio_OnAfterClick
  ExecutaForm("FORM_FS_ORDEM_ROMANEIO_LOG_CRIACAO").ShowModal
End Sub

Sub ReservaAutomatica()
  Dim vRES_IN_SEQUENCIA

  if (Messagedlg("Confirma a Geração de Reserva Automática?", 3, 3, 0) = MrYes) Then
    vCl_DadosExecutaScroll = false
    vCl_OrdemExecutaScroll = false
    With FormAtivo
      With Cl_DadosResevaAutomatica
        Close
        Open
        If RecordCount <= 0 then
          MessageDlg("Nenhum pedido encontrado para reserva automática!", mtInformation, mbOk, 0)
        Else

          With Cl_FS_SEQ_RESERVAAUTO
            Close
            Open
            If RecordCount > 0 Then
              vRES_IN_SEQUENCIA = FieldByName("SEQUENCIA").Value
              Cl_FS_RESERVAAUTO.Insert
              With Cl_FS_RESERVAAUTO
                FieldByName("RES_IN_CODIGO").Value     = vRES_IN_SEQUENCIA
                FieldByName("RES_IN_USUARIO").Value    = Dmmega.Usuario
                FieldByName("RES_DT_INICIO").Value     = Now
                FieldByName("RES_ST_COMPUTADOR").Value = Dmmega.ComputerName
              End With
              Cl_FS_RESERVAAUTO.Post
              Dmmega.GravaRegistro([Cl_FS_RESERVAAUTO])
            Else
              MessageDlg("Não foi possível gerar sequência da reserva!", mtError, mbOk, 0)
              vCl_DadosExecutaScroll = true
              vCl_OrdemExecutaScroll = true
              RaiseException("")
            end if
          End With

          Cl_DadosResevaAutomatica.First

          While NOT EOF
            If VerificaPermissaoReserva() then
              IF Cl_DadosResevaAutomatica.FieldByName("SALDO_ITEM").Value > 0 THEN

                '// ShowMessage(Cl_DadosResevaAutomatica.FieldByName("SALDO_ITEM").Value)

                GeraOE(Cl_DadosResevaAutomatica,"S",vRES_IN_SEQUENCIA)
              End If
            End If
            Cl_DadosResevaAutomatica.Next
          Wend

          With FormAtivo.Cl_Dados
            Close
            Open
          End With

          With Cl_FS_RESERVAAUTO_Update
            ParamByName("pRES_IN_CODIGO").Value = vRES_IN_SEQUENCIA
            ExecSQL
          End With

          MessageDlg("Operação Concluída!", mtInformation, mbOk, 0)

        End If
      End With
    End With
    vCl_DadosExecutaScroll = true
    vCl_OrdemExecutaScroll = true
     With Cl_OrdemExpedicao
      Close
      Open
    End With
  End If
End Sub

Sub Cl_DadosResevaAutomatica_OnBeforeOpen(sender as TMgClientDataSet)

  Dim pTodos

  With FormAtivo
    IF NOT Ck_B2B.Checked and NOT Ck_B2C.Checked AND NOT Ck_Exportacao.Checked AND NOT Ck_HIBRIDO.Checked AND NOT Ck_OUTROS.Checked AND NOT Ck_Indefinido.Checked then
      pTodos = "S"
    Else
      pTodos = "N"
    End If
  End With

  With sender
    Filtered = false

    If FormAtivo.Op_Sim.Checked then
      ParamByName("pParcial").Value = "S"
    Else
      If FormAtivo.Op_Nao.Checked then
        ParamByName("pParcial").Value = "N"
      Else
        If FormAtivo.Op_Todos.Checked then
          ParamByName("pParcial").Value = "T"
        End If
      End if
    End If


    if FormAtivo.Gb_Prioridade.Checked then
      ParamByName("pPrioridade").Value = StrToInt(Mgleft(FormAtivo.Cb_Prioridade.Text,1))
    else
      ParamByName("pPrioridade").Value = Null
    End If

    if FormAtivo.Gb_StatusEntrega.Checked then
       ParamByName("pStatusEntrega").Value = FormAtivo.Cb_EntregaStatus.Text
    else
       ParamByName("pStatusEntrega").Value = Null
    end if

    '// --- filtro de representante
    if FormAtivo.Gb_Representante.Checked then
      ParamByName("pREP_IN_CODIGO").Value = StrToInt(FormAtivo.Ed_REP_IN_CODIGO.Text)
    else
      ParamByName("pREP_IN_CODIGO").Value = Null
    end if

    '// --- filtro de Tipo Documento
    if FormAtivo.Gb_TipoDoc.Checked then
      ParamByName("pTPD_IN_CODIGO").Value = StrToInt(FormAtivo.Ed_TipoDoc.Text)
    else
      ParamByName("pTPD_IN_CODIGO").Value = Null
    end if

    if FormAtivo.Gb_Entrega.Checked then
       ParamByName("pENTREGA_INICIAL").Value = FormAtivo.Cl_Parametros.FieldByName("ENTREGA_INICIAL").Value
       ParamByName("pENTREGA_FINAL").Value   = FormAtivo.Cl_Parametros.FieldByName("ENTREGA_FINAL").Value
    else
       ParamByName("pENTREGA_INICIAL").Value = Null
       ParamByName("pENTREGA_FINAL").Value   = Null
    end if

    if FormAtivo.Gb_DataCliente.Checked then
       ParamByName("pDATA_CLIENTE_INICIAL").Value = FormAtivo.Cl_Parametros.FieldByName("DATA_CLIENTE_INICIAL").Value
       ParamByName("pDATA_CLIENTE_FINAL").Value   = FormAtivo.Cl_Parametros.FieldByName("DATA_CLIENTE_FINAL").Value
    else
       ParamByName("pDATA_CLIENTE_INICIAL").Value = Null
       ParamByName("pDATA_CLIENTE_FINAL").Value   = Null
    end if

    if FormAtivo.Gb_Emissao.Checked then
       ParamByName("pEMISSAO_INICIAL").Value = FormAtivo.Cl_Parametros.FieldByName("EMISSAO_INICIAL").Value
       ParamByName("pEMISSAO_FINAL").Value   = FormAtivo.Cl_Parametros.FieldByName("EMISSAO_FINAL").Value
    else
       ParamByName("pEMISSAO_INICIAL").Value = Null
       ParamByName("pEMISSAO_FINAL").Value   = Null
    end if

    if FormAtivo.Gb_Pedido.Checked then
       ParamByName("pPEDIDO_INICIAL").Value = FormAtivo.Cl_Parametros.FieldByName("PEDIDO_INICIAL").Value
       ParamByName("pPEDIDO_FINAL").Value   = FormAtivo.Cl_Parametros.FieldByName("PEDIDO_FINAL").Value
    else
       ParamByName("pPEDIDO_INICIAL").Value = Null
       ParamByName("pPEDIDO_FINAL").Value   = Null
    end if

    if FormAtivo.Gb_CodItem.Checked then
       ParamByName("pITEM_INICIAL").Value   = FormAtivo.Ed_CodItemInicial.Text
       ParamByName("pITEM_FINAL").Value     = FormAtivo.Ed_CodItemFinal.Text
    else
       ParamByName("pITEM_INICIAL").Value   = null
       ParamByName("pITEM_FINAL").Value     = null
    end if

    if FormAtivo.Gb_Grupos.Checked then
       ParamByName("pGRUPO_INICIAL").Value  = FormAtivo.Ed_GruposInicial.Text
       ParamByName("pGRUPO_FINAL").Value    = FormAtivo.Ed_GruposFinal.Text
    else
       ParamByName("pGRUPO_INICIAL").Value  = null
       ParamByName("pGRUPO_FINAL").Value    = null
    end if

    '//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 6 - Início
    if FormAtivo.Gb_GrupoCliente.Checked then
       ParamByName("PGRUPOCLIENTE_INICIAL").Value = FormAtivo.Ed_GrupoClienteInicial.Text
       ParamByName("PGRUPOCLIENTE_FINAL").Value   = FormAtivo.Ed_GrupoClienteFinal.Text
    else
       ParamByName("PGRUPOCLIENTE_INICIAL").Value = null
       ParamByName("PGRUPOCLIENTE_FINAL").Value   = null
    end if
    '//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 6 - Fim

    if FormAtivo.Gb_SubGrupos.Checked then
       ParamByName("pSUBGRUPO_INICIAL").Value  = FormAtivo.Ed_SubGruposInicial.Text
       ParamByName("pSUBGRUPO_FINAL").Value    = FormAtivo.Ed_SubGruposFinal.Text
    else
       ParamByName("pSUBGRUPO_INICIAL").Value  = null
       ParamByName("pSUBGRUPO_FINAL").Value    = null
    end if

    if FormAtivo.Gb_Cliente.Checked then
       ParamByName("pCLIENTE_INICIAL").Value  = FormAtivo.Ed_ClienteInicial.Text
       ParamByName("pCLIENTE_FINAL").Value    = FormAtivo.Ed_ClienteFinal.Text
    else
       ParamByName("pCLIENTE_INICIAL").Value  = Null
       ParamByName("pCLIENTE_FINAL").Value    = Null
    end if

    if FormAtivo.Gb_NotaFiscal.Checked then
       ParamByName("pNOTA_INICIAL").Value  = FormAtivo.Cl_Parametros.FieldByName("NOTA_INICIAL").Value
       ParamByName("pNOTA_FINAL").Value    = FormAtivo.Cl_Parametros.FieldByName("NOTA_FINAL").Value
    else
       ParamByName("pNOTA_INICIAL").Value  = Null
       ParamByName("pNOTA_FINAL").Value    = Null
    end if

    if FormAtivo.Gb_StatusOE.Checked then
       ParamByName("pStatusOE").Value  = FormAtivo.Cb_StatusOE.Text
    else
       ParamByName("pStatusOE").Value  = Null
    end if

    IF FormAtivo.Gb_Status.Checked then
      ParamByName("pStatus").Value  = FormAtivo.Cb_StatusPedido.Text
    Else
      ParamByName("pStatus").Value  = Null
    End If

    ParamByName("pB2B").Value          = FormAtivo.Cl_Parametros.FieldByName("B2B").Value
    ParamByName("pB2C").Value          = FormAtivo.Cl_Parametros.FieldByName("B2C").Value
    ParamByName("pEXPORTACAO").Value   = FormAtivo.Cl_Parametros.FieldByName("EXPORTACAO").Value
    ParamByName("pOUTROS").Value       = FormAtivo.Cl_Parametros.FieldByName("OUTROS").Value
    ParamByName("pHIBRIDO").Value      = FormAtivo.Cl_Parametros.FieldByName("HIBRIDO").Value
    ParamByName("pINDEFINIDO").Value   = FormAtivo.Cl_Parametros.FieldByName("INDEFINIDO").Value
    ParamByName("pTodos").Value        = pTodos

    ParamByName("pFIL_IN_CODIGO").Value = DMMega.Filial
    ParamByName("pUSU_IN_CODIGO").Value = DMMega.Usuario
  End With
End Sub

'//Exclusão em Massa das OE's do Pedido de Venda
Sub Cl_ExcluiOEPedido_OnBeforeOpen(sender as TmgClientDataSet)
  With sender
    ParamByName("pORG_TAB_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAB_IN_CODIGO").Value
    ParamByName("pORG_PAD_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_PAD_IN_CODIGO").Value
    ParamByName("pORG_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("ORG_IN_CODIGO").Value
    ParamByName("pORG_TAU_ST_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("ORG_TAU_ST_CODIGO").Value
    ParamByName("pSER_ST_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("SER_ST_CODIGO").Value
    ParamByName("pPED_IN_CODIGO").Value     = FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value
  End With
End Sub

Function VerificaPermissaoReserva()
  With FormAtivo
    With Cl_DadosResevaAutomatica
      If((FieldByName("B2B").Value        = "S") AND (vPermissaoB2B >=2) OR _
         (FieldByName("B2C").Value        = "S") AND (vPermissaoB2C >=2) OR _
         (FieldByName("EXPORTACAO").Value = "S") AND (vPermissaoExp >=2) OR _
         (FieldByName("OUTROS").Value     = "S") AND (vPermissaoOut >=2)) then
        return true
      Else
        return false
      End If
    End With
  End With
End Function

Sub ExcluiOEPedido()
  With FormAtivo

    Dim vSEQ_IN_CODIGO_RET, vEXP_IN_SEQUENCIA_RET, vEXP_IN_CODIGO_RET
    Dim vGerencia    = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_GERENCIA").Value    = "S"), _
        vRedistribui = (FormAtivo.Cl_Dados.FieldByName("NIV_CH_REDISTRIBUI").Value = "S")

    vCl_DadosExecutaScroll = false
    vCl_OrdemExecutaScroll = false
    Try
      If (vGerencia or vRedistribui)then
        If(MessageDlg("Deseja excluir a(s) OE(s) do Pedido: " & IntToStr(FormAtivo.Cl_Dados.FieldByName("PED_IN_CODIGO").Value) & " ? ", 3, 3, 0) = MrYes) Then
          With Cl_ExcluiOEPedido
            Close
            Open
            if RecordCount <= 0 then
              MessageDlg("Nenhuma OE disponível para exclusão!", mtWarning, mbOk, 0)
            Else
              Cl_ExcluiOEPedido.First
              While NOT EOF
                With Cl_IntegraOe
                  ParamByName("pORG_TAB_IN_CODIGO").Value    = Cl_ExcluiOEPedido.FieldByName("ORG_TAB_IN_CODIGO").Value
                  ParamByName("pORG_PAD_IN_CODIGO").Value    = Cl_ExcluiOEPedido.FieldByName("ORG_PAD_IN_CODIGO").Value
                  ParamByName("pORG_IN_CODIGO").Value        = Cl_ExcluiOEPedido.FieldByName("ORG_IN_CODIGO").Value
                  ParamByName("pORG_TAU_ST_CODIGO").Value    = Cl_ExcluiOEPedido.FieldByName("ORG_TAU_ST_CODIGO").Value
                  ParamByName("pFIL_IN_CODIGO").Value        = Cl_ExcluiOEPedido.FieldByName("FIL_IN_CODIGO").Value
                  ParamByName("pSER_ST_CODIGO").Value        = Cl_ExcluiOEPedido.FieldByName("SER_ST_CODIGO").Value
                  ParamByName("pPED_IN_CODIGO").Value        = Cl_ExcluiOEPedido.FieldByName("PED_IN_CODIGO").Value
                  ParamByName("pITP_IN_SEQUENCIA").Value     = Cl_ExcluiOEPedido.FieldByName("ITP_IN_SEQUENCIA").Value
                  ParamByName("pIPE_IN_SEQUENCIA").Value     = Cl_ExcluiOEPedido.FieldByName("IPE_IN_SEQUENCIA").Value
                  ParamByName("pIPE_RE_QUANTIDADE").Value    = Cl_ExcluiOEPedido.FieldByName("IPE_RE_QUANTIDADE").Value
                  ParamByName("pEXP_DT_EMISSAO").Value       = Cl_ExcluiOEPedido.FieldByName("EXP_DT_EMISSAO").Value
                  ParamByName("pTRA_IN_CODIGO").Value        = Cl_ExcluiOEPedido.FieldByName("TRA_IN_CODIGO").Value
                  ParamByName("pEXP_IN_CODIGO").Value        = Cl_ExcluiOEPedido.FieldByName("EXP_IN_CODIGO").Value
                  ParamByName("pUSU_IN_CODIGO").Value        = DMMega.Usuario
                  ParamByName("pOPERACAO").Value             = "D"
                  ParamByName("pReservaAutomatica").Value    = "N"
                  ParamByName("pSEQ_IN_CODIGO_RET").Value    = vSEQ_IN_CODIGO_RET
                  ParamByName("pEXP_IN_SEQUENCIA_RET").Value = vEXP_IN_SEQUENCIA_RET
                  ParamByName("pEXP_IN_CODIGO_RET").Value    = vEXP_IN_CODIGO_RET
                  ExecSQL
                End With
                Cl_ExcluiOEPedido.Next
              Wend
            End if
          End With
        End if
      Else
        MessageDlg("Usuário não tem permissão para esta operação!", mtError, mbOk, 0)
      End if
    Catch
      MessageDlg("Não foi possível concluir a operação solicitada!", mtError, mbOk, 0)
    End Try

    Cl_Dados.Close
    Cl_Dados.Open

    vCl_DadosExecutaScroll = true
    vCl_OrdemExecutaScroll = true
    MessageDlg("Operação concluída com Sucesso!", mtInformation, mbOk, 0)
  End With
End Sub

Sub Bt_ExcluirOePedido_OnAfterClick()
    ExcluiOEPedido()
End Sub

Sub Bt_Comissao_OnAfterClick()
    ExecutaForm("FORM_FS_CONSULTA_COMISSAO").ShowModal
End Sub

Sub Cl_FS_APT_APONTAORDEM_OnBeforeOpen(sender as TmgClientDataSet)
  With sender
    ParamByName("pORG_TAB_IN_CODIGO").Value = Cl_OrdemExpedicao.FieldByName("ORG_TAB_IN_CODIGO").Value
    ParamByName("pORG_PAD_IN_CODIGO").Value = Cl_OrdemExpedicao.FieldByName("ORG_PAD_IN_CODIGO").Value
    ParamByName("pORG_IN_CODIGO").Value     = Cl_OrdemExpedicao.FieldByName("ORG_IN_CODIGO").Value
    ParamByName("pORG_TAU_ST_CODIGO").Value = Cl_OrdemExpedicao.FieldByName("ORG_TAU_ST_CODIGO").Value
    ParamByName("pSEQ_TAB_IN_CODIGO").Value = Cl_OrdemExpedicao.FieldByName("SEQ_TAB_IN_CODIGO").Value
    ParamByName("pSEQ_IN_CODIGO").Value     = Cl_OrdemExpedicao.FieldByName("SEQ_IN_CODIGO").Value
    ParamByName("pEXP_IN_SEQUENCIA").Value  = Cl_OrdemExpedicao.FieldByName("EXP_IN_SEQUENCIA").Value
  End With
End Sub

Sub Ed_PedidoInicial_OnExit
  With FormAtivo
    Cl_Parametros.FieldByName("PEDIDO_FINAL").Value  = Cl_Parametros.FieldByName("PEDIDO_INICIAL").Value
    Ed_PedidoFinal.SetFocus
  End With
End Sub

Sub Ed_CodItemInicial_OnAfterExit
  With FormAtivo
    Ed_CodItemFinal.Text = Ed_CodItemInicial.Text
    Ed_CodItemFinal.Atualiza
    Ed_CodItemFinal.SetFocus
  End With
End Sub

Sub Ed_ClienteInicial_OnAfterExit
  With FormAtivo
    Ed_ClienteFinal.Text = Ed_ClienteInicial.Text
    Ed_ClienteFinal.Atualiza
    Ed_ClienteFinal.SetFocus
  End With
End Sub

Sub Ed_NotaInicial_OnExit
  With FormAtivo
    Cl_Parametros.FieldByName("NOTA_FINAL").Value  = Cl_Parametros.FieldByName("NOTA_INICIAL").Value
    Ed_NotaFinal.SetFocus
  End With
End Sub

Sub Ed_GruposInicial_OnAfterExit
  With FormAtivo
    Ed_GruposFinal.Text = Ed_GruposInicial.Text
    Ed_GruposFinal.Atualiza
    Ed_GruposFinal.SetFocus
  End With
End Sub

'//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 7 - Início
Sub Ed_GrupoClienteInicial_OnAfterExit
  With FormAtivo
    Ed_GrupoClienteFinal.Text = Ed_GrupoClienteInicial.Text
    Ed_GrupoClienteFinal.Atualiza
    Ed_GrupoClienteFinal.SetFocus
  End With
End Sub
'//Luiz T.I. 10/06/2026 08:10 | Chamado 2188 Parte 7 - Fim

Sub Ed_SubGruposInicial_OnAfterExit
  With FormAtivo
    Ed_SubGruposFinal.Text = Ed_SubGruposInicial.Text
    Ed_SubGruposFinal.Atualiza
    Ed_SubGruposFinal.SetFocus
  End With
End Sub

Sub Bt_Simulacao_Corte
  ExecutaForm("FORM_FS_PLANO_CORTE_VISAO_PED").ShowModal
End Sub

Sub cCL_DataHorizonte_OnBeforeOpen(Sender)
  With Sender
    ParamByName("PFIL_IN_CODIGO").Value = DMMega.Filial
    ParamByName("PPRO_IN_CODIGO").Value = FormAtivo.Cl_Dados.FieldByName("PRO_IN_CODIGO").Value
  End With
End Sub

Sub Mi_PedProg_OnAfterClick
  With FormAtivo
    ExecutaForm("FORM_FS_PROG_ENTREGA").ShowModal
  End With
End Sub

Sub Mi_AlteraComissao_OnAfterClick
  With FormAtivo
    ExecutaForm("FORM_FS_REPRESENTANTEITEMDOC").ShowModal
  End With
End Sub

Sub Mi_Romaneio_OnAfterClick
  With FormAtivo
    ExecutaForm("FORM_FS_ORDEM_ROMANEIO").ShowModal
  End With
End Sub

Sub Mi_Romaneio_OE_OnAfterClick
  With FormAtivo
    ExecutaForm("FORM_FS_COLETOR_OE").ShowModal
  End With
End Sub

'//--------------------------------------------------------
'//-------------------- FUNÇÕES PADRÃO --------------------
'//--------------------------------------------------------
Sub subDesabilitaEdicao(pDataset As TMgClientDataset, pTableview)
  Dim i

  For i = 0 To pDataset.Fields.Count - 1
    If pTableview.GetColumnByFieldName(pDataset.Fields[i].FieldName) <> Nil Then
      With TcxGridDBColumn(pTableview.GetColumnByFieldName(pDataset.Fields[i].FieldName))
        If pDataset.Fields[i].FieldName In ["CONFIRMAR", "PED_BO_PARCIAL", "MINIMO_3PC", "CTD_CH_DATA_HORIZONTE"] Then
          subAcertaCampoCheckBox(pTableview, pDataset.Fields[i].FieldName)

          If pDataset.Fields[i].FieldName In ["MINIMO_3PC", "CTD_CH_DATA_HORIZONTE"] Then
            Options.Editing = False
          End If

        ElseIf pDataset.Fields[i].FieldName In ["PRIORIDADE"] Then
          subAcertaCampoComboBox(pTableview, pDataset.Fields[i].FieldName, Sl_Prioridade)

        ElseIf pDataset.Fields[i].FieldName In ["IPE_ST_STATUS"] Then
          subAcertaCampoComboBox(pTableview, pDataset.Fields[i].FieldName, Sl_StatusEntrega)

        ElseIf pDataset.Fields[i].FieldName In ["IPE_RE_QTDECONVERTIDA", "DATA_CLIENTE"] Then
          Options.Editing = True

        Else
          Options.Editing = False
          '//Options.Focusing = False
        End If
      End With
    End If
  Next
End Sub

Sub subAcertaCampoCheckBox(pTableview, pColuna)
  With pTableview.GetColumnByFieldName(pColuna)
    PropertiesClassName = "TcxCheckBoxProperties"
    '//Options.Editing = True
    Options.Filtering = False

    With TMgCxCheckBoxProperties(pTableview.GetColumnByFieldName(pColuna).Properties)
      ValueChecked = "S"
      ValueUnchecked = "N"
    End With

    '//ShowCheckBoxHeader = True
  End With
End Sub

Sub subAcertaCampoComboBox(pTableview, pColuna, pStringListItens)
  With pTableview.GetColumnByFieldName(pColuna)
    PropertiesClassName = "TcxComboBoxProperties"
    '//Options.Editing = True
    Options.Filtering = False

    With TMgDBComboBox(pTableview.GetColumnByFieldName(pColuna).Properties)
      Items = pStringListItens
      DataField = pColuna
      DataSource = pTableview.DataController.DataSource
    End With

    '//ShowCheckBoxHeader = True
  End With
End Sub
'//--------------------------------------------------------
'//-------------------- FUNÇÕES PADRÃO --------------------
'//--------------------------------------------------------