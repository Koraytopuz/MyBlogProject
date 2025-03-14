// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
.section {
    height: 100vh; /* Her bölümün yüksekliği tam ekran olacak */
    scroll - snap - align: start; /* Her bölümün başlangıcına hizalanacak */
}

html {
    scroll - snap - type: y mandatory; /* Dikey kaydırma ve zorunlu hizalama */
}

body {
    overflow - y: scroll; /* Dikey kaydırma etkin */
    scroll - behavior: smooth; /* Yumuşak kaydırma */
}
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();

        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});