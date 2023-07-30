**Criar nesta pasta estrutura de pastas para execução dos scripts de produção**

- Todo script deve conter validação para não executar duas vezes o mesmo comando
- O script deve levar em consideração no caso de campos que não aceitem nulos, a definição de um valor inicial.

ex:

If Not Exists(Select Top 1 * From INFORMATION_SCHEMA.COLUMNS Where [TABLE_NAME] = 'MinhaTabela' And [COLUMN_NAME] = 'MinhaColuna')
Begin
	Alter Table [MinhaTabela] Add [MinhaColuna] Bit Null;

	Update [MinhaTabela] Set [MinhaColuna] = 0;

	Alter Table [MinhaTabela] Alter Column [MinhaColuna] Bit Not Null Default(0);
End