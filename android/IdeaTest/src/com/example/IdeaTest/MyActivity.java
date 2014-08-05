package com.example.IdeaTest;

import android.app.Activity;
import android.app.Fragment;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import com.example.IdeaTest.fragments.LoginFragment;

public class MyActivity extends Activity {

    private boolean isLargeDevice;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        isLargeDevice = getResources().getBoolean(R.bool.is_large);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item.getItemId() == R.id.activity_main_action1) {
            showLoginFragment();
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    private void showLoginFragment() {
        FragmentManager fm = getFragmentManager();

        LoginFragment loginFragment = new LoginFragment();
        if (isLargeDevice) {
            loginFragment.show(fm, "login");
        }
        else {
            FragmentTransaction ft = fm.beginTransaction();
            Fragment prev = fm.findFragmentByTag("login");
            if (prev != null) {
                ft.remove(prev);
            }
            try {
                ft.addToBackStack(null);
                ft.replace(R.id.activity_main_text_view, loginFragment, "login");
                ft.commit();
            }
            catch (Exception ex) {
                android.util.Log.e("MyActivity", ex.toString());
            }
        }
    }
}
