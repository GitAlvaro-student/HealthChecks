# .NET Core HealthChecks

Este repositório contém exemplos e guias práticos sobre a implementação de **HealthChecks** em aplicações .NET.

---

## 🔍 O que são HealthChecks?

Em tradução livre, são "verificações de saúde". No contexto do .NET, o **HealthChecks** é um middleware que expõe um endpoint (geralmente `/health`) que informa se a aplicação está funcionando corretamente ou não.

Em vez de apenas saber se o servidor está "ligado", essa ferramenta verifica os componentes vitais que fazem a aplicação ser realmente funcional, como:
* Conexão com o **Banco de Dados**.
* Disponibilidade de **APIs externas**.
* Resposta de serviços de **mensageria** (RabbitMQ, Redis, etc).
* Integridade de memória e disco.

---

## 🚀 Por que eles são importantes?

A principal importância dos HealthChecks é permitir o **monitoramento automatizado** do sistema:

1.  **Orquestradores (Kubernetes):** Se uma instância da aplicação reportar um status "Unhealthy" (doente), o orquestrador pode reiniciá-la ou remover o tráfego dela automaticamente.
2.  **Load Balancers:** Evita que utilizadores sejam enviados para um servidor que está ativo, mas incapaz de processar dados (ex: sem ligação ao banco).
3.  **Diagnóstico Rápido:** Em arquiteturas de microserviços, permite identificar em segundos qual peça da engrenagem falhou, reduzindo o tempo de inatividade (**Downtime**).

---

## 📊 Estados de Saúde

Uma verificação de saúde geralmente retorna três estados principais:

* ✅ **Healthy:** Tudo a operar normalmente.
* ⚠️ **Degraded:** A aplicação responde, mas com performance reduzida ou falha num componente não crítico.
* ❌ **Unhealthy:** Falha crítica. A aplicação não deve receber requisições.
