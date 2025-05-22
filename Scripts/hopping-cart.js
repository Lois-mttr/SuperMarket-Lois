// Shopping cart functionality

document.addEventListener('DOMContentLoaded', function () {
    // Quantity controls in cart
    setupQuantityControls();

    // Update subtotals when quantity changes
    setupSubtotalUpdates();
});

function setupQuantityControls() {
    // Get all quantity decrease buttons
    const decreaseButtons = document.querySelectorAll('.quantity-decrease');

    // Get all quantity increase buttons
    const increaseButtons = document.querySelectorAll('.quantity-increase');

    // Add event listeners to decrease buttons
    decreaseButtons.forEach(button => {
        button.addEventListener('click', function () {
            const formId = this.getAttribute('data-form-id');
            const input = this.nextElementSibling;
            let value = parseInt(input.value);

            if (value > 1) {
                value--;
                input.value = value;
                updateSubtotal(input);
            }
        });
    });

    // Add event listeners to increase buttons
    increaseButtons.forEach(button => {
        button.addEventListener('click', function () {
            const formId = this.getAttribute('data-form-id');
            const input = this.previousElementSibling;
            let value = parseInt(input.value);

            if (value < 99) {
                value++;
                input.value = value;
                updateSubtotal(input);
            }
        });
    });
}

function setupSubtotalUpdates() {
    // Get all quantity inputs
    const quantityInputs = document.querySelectorAll('.quantity-cell input[type="number"]');

    // Add event listeners to inputs
    quantityInputs.forEach(input => {
        input.addEventListener('change', function () {
            updateSubtotal(this);
        });
    });
}

function updateSubtotal(input) {
    // Get the row
    const row = input.closest('tr');

    // Get the price cell
    const priceCell = row.querySelector('.price-cell');

    // Get the subtotal cell
    const subtotalCell = row.querySelector('.subtotal-cell');

    // Get the price (remove currency symbol and convert to number)
    const price = parseFloat(priceCell.textContent.replace(/[^0-9.-]+/g, ''));

    // Get the quantity
    const quantity = parseInt(input.value);

    // Calculate subtotal
    const subtotal = price * quantity;

    // Update subtotal cell
    subtotalCell.textContent = formatCurrency(subtotal);

    // Update total
    updateTotal();
}

function updateTotal() {
    // Get all subtotal cells
    const subtotalCells = document.querySelectorAll('.subtotal-cell');

    // Calculate total
    let total = 0;
    subtotalCells.forEach(cell => {
        total += parseFloat(cell.textContent.replace(/[^0-9.-]+/g, ''));
    });

    // Update total in summary
    const totalElement = document.querySelector('.summary-row.total span:last-child');
    if (totalElement) {
        totalElement.textContent = formatCurrency(total);
    }

    // Update subtotal in summary
    const subtotalElement = document.querySelector('.summary-row:first-child span:last-child');
    if (subtotalElement) {
        subtotalElement.textContent = formatCurrency(total);
    }
}

function formatCurrency(amount) {
    // Format the amount as currency
    return new Intl.NumberFormat('es-ES', {
        style: 'currency',
        currency: 'EUR'
    }).format(amount);
}