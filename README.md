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

## Jsons
{"account": {"active-card": true, "available-limit": 100}}
{"transaction": {"merchant": "Burger King", "amount": 20, "time": "2019-02-13T10:00:00.000Z"}}
{"transaction": {"merchant": "Habbib's", "amount": 90, "time": "2019-02-13T11:00:00.000Z"}}
{"transaction": {"merchant": "McDonald's", "amount": 30, "time": "2019-02-13T12:00:00.000Z"}}