# Meu Consultório Psi

## Objetivo do sistema

Construir uma camada facilitada e de baixo custo para que profissionais autônomos da psicologia possam gerenciar os seus atendimentos e contatos com clientes.

## Usuários

Psicólogos, Psiquiatras, Fonoaudiólogos, Fisioterapeutas, Nutricionistas...

## Funcionalidades iniciais

- Ainda em desenvolvimento

## Funcionalidades futuras

- Cadastro de usuário com o papel de psicólogo
- Cadastro de clientes
- Cadastro de agendamentos

- Cadastro de prontuários
- Cadastro de relatórios
- Cadastro de atividades

## Entidades

**Psicólogo** / **Therapist**
- Representa o profissional que realiza os atendimentos
- Possui um vínculo com o usuário logado
- Pode ter multiplos agendamentos

**Paciente** / **Patient**
- Pessoa atendida pelo psicólogo
- Possui histórico de atendimentos

**Relação terapêutica** / **Treatment**
- Relaciona um psicólogo a um cliente
- Determina uma data de início e fim(opicional) do tratamento
- Registra se o tratamento está ativo ou não

**Regra de recorrência** / **RecurrenceRule**
- Se relaciona com uma relação terapeutica
- Determina a frequência dos atendimentos (Semanal, quinzenal, mensal e etc.)
- Estabelece um dia da semana para ocorrer o atendimento
- Estabelece uma hora de início do atendimento
- Estabelece a duração total do atendimento
- Registra se a regra está ativa ou não

**Agendamento** / **Appointment**
- Se relaciona com uma relação terapêutica
- Representa um atendimento em data e hora específica
- Possui status (Agendado, Cancelado, Realizado)
- Não pode ter mais de um agendamento por data e hora


Relacionamentos
```
Therapist ─┐
           ├─ Treatment ─┬─ RecurrenceRule
Patient  ──┘             └─ Appointment
```