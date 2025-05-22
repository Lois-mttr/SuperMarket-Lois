// Dark mode toggle functionality

document.addEventListener('DOMContentLoaded', function () {
    const themeToggle = document.getElementById('theme-toggle');
    const darkModeStyles = document.getElementById('dark-mode-styles');

    // Check if user has a theme preference in localStorage
    const currentTheme = localStorage.getItem('theme') || 'light';

    // Apply the current theme
    if (currentTheme === 'dark') {
        document.body.classList.add('dark-mode');
        darkModeStyles.removeAttribute('disabled');
    }

    // Toggle theme when button is clicked
    themeToggle.addEventListener('click', function () {
        // Toggle dark mode class on body
        document.body.classList.toggle('dark-mode');

        // Toggle dark mode stylesheet
        if (document.body.classList.contains('dark-mode')) {
            darkModeStyles.removeAttribute('disabled');
            localStorage.setItem('theme', 'dark');

            // Set cookie for server-side rendering
            document.cookie = "theme=dark; path=/; max-age=31536000"; // 1 year
        } else {
            darkModeStyles.setAttribute('disabled', '');
            localStorage.setItem('theme', 'light');

            // Set cookie for server-side rendering
            document.cookie = "theme=light; path=/; max-age=31536000"; // 1 year
        }
    });
});