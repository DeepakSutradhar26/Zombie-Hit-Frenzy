# Zombie Hit Frenzy

## Project Overview

Built a top-down portrait mobile car game where the player drives a car and attempts to hit as many zombies as possible within a countdown timer.

## Technical Specifications

- **Engine** : Unity 6.3 LTS
- **Platform** : Android (Portrait)
- **View** : Top-Down (Orthographic)
- **Orientation** : Portrait Only
- **Target FPS** : >= 58 FPS
- **Input System** : Swipe/Drag Steer system like Hot Slide on play store
- **Physics Used** : Rigidbody-based car physics and ragdoll chains-based Zombies

## Controller Adaptation

The assests used for car driving system is unity Prometeo Car Controller and adaptations were made to make it like Hot Slide in play store

- **Existing Input Removal** : Removed existing accelerate, brake, left, right system. 

- **Swipe/Drag Input Addition** : By only using the existing $GoForward()$ function for accelerate and custom steering system. By using horzontal [-1, 1] and veritcal [-1, 1] I know the handle position of joystick and the code already contains steerAngle and steeringSystem. So, only using these twos, I had made the swipe control system.

- **Camera follow** : I made camera follow equals to car position + offset in $LateUpdate()$ method of unity.

## GamePlay & Loop

- **Start** : Timer starts with $N$ seconds which is configurable in inspector only.

- **Objective** : Try to hit as many zombies as possible before the timer ends.

- **End** : After timer ends, end screen pops up displaying current score and restart button.

## Zombie NPC & Ragdoll System

- **Wndering AI** : Made 7 waypoints (position on arena), 4 out of 7 will be randomly assinged to zombie on spawning them on random position.

- **Ragdoll System** : Initially zombie will be wandering in the arena with walking animation but after car hits them they will transition to active ragdoll physics.

- **Persistency** : Zombie will reamin in the arena for the remaining period of the game meaning they will not dspawn.

- **Respawn** : After getting hiy by car they will ragdoll and die and respawn after 2-3 seconds in the arena.

## UI Elements

- **Score Counter** : Score counter increments when car hits zombie.

- **Timer** : Indicates how many seconds are left before game ends.

- **FPS Rate** : Small number at right corner indicating FPS of game.

- **Restart** : End screen contains restart button which will reset the scene completely.

## Known Isuues & Limitations

- **Sudden FPS Drop** : At beginning their maybe fps drop because 10 zombies are going to be spawning but after that the fps will around average of 70 fps.

- **0.01% Chance Missed Hit** : I made a script called ZombieHit.cs at root of enemy but for collision detection and for nav surface, it also need the object to also have collider also therefore I used two 4 capsule colliders for detecting collision but the ragdoll chains also have collider but no ZombieHit.cs script so their can be $0.01\%$ chance that even the car had hit the zombie but collision not detected.

- **Enemy Detecton** : Their is no enemy detection system in the game so the car have to wander around to search for zombies. It feels like it is missing in the game so I stated it.

- **Portrait Mode Only** : The controls and counters looks enlarged in landscape mode because it is only made for portrait view of mobile.

## Third-Party Assets Used

- **Prometeo Car Controller** : Used for base physics and wheel alignment.

- **Stylized Zombie Model & Animations** : Used for all NPC visuals and movement states.