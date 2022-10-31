import math
import numpy as np

def calculateDistance(x,y,yaw,pitch,roll,altitude):
    horizontalAFOV=math.radians(121.2845)
    verticalAFOV=math.radians(90)
    yaw=math.radians(yaw)
    pitch=math.radians(pitch)
    roll=math.radians(roll)

    v=np.matrix([[2*y*math.tan(verticalAFOV/2)],[2*x*math.tan(horizontalAFOV/2)],[1]])
    print(v)
    
    rotz=np.matrix([[math.cos(yaw), -math.sin(yaw), 0], [math.sin(yaw), math.cos(yaw),0], [0,0,1]])
    roty=np.matrix([[math.cos(pitch), 0, math.sin(pitch)], [0, 1, 0], [-math.sin(pitch),0,math.cos(pitch)]])
    rotx=np.matrix([[1, 0, 0], [0, math.cos(roll),-math.sin(roll)], [0,math.sin(roll),math.cos(roll)]])
    
    v=np.matmul(rotz,v)
    v=np.matmul(rotx, v)
    v=np.matmul(roty, v)

    t=altitude/(v[2,0])
    xdirection = (t*v[0,0])
    ydirection = (t*v[1,0])

    vw = np.matrix([[xdirection],[ydirection],[altitude]])

    #rotz= np.matrix([[math.cos(yaw), -math.sin(yaw)], [math.sin(yaw),math.cos(yaw)]])
    #vw=np.matmul(rotz, vw)
    print (vw)

calculateDistance(-0.311006,-0.3249974,-70,50,-20,10)