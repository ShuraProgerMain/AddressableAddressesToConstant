Ассет добавляет в юнити окно AddressableAddressesToConstants.

>[!warning]
>Необходимые ассеты:
> - Addressables

Идея этого ассета в генерации классов с константами содержащими адреса ассетов. 
Каждая выбранная в окне группа равна 1 скрипту внутри которого будут константы для каждого объекта.

*Окно выбора групп: **Tools>AddressableAddressesToConstants***
![[Pasted image 20230721142759.png]]
*Те самые группы и файлы в них*
![[Pasted image 20230721142829.png]]

*После нажатия на кнопку **Generate Scripts** создаются 2 класса по пути:
**Assets/Scripts/AddressableExtensions/\[GroupName].cs***
![[Pasted image 20230721142855.png]]
![[Pasted image 20230721142913.png]]
