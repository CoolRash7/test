package com.mygdx.gameobjects;

import com.mygdx.game.GameObject;
import com.mygdx.game.MyGdxGame;

public class Mars extends GameObject {
	
	public Mars(float x, float y, String path) {
		super(x, y, path);
		// TODO Auto-generated constructor stub
	}

	@Override
	public void update() {
		// TODO Auto-generated method stub/*
		
		rect.x = (float) (200 * Math.cos(MyGdxGame.angel)+ MyGdxGame.WIDTH/2); 
		rect.y = (float) (200 * Math.sin(MyGdxGame.angel)+ MyGdxGame.HEIGHT/2); 
		
	}
	


	

}
