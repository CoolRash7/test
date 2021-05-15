package com.mygdx.game;

import java.util.Iterator;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Sprite;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.utils.Array;
import com.badlogic.gdx.utils.ScreenUtils;
import com.mygdx.gameobjects.Earth;
import com.mygdx.gameobjects.Mars;
import com.mygdx.gameobjects.Moon;
import com.mygdx.gameobjects.Sun;

public class MyGdxGame extends ApplicationAdapter {
	
	public enum State {
		PAUSE, RUN
	}
	
	//константы игровые ит д
	public static int WIDTH = 800;
	public static int HEIGHT = 640;
	public static float PI = 3.1416f;
	
	public static float angel = 0, earthX = 0, earthY = 0;
	private int i = 0;
	public State state;
	
	SpriteBatch batch;
	Texture imgButton;
	Sprite sprButton;
	
	Array<GameObject> handler;
	
	@Override
	public void create () {
		
		// batch типо аналог Graphics2D - отображает графику
		batch = new SpriteBatch();
		
		state = State.RUN;
		
		imgButton = new Texture("button.png");
		sprButton = new Sprite(imgButton);
		
		//handler - коллекция всех игровых объектов
		handler = new Array<GameObject>();
		
		// add добавляем туда эти объекты унаследованные gameobject
		handler.add(new Sun((int) WIDTH/2,(int) HEIGHT/2,"sun.png"));
		handler.add(new Moon(0,0,"moon.png"));
		handler.add(new Earth(0,0,"earth.png"));
		handler.add(new Mars(0,0,"mars.png"));
		
	}

	@Override
	public void render () {
		
		if (i > 360) i = 0;
		
		// reduis -> radian
		angel = i * (PI / 180);
		
		ScreenUtils.clear(0, 0, 0.1f, 1);
		batch.begin();
		
		
		Iterator<GameObject> iterator = handler.iterator();
		
		while (iterator.hasNext()) {
			GameObject tempObject = iterator.next();
			tempObject.update();
			tempObject.drawGameObject(batch);
		}
		
		batch.draw(imgButton,300, 50, 200, 40);
		
		batch.end();
		
		if (Gdx.input.isButtonPressed(Input.Keys.LEFT))
			if (mouseOver(Gdx.input.getX(), Gdx.graphics.getHeight() - Gdx.input.getY(), 300, 50, 200, 40)) {
				if (state == State.PAUSE)
					state = State.RUN;
				else
					state = State.PAUSE;

			}
		
		if (state == State.RUN)
		i++;
	}
	
	@Override
	public void dispose () {
		batch.dispose();
		handler.removeAll(handler, false);
		imgButton.dispose();
		
	}
	
	private boolean mouseOver(int mx, int my, int x, int y, int width, int height) {
		if (mx > x && mx < x + width) {
			if (my > y && my < y + height) {
				return true;
			} else return false;
		} else return false;
	}
}
