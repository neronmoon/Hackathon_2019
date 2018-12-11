# Hack2019 Project

### Installation
```
cd <yours working dir>
git clone git@github.com:neronmoon/Hackathon_2019.git
cd Hackathon_2019
git submodule init && git submodule update
```

### Useful links
- [Link to design doc](http://example.com)
- [Link to issues project](https://github.com/neronmoon/Hackathon_2019/projects/1)


### Project structure

```
 /DesignData - ассеты, созданные из ScriptableObject с данными о гайплейных настройках.
 /Materials - Все материалы, используемые в проекте
 /Models - Все модели, используемые в проекте
 /Prefabs - Все префабы, используемые в проекте
 /Plugins - Все плагины, используемые в проекте
 /Rendering - ассеты для настройки рендеринга.
 /Sources - исходный код
 /Sources/DesignDataTypes - исходный код ScriptableObject, ассеты которых хранятся в /DesignData
 /Sources/Suport - исходный код не-гейплейных скриптов
```
Все файлы в проекте должны быть структурированы согласно данному списку (дополняется), но в первую очередь следует руководствоваться здравым смыслом.

## Подключение плагинов
- Подключая плагин из AssetStore, после его импорта необходимо перенести папку плагина в /Plugins
- Подключая плагин из какого-либо git репозитория следует выполнять это используя подмодули: `git submodule add <repo url> Assets/Plugins/<Plugin Name>`

Пример подключения плагина из git:
```
git submodule add git@github.com:dbrizov/NaughtyAttributes.git Assets/Plugins/NaughtyAttributes
```

Больше о использовании submodules можно почитать [здесь](https://git-scm.com/book/ru/v1/%D0%98%D0%BD%D1%81%D1%82%D1%80%D1%83%D0%BC%D0%B5%D0%BD%D1%82%D1%8B-Git-%D0%9F%D0%BE%D0%B4%D0%BC%D0%BE%D0%B4%D1%83%D0%BB%D0%B8)


## MagicaVoxel export issues!
1. При экспорте модели в obj формате возможен сдвиг pivot. Нужно исправлять в Blender
2. MagicaVoxel создает по полигону на каждый воксель, что далает модель совсем плохой для производительности рендеринга
#### Solutions
1. Необходимо оптимзировать модель и исправить ее pivot (origin) в blender. Видос как это делать [https://www.youtube.com/watch?v=5MY3rsq5JGw](https://www.youtube.com/watch?v=5MY3rsq5JGw)
2. Экспортировать из blender в fbx
3. Удалить obj файлы **(Файлы vox следует оставить на месте)**
