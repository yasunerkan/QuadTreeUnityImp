# QuadTreeUnityImp

Problem: 
write a quadtree implementation for collision detection (rect & circle)
- spawn lots of entities in the world with varying sizes. when an entity bump into another, takes 1 damage. each entity has 5 health, when they die, spawn another entity in a random position within the tree.
- make a UI to give the player the ability to control the number of entities.
- possibility to activate debug rendering for quadtree.
-try to create as small garbage as possible.

optional/bonus:
- use ECS without the worker system to do the same implementation. compare the performance results. explain the difference.
- polish the feeling of the simulation. create particles on collisions, tween the spawning of entities, destroying, etc.
- polish the player UI controls. add feedback to buttons.
 
 Solution:
![QuadTreeUML1](https://user-images.githubusercontent.com/82117271/113933592-7297c080-97fd-11eb-8699-38e6d650c66f.PNG)
![QuadTreeUML2](https://user-images.githubusercontent.com/82117271/113933638-817e7300-97fd-11eb-8006-03175fb8c89a.PNG)
![QuadTreeMenu](https://user-images.githubusercontent.com/82117271/113932560-6d864180-97fc-11eb-8a19-331a4afb6702.PNG)
![QuadTreeDemo](https://user-images.githubusercontent.com/82117271/113932558-6cedab00-97fc-11eb-9ffe-f6805f659ccc.PNG)


Reference:

● https://www.integu.net/visitor-pattern/
● https://refactoring.guru/design-patterns/visitor
● https://medium.com/@ErkanYasun/factory-pattern-with-generics-f73432921f99
