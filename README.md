# SimpleBlog
Uma aplicação que implementada boas práticas no desenvolvimento. Fazendo o uso de websocket para comunicação em tempo real.

Para subir a aplicação é necessário:

> 1. Docker versão 25.0.3 ou superior
<br>
> 2. Docker compose 2.24.6 ou superior

Docker pode ser baixado clicando [Aqui](https://www.docker.com/products/docker-desktop/).

Se utilizar S.O Windows, ao instalar o Docker será instalado o docker compose automaticamente.


A aplicação rodará na em http://localhost:5001/swagger/index.html

Passos:
- Com docker e docker compose disponível, vá até a raiz do projeto onde se encontra o arquivo `docker-compose.yml`
- Abra o terminal ou shell neste local
- Execute o comando `docker-compose up`

**Voilà**
#### A aplicação deve estar rodando e disponível em http://localhost:5001/swagger/index.html

### **OBS:**
-- Caso aja necessidade de reiniciar a base, apague a pasta "postgres-data" que é criada na raiz do projeto.
