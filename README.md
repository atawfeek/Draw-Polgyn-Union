# Non-Convex Polygons Boolean Operatons
Windows based application using .NET technologies to perform boolean operations on 2D non-convex polygons.

# Summary
Recently, I got an exciting chance to work on geometric algorithms, and to execute different operations on polygons especially the non-convex ones via .Net application wrapping the required algorithm.

This geometric app uses special custom algorithm to perform different operations on Polygons (currently Union is only supported).

# Application Objective
This app is divided to two parts.

- Part I: Draw Polygons
  App uses System.Drawing built-in library to draw polygons, each polygon is considered as list of vertixes which are represented in .Net as PointF which represents an ordered pair of floating-point x-and y-coordinates that defines a point in a 2D plane.
  App implements different mouse operations, which make it easy and straightforward to draw vertixes and edges to finally form polygons.

- Part II: Generate Union Polygon
  This is the main functino List<PointF> FindPolygonUnion(Polygons polygons) which performs the whole operation by taking two pairs polygons and then generates the union polygon by applying the custom algorithm in following section to collect union polygon vertixes which will form the union shape.

# Usage Instructions
- Use left mouse click to draw edges of your polygon.
- One left click to determine a vertix
- Double left click to finalize drawing polygon, accordingly app will connect starting point with ending point to complete polygon boundaries.
- Right click to erase a polygon

# Algorithm (Step-by-Step)
- Moving Counterclockwise
  Orient both polygons counterclockwise. (In other words, as you traverse the list of points representing the polygon, the points should move counterclockwise around the polygon.
- Starting Point
  Start at a vertex known to be on one polygon and not inside the other. This algorithm uses the leftmost vertex. Add that point to the union and call it the current_point.
- Move to Next Point
  Starting at the point added to the union, move to the next point along the polygon and:
  - See if the segment from the current_point to the polygon’s next vertex intersects any of the other polygon’s edges. If so, find the intersection that is closest to the current_point and:
    - Set current_point to the point of intersection and add it to the union.
    - Switch polygons so you’re now following the other polygon’s edges counterclockwise.
- Recusrsion
  Continue moving around the polygon edges until you return the starting point.

# User Story
As a user, I want to randomly generate two non-convex polygons.
 
•	I can generate two non-convex polygons successfully at a time.
•	I can perform one of the following main operations on the generated polygons:
  - Union

# Technologies
- Asp.Net Core
- Layerd Architecture  
  - Domain 
  - Model
  - Presentation   
  - Test
- Dependency Injection: **Unity**  
- Unit Test: **NUnit & Moq**
- Considered Design Patterns:
  - Lazy Loading Pattern
  - Simple Factory Pattern
- Considered Object-Oriented Principles
  - Single Responsibility
  - Open-Closed Principle