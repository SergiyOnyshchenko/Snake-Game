# Snake-Game

Описание идеи
Игра в которой нам предстоит играть за змейку, которая ползет по трассе. Параллельно
нужно уворачиваться от препятствий и кушать человечков, подходящих по цвету.

Змея
● Движение змеи должно иметь физику как в референсе. То есть, хвост эластично
следует за головой примерно с той же скоростью и амплитудой
● У хвоста нет коллизий с другими объектами, он может врезаться в преграды. Чтобы
проиграть нужно врезаться головой или верхней частью туловища змеи
● Можно обойтись обычным кубом вместо змеи, за которым следуют другие кубы. Но
двигаться объект должен так же, как змея на гифке!

Трасса
● Длинный прямой участок дороги
● Никаких горок или углублений быть не должно, просто ровная поверхность
● По краям небольшие бортики, выделенные цветом
● Вывалиться за бортики в процессе прохождения уровня нельзя
Смена цвета
● Каждый N отрезок пути должен располагаться чек-поинт, который меняет цвет
нашей змее
● Всего цветов использовано 6-8
● Змея может есть только тех человечков, которые соответствуют ее цвету
● При столкновении с человечками другого цвета мы проигрываем и начинаем
уровень заново
● Человечков можно сделать на примитивах. Например, капсулами.
Препятствия
● Не обязательно использовать именно шары с шипами, можно обойтись преградами
из кубов или других простых моделек
● Препятствия обязательно должны читаться как преграды, которые нужно избегать
и стилистически подходить под референс

Поедание
● Есть можно только еду текущего цвета, иначе - проигрыш
● Змея засасывает в рот еду, которая находится в конусе перед ней
● Змея не может притянуть еду по бокам или оставленную позади от ее головы

Управление
Змея движется по координате Z (вперёд) самостоятельно. Смещение по оси X
(влево\вправо) должно происходить в место, где игрок держит палец на экране.

Кристаллы
● Помимо еды змея может пожирать кристаллы
● Подобранные кристаллы приплюсовываются к общему счету кристаллов в левом
верхнем углу экрана

Февер
● Если змея подряд съедает больше 3-ёх кристаллов, активируется февер
● В режиме “февер” змея перемещается в центр трассы, управлять ей становится
невозможно. Она съедает всё на своём пути (в том числе преграды) и движется в 3
раза быстрее
● Февер длится 5 секунд, после чего змея снова возвращается в обычное состояние
● После того, как февер закончился, счетчик кристаллов обнуляется.
Визуал
● Графика может состоять из примитивов, но по виду (цветогамма) должна быть
близка к гифке

Уровни
Нужно сделать 1 уровень длительностью в 40 секунд.