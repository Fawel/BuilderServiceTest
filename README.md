# BuilderServiceTest

Тестим сервис по получению данных из бд, для разных подтипов.
### Важные, наверное пункты
* Данные хранятся в базе (или типа "базой") через EF Core
* Класс возвращаемых конечных данных из билдера не совпадают с классами из контекста 
* Из базы получаем данные без трэкинга
* обновление через билдер, либо через модель (ещё не определено)
