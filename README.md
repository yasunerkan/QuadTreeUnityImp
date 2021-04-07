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
![image](https://user-images.githubusercontent.com/82117271/113932224-08325080-97fc-11eb-813b-2a8b190c428e.png)
![image](https://user-images.githubusercontent.com/82117271/113932317-2304c500-97fc-11eb-8c6b-13eb635b2992.png)
![QuadTreeDemo](https://user-images.githubusercontent.com/82117271/113932558-6cedab00-97fc-11eb-9ffe-f6805f659ccc.PNG)
![QuadTreeMenu](https://user-images.githubusercontent.com/82117271/113932560-6d864180-97fc-11eb-8a19-331a4afb6702.PNG)

