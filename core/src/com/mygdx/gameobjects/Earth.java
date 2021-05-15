package com.mygdx.gameobjects;

import com.mygdx.game.GameObject;
import com.mygdx.game.MyGdxGame;

public class Earth extends GameObject {

	public Earth(float x, float y, String path) {
		super(x, y, path);
	}

	@Override
	public void update() {
		
		rect.x = (float) (200 * -Math.cos(MyGdxGame.angel)+ MyGdxGame.WIDTH/2); 
		rect.y = (float) (200 * -Math.sin(MyGdxGame.angel)+ MyGdxGame.HEIGHT/2);
		giveCoords();
	}
	
	public void giveCoords() {
		MyGdxGame.earthX = rect.x;
		MyGdxGame.earthY = rect.y;
	}

}
