# Projeto: Sistema de Agendamento para Autônomos

Este repositório existe com um objetivo claro: **aprender .NET de forma prática, progressiva e aplicável ao mundo real**, evitando excesso de abstrações, padrões prematuros e dependência de tutoriais.

O projeto consiste em um **sistema de agendamento** para profissionais autônomos (**psicólogos**, personal trainers, barbeiros, terapeutas, etc.).

---

## 🎯 Objetivo Geral
Construir uma aplicação **fullstack** com:
- Backend em **ASP.NET Core Web API**
- Frontend (a definir: React ou Blazor)
- Regras de negócio reais
- Evolução incremental

O foco não é apenas "funcionar", mas **entender o porquê das decisões técnicas**.

---

# 📌 Metas do Projeto

## META 0 — Decisão técnica mínima

### Backend
- ASP.NET Core Web API
- Controllers (não usar Minimal APIs inicialmente)
- Entity Framework Core
- Banco de dados: SQLite ou PostgreSQL local

### Frontend
🚫 **Não escolher ainda**

A decisão do frontend será feita **após a Meta 3**, quando o backend estiver estável.

---

## META 1 — Domínio e regras de negócio (sem código)

### Objetivo
Entender o problema antes de escrever código.

### Entidades principais
- Profissional
- Cliente
- Agendamento

### Regras mínimas
- Um agendamento pertence a um profissional
- Um horário não pode ser duplamente agendado
- Um agendamento possui:
  - Data
  - Hora de início
  - Duração
  - Status (marcado, cancelado)

📌 Esta meta deve ser documentada (README, notas, diagramas simples).

### Ignorar conscientemente
- Autenticação
- Identity
- Frontend
- Docker
- Deploy

---

## META 2 — Backend cru (CRUD funcional)

### Objetivo
Criar uma API funcional, mesmo que simples e "feia".

### Implementar
- Projeto ASP.NET Core Web API
- Controllers para:
  - Profissionais
  - Clientes
  - Agendamentos
- Entity Framework Core
- Migrations
- CRUD básico

### Mínimo aceitável
- Criar profissional
- Criar cliente
- Criar agendamento
- Listar agendamentos por profissional

Se funcionar via Swagger, está suficiente.

### Ignorar conscientemente
- Validações avançadas
- DTOs perfeitos
- Paginação
- Testes
- Segurança

---

## META 3 — Regras de negócio reais

### Objetivo
Deixar de pensar apenas em CRUD e começar a pensar como backend developer.

### Implementar
- Impedir conflitos de horário
- Impedir agendamento no passado
- Cancelamento altera status (não remove registro)

### Mínimo aceitável
- Conflito de horário funcionando
- Retorno de erro claro (400 ou 409)

### Ignorar conscientemente
- DDD formal
- Repository Pattern genérico
- Services excessivamente abstratos

---

## ⏸️ PAUSA NO BACKEND

Neste ponto o sistema já possui:
- API útil
- Regras reais
- Swagger funcional

👉 **Este é o momento correto para iniciar o frontend.**

---

## META 4 — Escolha do Frontend

### Opções
- **React** → mercado amplo, JavaScript moderno
- **Angular** → estrutura enterprise (não recomendado neste projeto)
- **Blazor** → C# do backend ao frontend

📌 Escolher **apenas uma tecnologia** e ignorar as outras.

---

## META 5 — Frontend mínimo (funcional)

### Objetivo
Consumir a API. Apenas isso.

### Telas mínimas
- Listagem de profissionais
- Listagem de horários disponíveis
- Criar agendamento
- Cancelar agendamento

### Mínimo aceitável
- Funcional
- Feio
- Sem preocupação estética

### Ignorar conscientemente
- CSS avançado
- Responsividade perfeita
- UX refinado
- Login

---

## META 6 — Integração fullstack real

### Objetivo
Pensar no sistema como um todo.

### Implementar
- Tratamento de erros vindos da API
- Estados de carregamento
- Mensagens claras para o usuário

### Ignorar conscientemente
- Gerenciamento de estado complexo
- Cache
- Otimizações prematuras

---

## META 7 — Autenticação (somente agora)

### Objetivo
Aprender segurança com contexto real.

### Implementar
- Autenticação JWT simples
- Profissional só acessa seus dados
- Cliente só acessa seus agendamentos

### Mínimo aceitável
- Login
- Token
- Authorization básica

### Ignorar conscientemente
- Refresh token
- Identity completo
- OAuth

---

## META 8 — Refinamento técnico (opcional)

Escolher **1 ou 2 tópicos**, não todos:
- Identity
- Testes automatizados
- Docker
- Deploy simples

---

# 🚫 O que evitar durante todo o projeto

Não implementar prematuramente:
- Clean Architecture completa
- CQRS
- Mediator
- Event sourcing
- Microservices
- Kubernetes
- Padrões enterprise sem necessidade

---

## ✅ Critério de sucesso

O projeto é bem-sucedido se for possível:
- Explicar as decisões técnicas
- Demonstrar uma API real e funcional
- Demonstrar um frontend funcional
- Evoluir o sistema sem reescrever tudo

---

Este README é um **guia de estudo**, não uma checklist rígida.
