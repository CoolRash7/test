package com.mygdx.game;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Rectangle;

public abstract class GameObject {

	public Texture texture;
	public Rectangle rect;
	private float velY, velX;
	
	
	public GameObject(float x, float y, String path) {
		rect = new Rectangle();
		rect.x = x;
		rect.y = y;
		texture = new Texture(path);

		rect.height = 100;
		rect.width = 100;
	}
	
	public abstract void update();
	
	public void drawGameObject(SpriteBatch batch) {
		batch.draw(texture, rect.x, rect.y, rect.width, rect.height);
	}
	

	
	public float getX() {
		return rect.x;
	}


	public void setX(double d) {
		rect.x = (float)d;
	}


	public float getY() {
		return rect.y;
	}


	public void setY(double d) {
		rect.y = (float)d;
	}


	public float getVelY() {
		return velY;
	}


	public void setVelY(float velY) {
		this.velY = velY;
	}


	public float getVelX() {
		return velX;
	}


	public void setVelX(float velX) {
		this.velX = velX;
	}


	public float getWidth() {
		return rect.width;
	}


	public void setWidth(float width) {
		rect.width = width;
	}


	public float getHeight() {
		return rect.height;
	}


	public void setHeight(float height) {
		rect.height = height;
	}
	
	
}
