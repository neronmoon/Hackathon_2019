# Hack2019 Project

### Installation
```
cd <yours working dir>
git clone git@github.com:neronmoon/Hackathon_2019.git
cd Hackathon_2019
```

### Useful links
- [Link to design doc](http://example.com)
- [Link to issues project](https://github.com/neronmoon/Hackathon_2019/projects/1)


### Project structure

```
 /DesignData - ассеты, созданные из ScriptableObject с данными о гайплейных настройках. *Пример: Weapons/Buster.asset -- ассет с настройками бластера*
 /Materials - Все материалы, используемые в проекте
 /Models - Все модели, используемые в проекте
 /Prefabs - Все префабы, используемые в проекте
 /Rendering - ассеты для настройки рендеринга. *Пример: Post-processing Volume asset -- настройка пост-процессинга*
 /Sources - исходный код
 /Sources/DesignDataTypes - исходный код ScriptableObject, ассеты которых хранятся в /DesignData
 /Sources/Suport - исходный код не-гейплейных скриптов
```
Все файлы в проекте должны быть структурированы согласно данному списку (дополняется), но в первую очередь следует руководствоваться здравым смыслом.


## MagicaVoxel export issues!
1. При экспорте модели в obj формате возможен сдвиг pivot. Нужно исправлять в Blender
2. MagicaVoxel создает по полигону на каждый воксель, что далает модель совсем плохой для производительности рендеринга
#### Solutions
1. Необходимо оптимзировать модель и исправить ее pivot (origin) в blender. Видос как это делать [https://www.youtube.com/watch?v=5MY3rsq5JGw](https://www.youtube.com/watch?v=5MY3rsq5JGw)
2. Экспортировать из blender в fbx
3. Удалить obj файлы **(Файлы vox следует оставить на месте)**
