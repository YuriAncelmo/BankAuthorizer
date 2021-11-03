# Bank Transaction Authorizer

This README explains critical and essencial topics of this solution

## Framework
	- .Net Framework 6.0 , with development in Visual Studio 2022 Preview. I decided for because is the most recent framework of .Net and we can help community to improve this release candidate.
## Pattern decision 

- **State Pattern**	There is many kinds of states that an account can be, this pattern can help us to make decisions according to state of an account, example, one suspended account cant me deposit, one valid account can do 
- **Rule Pattern** 	This pattern allow us to desentralize our rules from our logic and model code. This can be useful for maintenance of a system, cause the organizations of rules allow we go direct on the point
## Build Application on Temporary Container 

Certify that you have Docker running, then , in the folder of project ChallengeCodeAuthorizer run the build.cmd file.
This file will compile the application in the folder bin, create the image and upload to a temporary container.


## Build 
Open CLI from .Net, and run follow command
```dotnet publish -c Release
```
After this, you will be able to view the application compiled in folder ..\ChallengeCodeAuthorizer\ChallengeCodeAuthorizer\bin\Release\net6.0
If you want run in windows, only you need is run ChallengeCodeAuthorizer.exe

## Create Image for Container
With docker installed run 
```docker build -t authorizer-image -f Dockerfile .```

## Create a Container 
With Image created run 
```docker create --name authorizer authorizer-image```

## Start and stop container 
When you want to start or stop container, you only need to run 
```docker start[or stop] authorizer```

## Execute 
The following command attach to container and allow to test
```docker attach --sig-proxy=false authorizer```

## References
- Special character json field name 
	- https://stackoverflow.com/questions/38719368/special-characters-in-property-name
- Newtosoft Json 
	- https://www.newtonsoft.com/
- Map with reserved words 
	- https://stackoverflow.com/questions/38391324/map-json-to-c-sharp-class-with-attribute-names-having-space-and-reserve-words
- String enums 
	- https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp
- State Pattern 
	- https://codewithshadman.com/state-pattern-csharp/
	- https://www.dofactory.com/net/state-design-pattern
- Rule Pattern 
	- https://stackoverflow.com/questions/16849656/design-pattern-to-implement-business-rules-with-hundreds-of-if-else-in-java
	- https://www.michael-whelan.net/rules-design-pattern/
- Last elements of List 
	- https://stackoverflow.com/questions/3453274/using-linq-to-get-the-last-n-elements-of-a-collection
- Compare minutes 
	- https://www.tutorialspoint.com/calculate-minutes-between-two-dates-in-chash
- Build Container
	- https://docs.microsoft.com/pt-br/dotnet/core/docker/build-container?tabs=windows

# Jsons

