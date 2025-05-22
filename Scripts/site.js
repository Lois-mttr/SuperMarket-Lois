// Main JavaScript file for the Supermercado MVC website

document.addEventListener('DOMContentLoaded', function () {
    // Initialize any components that need JavaScript
    initializeComponents();

    // Add smooth scrolling for anchor links
    addSmoothScrolling();

    // Add responsive navigation for mobile
    setupMobileNavigation();
});

function initializeComponents() {
    // Add any component initialization here
    console.log('Components initialized');
}

function addSmoothScrolling() {
    // Smooth scrolling for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                e.preventDefault();
                window.scrollTo({
                    top: target.offsetTop - 100,
                    behavior: 'smooth'
                });
            }
        });
    });
}

function setupMobileNavigation() {
    // Check if we need to create a mobile menu
    if (window.innerWidth <= 768) {
        const header = document.querySelector('header');
        const nav = header.querySelector('nav');

        // Create mobile menu button
        const mobileMenuBtn = document.createElement('button');
        mobileMenuBtn.className = 'mobile-menu-btn';
        mobileMenuBtn.innerHTML = '☰';
        mobileMenuBtn.setAttribute('aria-label', 'Toggle menu');

        // Insert button before nav
        header.querySelector('.container').insertBefore(mobileMenuBtn, nav);

        // Add click event to toggle menu
        mobileMenuBtn.addEventListener('click', function () {
            nav.classList.toggle('active');
            this.innerHTML = nav.classList.contains('active') ? '✕' : '☰';
        });

        // Add CSS for mobile menu
        const style = document.createElement('style');
        style.textContent = `
            .mobile-menu-btn {
                display: block;
                background: none;
                border: none;
                font-size: 1.5rem;
                cursor: pointer;
                margin-left: auto;
            }
            
            header .container {
                flex-wrap: wrap;
            }
            
            nav {
                display: none;
                width: 100%;
                margin-top: 1rem;
            }
            
            nav.active {
                display: block;
            }
            
            nav ul {
                flex-direction: column;
            }
            
            nav ul li {
                margin: 0.5rem 0;
            }
        `;
        document.head.appendChild(style);
    }
}