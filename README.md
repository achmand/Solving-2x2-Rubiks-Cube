# Solving a 2x2 Rubik's Cube using C#

## Introduction 

The Rubik’s 2x2x2 solver project allows you to play/solve a pocket cube inside a program. By using the buttons and drop down menus on the form, you can rotate the cube and change its colors. Once you click on solve the instructions would be shown in the list box located on the right side of the form. You must think of the cube in a 2-dimensional way, because this is how it is displayed in the program. 

![1](https://cloud.githubusercontent.com/assets/9870940/25029693/00511624-20c0-11e7-9374-00d321e90064.jpg)

From the programming aspect, the cube was constructed into a complex object. The pocket cube has 24 tiles in it. If all the 4 tiles in each face have a matching color the cube is solved. The main component of the object is; 

An array of colors which holds the current state of the cube. So, the array was made up of 24 colors each index with a color. 

![2](https://cloud.githubusercontent.com/assets/9870940/25029730/4a7a5486-20c0-11e7-87c2-6d3ba99a77f4.jpg)

![3](https://cloud.githubusercontent.com/assets/9870940/25029731/4a804328-20c0-11e7-85ec-f0654f6cbfde.jpg)

Black and white circle = White. This sequence will go on (As shown in the other representation of the cube with the number on it);

8 – 11 -> Red 
12 – 15 -> Yellow
16 – 19 -> Blue
20 – 21 -> Orange

As you can see in each index you have a color. In the example above you can see how the array looks like at the start (solved solution). Obviously, this goes on until the index is 23, because we start from 0 and need 24 to represent 24 tiles. 

The rotation is then done by changing colors in the array with each other. Obviously, there is a pattern that must be followed to achieve this. Just keep in mind that the colors are changed the index stay the same. Rotation can be made to each face on two directions clockwise and anti-clockwise. 

![4](https://cloud.githubusercontent.com/assets/9870940/25029741/675115a4-20c0-11e7-9280-501c49a195fb.jpg)

So basically, when the rotate button is clicked the colors inside the array are changed accordingly.

## How is the cube solved?

After you got a picture of how the cube is represented, now we can look at how the cube gets
From a jumbled state to a solved state. As I pointed out earlier the cube object is made up of an array of colors. Another property of type Boolean was added to the cube. I will come to this property later. When the cube calls the rotate method, it does not change its array of colors instead it will return a new cube with the changed array colors.

![5](https://cloud.githubusercontent.com/assets/9870940/25029757/9c7655dc-20c0-11e7-820b-50137c0dc1a2.jpg)

At this stage, we need to have another object that holds two cubes together with a direction and a face. Let’s call this object Edge. So, for now we have a cube object and an edge object. So if we apply left clockwise rotation we need to create a new Edge object. 
So, if we had to keep a record the rotation made by the cube, we would use this object Edge. 

Below is a record of the rotation applied in the previous point 

![6](https://cloud.githubusercontent.com/assets/9870940/25029770/bd51188c-20c0-11e7-9e1f-eae2f15fa59e.jpg)

So now we have a basic understanding of how the rotations are recorded and how the cube is represented. Now when you have a jumbled solution in the project and you click the solve button. The jumbled cube is passed through an operation where all the rotations are done to it. So, in the first iteration of the operation twelve new cubes are produced (6 Faces and 2 rotations 6*2 = 12). This will go on until a solved cube is found. So basically, it is solved by examining all possible rotation or until a solved cube is found. All the cubes are stored in a list. 

Once all twelve rotations are made from that cube, the cube is marked as visited. This operation will continue by getting another cube which is not visited and apply all rotations to it too (Then is marked as visited). For every new cube, there is also an edge that is created and stored in a list to keep track of how the cube turned from one state to another. 
Once a solution is found the edges are then examined using shortest route algorithms to get the path from the jumbled state to the solved state. 

Below is a diagram of how this operation works (Excluding the shortest path method)

![7](https://cloud.githubusercontent.com/assets/9870940/25029794/e74f796c-20c0-11e7-810b-33a0e2726605.jpg)

![8](https://cloud.githubusercontent.com/assets/9870940/25029795/e7515002-20c0-11e7-85c4-7e6c67360cad.jpg)

As you can see the starting jumbled state is the cube you are looking at after clicking the solve button. All rotations are done to that cube. If no cube is solved, another cube which is not visited will go through the same operation and 12 new cubes would be generated and that cube marked as visited. This goes on until a solved cube is found. 
This was a basic description of how the project work!





