# Nubank Authorizer

This README explains critical and essencial topics of this solution

## Frameworks
## Pattern decision 

State Pattern -> There is many kinds of states that an account can be, this pattern can help us to make decisions according to state of an account, example, one suspended account cant me deposit, one valid account can do 
Rule Pattern -> This pattern allow us to desentralize our rules from our logic and model code. This can be useful for maintenance of a system, cause the organizations of rules allow we go direct on the point


```bash
pip install foobar
```

## Usage

```python
import foobar

# returns 'words'
foobar.pluralize('word')

# returns 'geese'
foobar.pluralize('goose')

# returns 'phenomenon'
foobar.singularize('phenomena')
```

## References
Special character json field name -> https://stackoverflow.com/questions/38719368/special-characters-in-property-name
Newtosoft Json -> https://www.newtonsoft.com/
Map with reserved words -> https://stackoverflow.com/questions/38391324/map-json-to-c-sharp-class-with-attribute-names-having-space-and-reserve-words
String enums -> https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp
State Pattern -> https://codewithshadman.com/state-pattern-csharp/
State Pattern -> https://www.dofactory.com/net/state-design-pattern
Rule Pattern -> https://stackoverflow.com/questions/16849656/design-pattern-to-implement-business-rules-with-hundreds-of-if-else-in-java
Rule Pattern -> https://www.michael-whelan.net/rules-design-pattern/
Last elements of List -> https://stackoverflow.com/questions/3453274/using-linq-to-get-the-last-n-elements-of-a-collection
Compare minutes -> https://www.tutorialspoint.com/calculate-minutes-between-two-dates-in-chash

## Jsons
{"account": {"active-card": true, "available-limit": 100}}
{"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T10:00:00.000Z"}}
{"transaction": {"merchant": "Habbib's", "amount": 90, "time": "2019-02-13T11:00:00.000Z"}}
{"transaction": {"merchant": "McDonald's", "amount": 30, "time": "2019-02-13T12:00:00.000Z"}}