## Processando uma transação com sucesso
	{"account": {"active-card": true, "available-limit": 100}}
	{"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}

Output: 
		{"account": {"active-card": true, "available-limit": 100},"violations": []}
		{"account": {"active-card": true, "available-limit": 80},"violations": []}

## Processando uma transação que viola a lógica account-not-initialized - 1
	{"account": {"active-card": true, "available-limit": 100}}
	{"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}

Output: 
		{"account": {"active-card": true, "available-limit": 100},"violations": []}
		{"account": {"active-card": true, "available-limit": 80},"violations": []}
 
## Processando uma transação que viola a lógica account-not-initialized - 2
	{"transaction": {"merchant": "Uber Eats", "amount": 25, "time": "2020-12-01T11:07:00.000Z"}}
	{"account": {"active-card": true, "available-limit": 225}}
	{"transaction": {"merchant": "Uber Eats", "amount": 25, "time": "2020-12-01T11:07:00.000Z"}}
	
Output:
		{"account": {}, "violations": ["account-not-initialized"]}
		{"account": {"active-card": true, "available-limit": 225}, "violations": []}
		{"account": {"active-card": true, "available-limit": 200}, "violations": []}

## Processando uma transação que viola a lógica card-not-active
	{"account": {"active-card": false, "available-limit": 100}}
	{"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}
	{"transaction": {"merchant": "Habbib's", "amount": 15, "time": "2019-02-13T11:15:00.000Z"}}
	
Output: 
		{"account": {"active-card": false, "available-limit": 100}, "violations": []}
		{"account": {"active-card": false, "available-limit": 100}, "violations": ["cardnot-active"]}
		{"account": {"active-card": false, "available-limit": 100}, "violations": ["cardnot-active"]}
## Processando uma transação que viola a lógica insufficient-limit
	{"account": {"active-card": true, "available-limit": 1000}}
	{"transaction": {"merchant": "Vivara", "amount": 1250, "time": "2019-02-13T11:00:00.000Z"}}
	{"transaction": {"merchant": "Samsung", "amount": 2500, "time": "2019-02-13T11:00:01.000Z"}}
	{"transaction": {"merchant": "Nike", "amount": 800, "time": "2019-02-13T11:01:01.000Z"}}
	
Output:
		{"account": {"active-card": true,"available-limit": 1000}, "violations": []}
		{"account": {"active-card": true,"available-limit": 1000}, "violations":["insufficient-limit"]}
		{"account": {"active-card": true,"available-limit": 1000}, "violations":["insufficient-limit"]}
		{"account": {"active-card": true,"available-limit": 200}, "violations": []}

## Processando uma transação que viola a lógica high-frequency-small-interval
	{"account": {"active-card": true, "available-limit": 100}}
	{"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}
	{"transaction": {"merchant": "Habbib's", "amount": 20, "time": "2019-02-13T11:00:01.000Z"}}
	{"transaction": {"merchant": "McDonald's", "amount": 20, "time": "2019-02-13T11:01:01.000Z"}}
	{"transaction": {"merchant": "Subway", "amount": 20, "time": "2019-02-13T11:01:31.000Z"}}
	{"transaction": {"merchant": "Burger King", "amount": 10, "time": "2019-02-13T12:00:00.000Z"}}
	
Output:
		{"account": {"active-card": true, "available-limit": 100}, "violations": []}
		{"account": {"active-card": true, "available-limit": 80}, "violations": []}
		{"account": {"active-card": true, "available-limit": 60}, "violations": []}x
		{"account": {"active-card": true, "available-limit": 40}, "violations": []}
		{"account": {"active-card": true, "available-limit": 40}, "violations": ["highfrequency-small-interval"]}
		{"account": {"active-card": true, "available-limit": 30}, "violations": []}

## Processando uma transação que viola a lógica doubled-transaction
	{"account": {"active-card": true, "available-limit": 100}}
	{"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:00.000Z"}}
	{"transaction": {"merchant": "McDonald's", "amount": 10, "time": "2019-02-13T11:00:01.000Z"}}
	{"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:02.000Z"}}
	{"transaction": {"merchant": "Burger King", "amount": 15, "time": "2019-02-13T11:00:03.000Z"}}

Output:
		{"account": {"active-card": true, "available-limit": 100}, "violations": []}
		{"account": {"active-card": true, "available-limit": 80}, "violations": []}
		{"account": {"active-card": true, "available-limit": 70}, "violations": []}
		{"account": {"active-card": true, "available-limit": 70}, "violations": ["doubledtransaction"]}
		{"account": {"active-card": true, "available-limit": 55}, "violations": []}

## Processando transações que violam multiplas lógicas
	{"account": {"active-card": true, "available-limit": 100}}    
	{"transaction": {"merchant": "McDonald's", "amount": 10, "time": "2019-02-13T11:00:01.000Z"}}    
	{"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T11:00:02.000Z"}}    
	{"transaction": {"merchant": "Burger King", "amount": 5, "time": "2019-02-13T11:00:07.000Z"}}    
	{"transaction": {"merchant": "Burger King", "amount": 5, "time": "2019-02-13T11:00:08.000Z"}}    
	{"transaction": {"merchant": "Burger King", "amount": 150, "time": "2019-02-13T11:00:18.000Z"}}    
	{"transaction": {"merchant": "Burger King", "amount": 190, "time": "2019-02-13T11:00:22.000Z"}}    
	{"transaction": {"merchant": "Burger King", "amount": 15, "time": "2019-02-13T12:00:27.000Z"}}
Output:
	{"account":{"active-card":true,"available-limit":100},"violations":[]}    
	{"account":{"active-card":true,"available-limit":90},"violations":[]}    
	{"account":{"active-card":true,"available-limit":70},"violations":[]}    
	{"account":{"active-card":true,"available-limit":65},"violations":[]}    
	{"account":{"active-card":true,"available-limit":65},"violations":["high-frequency-small-interval","double-transaction"]}    
	{"account":{"active-card":true,"available-limit":65},"violations":["insufficient-limit","high-frequency-small-interval"]}    
	{"account":{"active-card":true,"available-limit":65},"violations":["insufficient-limit","high-frequency-small-interval"]}    
	{"account":{"active-card":true,"available-limit":50},"violations":[]}

## Estado da Aplicação 
	{"account": {"active-card": true, "available-limit": 1000}}    
	{"transaction": {"merchant": "Vivara", "amount": 1250, "time": "2019-02-13T11:00:00.000Z"}}    
	{"transaction": {"merchant": "Samsung", "amount": 2500, "time": "2019-02-13T11:00:01.000Z"}}    
	{"transaction": {"merchant": "Nike", "amount": 800, "time": "2019-02-13T11:01:01.000Z"}}    
	{"transaction": {"merchant": "Uber", "amount": 80, "time": "2019-02-13T11:01:31.000Z"}}

Output:
{"account": {"active-card": true, "available-limit": 1000},"violations": []}    
{"account": {"active-card": true, "available-limit": 1000},"violations":["insufficient-limit"]}    
{"account": {"active-card": true, "available-limit": 1000},"violations":["insufficient-limit"]}    
{"account": {"active-card": true, "available-limit": 200},"violations": []}    
{"account": {"active-card": true, "available-limit": 120},"violations": []}
## General 
Using IntelliCode native 
