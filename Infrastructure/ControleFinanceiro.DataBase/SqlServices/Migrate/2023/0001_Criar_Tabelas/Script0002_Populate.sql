Use ControleFinanceiro
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Dashboard' And ParentId Is Null) 
Begin
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= Null
		,Descricao	= 'Dashboard'
		,Icone		= 'dashboard'
		,RouterLink	= 'dashboard'
		,Ordem		= 1
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Meu Perfil' And ParentId Is Null) 
Begin
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= Null
		,Descricao	= 'Meu Perfil'
		,Icone		= 'person'
		,RouterLink	= 'meu-perfil'
		,Ordem		= 2
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Finanças' And ParentId Is Null) 
Begin
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= Null
		,Descricao	= 'Finanças'
		,Icone		= 'insert_chart'
		,RouterLink	= Null
		,Ordem		= 3
		,Ativo		= 1
End
Go

If Not Exists (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Gastos' And 
				ParentId In (Select 1 From SistemaMenu (Nolock) Where Descricao = 'Finanças')) 
Begin
	Declare @ParentId Int = (Select Top 1 SistemaMenuId From SistemaMenu (Nolock) Where Descricao = 'Finanças')
	Insert Into SistemaMenu
	(
		 ParentId
		,Descricao
		,Icone
		,RouterLink
		,Ordem
		,Ativo
	)
	Select
		 ParentId	= @ParentId
		,Descricao	= 'Gastos'
		,Icone		= 'credit_card'
		,RouterLink	= 'gasto'
		,Ordem		= 1
		,Ativo		= 1
End
Go

If Not Exists (Select Top 1 1 From GastoTipo (Nolock)) 
Begin
	Insert Into GastoTipo
	(
		Descricao
	)
	Values
	 ('Gasto Fixo')
	,('Gasto Variável')
End
Go