# Processando uma transa��o com sucesso
 Input
 {"account": {"active-card": true, "available-limit": 100}}
 {"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}
 Output
 {"account": {"active-card": true, "available-limit": 100},"violations": []}
 {"account": {"active-card": true, "available-limit": 80},"violations": []}

Processando uma transa��o que viola a l�gica account-not-initialized
Quando uma opera��o de transa��o � processada sem que haja uma conta criada, o Autorizador deve
rejeitar a opera��o e retornar a viola��o account-not-initialized :
 Input
 {"account": {"active-card": true, "available-limit": 100}}
 {"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}
 Output
 {"account": {"active-card": true, "available-limit": 100},"violations": []}
 {"account": {"active-card": true, "available-limit": 80},"violations": []}
 Input
 {"transaction": {"merchant": "Uber Eats", "amount": 25, "time": "2020-12-01T11:07:00.000Z"}}
 {"account": {"active-card": true, "available-limit": 225}}
 {"transaction": {"merchant": "Uber Eats", "amount": 25, "time": "2020-12-01T11:07:00.000Z"}}
 Output
 {"account": {}, "violations": ["account-not-initialized"]}
 {"account": {"active-card": true, "available-limit": 225}, "violations": []}
 {"account": {"active-card": true, "available-limit": 200}, "violations": []}

# Processando uma transa��o que viola a l�gica card-not-active
	Dado uma conta com o cart�o inativo ( active-card: false ) quando qualquer opera��o de transa��o �
	submetida, o Autorizador deve rejeitar a opera��o e retornar a viola��o card-not-active :



 Input
 {"account": {"active-card": false, "available-limit": 100}}
 {"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}
 {"transaction": {"merchant": "Habbib's", "amount": 15, "time": "2019-02-13T11:15:00.000Z"}}
 Output
 {"account": {"active-card": false, "available-limit": 100}, "violations": []}
 {"account": {"active-card": false, "available-limit": 100}, "violations": ["cardnot-active"]}
 {"account": {"active-card": false, "available-limit": 100}, "violations": ["cardnot-active"]}
# Processando uma transa��o que viola a l�gica insufficient-limit :
	Dado uma conta com cart�o ativo ( active-card: true ) e limite dispon�vel de 1000 ( available-limit:
	1000 ), para qualquer opera��o de transa��o com o atributo amount acima do valor limite de 1000 o
	Autorizador deve rejeitar a opera��o e retornar a viola��o insufficient-limit :
	 Input
 {"account": {"active-card": true, "available-limit": 1000}}
 {"transaction": {"merchant": "Vivara", "amount": 1250, "time": "2019-02-13T11:00:00.000Z"}}
 {"transaction": {"merchant": "Samsung", "amount": 2500, "time": "2019-02-13T11:00:01.000Z"}}
 {"transaction": {"merchant": "Nike", "amount": 800, "time": "2019-02-13T11:01:01.000Z"}}
 Output
 {"account": {"active-card": true,"available-limit": 1000}, "violations": []}
 {"account": {"active-card": true,"available-limit": 1000}, "violations":["insufficient-limit"]}
 {"account": {"active-card": true,"available-limit": 1000}, "violations":["insufficient-limit"]}
 {"account": {"active-card": true,"available-limit": 200}, "violations": []}

# Processando uma transa��o que viola a l�gica high-frequency-small-interval
Dado uma conta com cart�o ativo ( active-card: true ), limite dispon�vel de 100 ( available-limit:
100 ) e 3 transa��es ocorreram com sucesso nos �lltimos 2 minutos. O Autorizador deve rejeitar a nova
opera��o de transa��o e retornar a viola��o high-frequency-small-interval :
Input
{"account": {"active-card": true, "available-limit": 100}}
 {"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}
 {"transaction": {"merchant": "Habbib's", "amount": 20, "time": "2019-02-13T11:00:01.000Z"}}
 {"transaction": {"merchant": "McDonald's", "amount": 20, "time": "2019-02-13T11:01:01.000Z"}}
 {"transaction": {"merchant": "Subway", "amount": 20, "time": "2019-02-13T11:01:31.000Z"}}
 {"transaction": {"merchant": "Burger King", "amount": 10, "time": "2019-02-13T12:00:00.000Z"}}
 Output
 {"account": {"active-card": true, "available-limit": 100}, "violations": []}
 {"account": {"active-card": true, "available-limit": 80}, "violations": []}
 {"account": {"active-card": true, "available-limit": 60}, "violations": []}x
 {"account": {"active-card": true, "available-limit": 40}, "violations": []}
 {"account": {"active-card": true, "available-limit": 40}, "violations": ["highfrequency-small-interval"]}
 {"account": {"active-card": true, "available-limit": 30}, "violations": []}

#Processando uma transa��o que viola a l�gica doubled-transaction
Dado uma conta com cart�o ativo ( active-card: true ), limite dispon�vel de 100 ( available-limit:
100 ) e algumas transa��es ocorridas com sucesso nos �lltimos 2 minutos. O Autorizador deve rejeitar a
nova opera��o de transa��o se ela compartilhar o mesmo valor ( amount ) e comerciamente ( merchant )
com qualquer uma das transa��es previamente aceitas e retornar a viola��o doubled-transaction :
 Input
 {"account": {"active-card": true, "available-limit": 100}}
 {"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}
 {"transaction": {"merchant": "McDonald's", "amount": 10, "time": "2019-02-13T11:00:01.000Z"}}
 {"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:02.000Z"}}
 {"transaction": {"merchant": "Burger King", "amount": 15, "time": "2019-02-13T11:00:03.000Z"}}
 Output
 {"account": {"active-card": true, "available-limit": 100}, "violations": []}
 {"account": {"active-card": true, "available-limit": 80}, "violations": []}
 {"account": {"active-card": true, "available-limit": 70}, "violations": []}
 {"account": {"active-card": true, "available-limit": 70}, "violations": ["doubledtransaction"]}
 {"account": {"active-card": true, "available-limit": 55}, "violations": []}
## General 
Using IntelliCode native 
