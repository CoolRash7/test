package com.mygdx.gameobjects;

import com.mygdx.game.GameObject;
import com.mygdx.game.MyGdxGame;

public class Moon extends GameObject {

	public Moon(float x, float y, String path) {
		super(x, y, path);
		// TODO Auto-generated constructor stub
	}

	@Override
	public void update() {
		// TODO Auto-generated method stub
		
		rect.x = (float) (100 * -Math.cos(-MyGdxGame.angel))+MyGdxGame.earthX; 
		rect.y = (float) (100 * -Math.sin(-MyGdxGame.angel))+MyGdxGame.earthY;
	}

}
