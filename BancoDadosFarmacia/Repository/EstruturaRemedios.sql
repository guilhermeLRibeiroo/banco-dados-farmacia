CREATE TABLE produtos_remedios 
(
	id INT PRIMARY KEY IDENTITY(1,1),
	
	nome VARCHAR(100),
	faixa VARCHAR(100),
	categoria VARCHAR(100),

	generico BIT,
	solido BIT,
	precisa_receita BIT,
	
	bula TEXT
);