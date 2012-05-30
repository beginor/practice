//
//  native-activity.c
//  AndroidNDK
//
//  Created by gdeic on 12-5-22.
//  Copyright (c) 2012年 __MyCompanyName__. All rights reserved.
//

#include <jni.h>
#include <errno.h>

#include <EGL/egl.h>
#include <GLES/gl.h>

#include <android/sensor.h>
#include <android/log.h>
#include <android_native_app_glue.h>

#define LOGI(...) ((void)__android_log_print(ANDROID_LOG_INFO, "native-activity", __VA_ARGS__))
#define LOGW(...) ((void)__android_log_print(ANDROID_LOG_WARN, "native-activity", __VA_ARGS__))

struct saved_state {
	float angle;
	int32_t x;
	int32_t y;
};

struct engine {
	struct android_app* app;
	
	ASensorManager* sensorManager;
	const ASensor* accelerometerSensor;
	ASensorEventQueue* sensorEventQueue;
	
	int animating;
	EGLDisplay display;
	EGLSurface surface;
	EGLContext context;
	int32_t width;
	int32_t height;
	struct saved_state state;
};

static int engine_init_display(struct engine* engine) {
	const EGLint attribs[] = {
		EGL_SURFACE_TYPE, EGL_WINDOW_BIT,
		EGL_BLUE_SIZE, 8,
		EGL_GREEN_SIZE, 8,
		EGL_RED_SIZE, 8
	};
	return 0;
}

static void engine_draw_frame(struct engine* engine) {
	
}

static void engine_term_display(struct engine* engine) {
	
}

static int32_t engine_handle_input(struct android_app* app, AInputEvent* event) {
	struct engine* engine = (struct engine*)app->userData;
	if (AInputEvent_getType(event) == AINPUT_EVENT_TYPE_MOTION) {
		engine->animating = 1;
		engine->state.x = AMotionEvent_getX(event, 0);
		engine->state.y = AMotionEvent_getY(event, 0);
		return 1;
	}
	return 0;
}

static void engine_handle_cmd(struct android_app* app, int32_t cmd) {
	struct engine* engine = (struct engine*)app->userData;
	switch (cmd) {
		case APP_CMD_SAVE_STATE:
			engine->app->savedState = malloc(sizeof(struct saved_state));
			*((struct saved_state*)engine->app->savedState) = engine->state;
			engine->app->savedStateSize = sizeof(struct saved_state);
			break;
		case APP_CMD_INIT_WINDOW:
			if (engine->app->window != NULL) {
				engine_init_display(engine);
				engine_draw_frame(engine);
			}
			break;
		case APP_CMD_TERM_WINDOW:
			engine_term_display(engine);
			break;
		case APP_CMD_GAINED_FOCUS:
			if (engine->accelerometerSensor != NULL) {
				ASensorEventQueue_enableSensor(engine->sensorEventQueue, engine-> accelerometerSensor);
				ASensorEventQueue_setEventRate(engine->sensorEventQueue, engine->accelerometerSensor, (1000L/60)*1000);
			}
			break;
		case APP_CMD_LOST_FOCUS:
			if (engine->accelerometerSensor != NULL) {
				ASensorEventQueue_disableSensor(engine->sensorEventQueue, engine->accelerometerSensor);
			}
			engine->animating = 0;
			engine_draw_frame(engine);
			break;
	}
}

void android_main(struct android_app* state) {
	struct engine engine;
	
	app_dummy();
	
	memset(&engine, 0, sizeof(engine));
	state->userData = &engine;
	state->onAppCmd = engine_handle_cmd;
	state->onInputEvent = engine_handle_input;
	engine.app = state;
	
	engine.sensorManager = ASensorManager_getInstance();
	engine.accelerometerSensor = ASensorManager_getDefaultSensor(engine.sensorManager, ASENSOR_TYPE_ACCELEROMETER);
	engine.sensorEventQueue = ASensorManager_createEventQueue(engine.sensorManager, state->looper, LOOPER_ID_USER, NULL, NULL);
	
	if (state->savedState != NULL) {
		engine.state = *(struct saved_state*)state->savedState;
	}
	
	while (1) {
		int ident;
		int events;
		struct android_poll_source* source;
		
		while ((ident = ALooper_pollAll(engine.animating ? 0 : -1, NULL, &events, (void**)source)) >= 0) {
			
			if (source != NULL) {
				source->process(state, source);
			}
			
			if (ident == LOOPER_ID_USER) {
				if (engine.accelerometerSensor != NULL) {
					ASensorEvent event;
					while (ASensorEventQueue_getEvents(engine.sensorEventQueue, &event, 1) > 0) {
						LOGI("accelerometer: x=%f, y=%f, z =%f",
							  event.acceleration.x, event.acceleration.y,
							  event.acceleration.z);
					}
				}
			}
			
			if (state->destroyRequested != 0) {
				engine_term_display(&engine);
				return;
			}
		}
		
		if (engine.animating) {
			engine.state.angle += 0.01f;
			if (engine.state.angle > 1) {
				engine.state.angle = 1;
			}
			
			engine_draw_frame(&engine);
		}
	}
}








