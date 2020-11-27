package alencar.daniel.e_stacionar;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;

public class MainActivity extends AppCompatActivity {
    WebView conteudo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        conteudo = findViewById(R.id.conteudo);
        conteudo.loadUrl("https://www.estacionar.somee.com/index.aspx");
        conteudo.setWebViewClient(new WebViewClient());
        WebSettings settings= conteudo.getSettings();
        settings.setJavaScriptEnabled(true);
        settings.setGeolocationEnabled(true);
    }

    @Override
    public void onBackPressed() {
        if(conteudo.canGoBack())
        {
            conteudo.goBack();
        }
        else {
            super.onBackPressed();
        }
    }
}