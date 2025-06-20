# 🌍 Travel Agency Management System

Este projeto é um sistema web desenvolvido em **ASP.NET Core com Razor Pages**, que simula a gestão de uma **agência de viagens**. O sistema permite o cadastro de destinos, pacotes turísticos, clientes, reservas e gerenciamento de anotações internas.

---

## 🚀 Funcionalidades

- ✅ Cadastro e gerenciamento de **Destinos** (com exclusão lógica)
- ✅ Cadastro e gerenciamento de **Pacotes Turísticos**, com:
  - Associação de múltiplos destinos
  - Controle de capacidade máxima
- ✅ Cadastro e gerenciamento de **Clientes**
- ✅ Sistema completo de **Reservas**, com:
  - Validação de capacidade
  - Validação de data futura
  - Prevenção de reservas duplicadas para o mesmo cliente e pacote
- ✅ Sistema de **anotações internas**, com:
  - Criação de arquivos `.txt`
  - Listagem e leitura dos arquivos criados
- ✅ Sistema de **autenticação** baseado em login e senha definidos no código
- ✅ Proteção de páginas sensíveis com `[Authorize]`
- ✅ Layout moderno, responsivo e intuitivo, utilizando Bootstrap e estilização personalizada

---

## 🔐 Login de Acesso

- **Usuário:** `admin`  
- **Senha:** `123456`

> ⚠️ Este sistema utiliza autenticação simples, sem persistência em banco de dados.

---

## 🏗️ Tecnologias Utilizadas

- ASP.NET Core com Razor Pages
- Entity Framework Core (com SQLite)
- C#
- Bootstrap 5
- HTML, CSS e Razor
- Autenticação baseada em Cookies

---

## 🔧 Como Executar o Projeto

1. Clone este repositório:

```bash
git clone https://github.com/seu-usuario/TravelAgency.git
```

2. Navegue até a pasta do projeto:
```bash
cd TravelAgency
```

3. Execute as migrations e crie o banco de dados:
```bash
dotnet ef database update
```

4. Execute a aplicação:
```bash
dotnet run
```
