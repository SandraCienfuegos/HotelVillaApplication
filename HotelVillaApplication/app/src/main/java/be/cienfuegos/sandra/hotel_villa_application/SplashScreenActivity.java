package be.cienfuegos.sandra.hotel_villa_application;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.os.Handler;

import org.androidannotations.annotations.AfterViews;
import org.androidannotations.annotations.EActivity;
import org.androidannotations.annotations.Fullscreen;


@SuppressLint("Registered")
@Fullscreen
@EActivity(R.layout.activity_splash_screen)
public class SplashScreenActivity extends Activity {

    public static final int SPLASH_SCREEN_OUT = 3000;

    @AfterViews
    protected void initView() {
        new Handler().postDelayed(new Runnable() {
            @Override
            public void run() {
                SignInActivity_.intent(SplashScreenActivity.this).start();
                finish();
            }
        }, SPLASH_SCREEN_OUT);
    }
}
