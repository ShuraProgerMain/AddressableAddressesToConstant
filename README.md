Ассет добавляет в юнити окно AddressableAddressesToConstants.

>[!warning]
>Необходимые ассеты:
> - Addressables

Идея этого ассета в генерации классов с константами содержащими адреса ассетов. 
Каждая выбранная в окне группа равна 1 скрипту внутри которого будут константы для каждого объекта.

*Окно выбора групп: **Tools>AddressableAddressesToConstants***
![Pasted image 20230721142759](https://github.com/ShuraProgerMain/AddressableAddressesToConstant/assets/67688368/5e1cc3af-52d5-48c1-9ff4-f9184d0d8429)

*Те самые группы и файлы в них*
![Pasted image 20230721142829](https://github.com/ShuraProgerMain/AddressableAddressesToConstant/assets/67688368/c0d95b5f-0905-4c7a-b820-6ea4c98fc4f1)

*После нажатия на кнопку **Generate Scripts** создаются 2 класса по пути:
**Assets/Scripts/AddressableExtensions/\[GroupName].cs***
![Pasted image 20230721142913](https://github.com/ShuraProgerMain/AddressableAddressesToConstant/assets/67688368/9ca4fe49-61db-4b23-8d65-70958e370109)
![Pasted image 20230721142855](https://github.com/ShuraProgerMain/AddressableAddressesToConstant/assets/67688368/1c10d2e6-1c62-49fb-b5b7-f0b7d25fad8a)
