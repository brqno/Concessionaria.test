-- Tabela CLIENTES
CREATE TABLE Clientes (
    Id INT PRIMARY KEY,
    Nome VARCHAR(100),
    Idade INT,
    CPF_CNPJ VARCHAR(20) UNIQUE, -- CPF/CNPJ único
    Email VARCHAR(100),
    Endereco VARCHAR(200),
    Pagamento VARCHAR(50)
);

-- Tabela VEICULOS
CREATE TABLE Veiculos (
    Id INT PRIMARY KEY,
    Nome VARCHAR(100),
    Placa VARCHAR(10) UNIQUE, -- Placa única
    Modelo VARCHAR(100),
    Ano INT,
    Preco DECIMAL(10, 2)
);

-- Tabela VENDEDORES
CREATE TABLE Vendedores (
    Id INT PRIMARY KEY,
    Nome VARCHAR(100),
    Idade INT,
    CPF_CNPJ VARCHAR(20) UNIQUE, -- CPF/CNPJ único
    Usuario VARCHAR(50),
    Senha VARCHAR(50)
);
