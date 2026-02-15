import { test, expect } from '@playwright/test';

test.describe('Admin Login', () => {
    test('should display login form', async ({ page }) => {
        await page.goto('/login');
        await expect(page.locator('app-login h2')).toContainText('Admin Portal Login');
        await expect(page.locator('input#username')).toBeVisible();
        await expect(page.locator('input#password')).toBeVisible();
        await expect(page.locator('button[type="submit"]')).toBeVisible();
    });

    test('should handle invalid login', async ({ page }) => {
        await page.goto('/login');
        await page.fill('input#username', 'wronguser');
        await page.fill('input#password', 'wrongpass');
        await page.click('button[type="submit"]');

        // Check for error message
        // Note: We might need to mock the API response for robustness if backend isn't running
        // For now assuming backend will return 401
        await expect(page.locator('.error-message')).toBeVisible();
        await expect(page.locator('.error-message')).toContainText('Login failed');
    });

    // We'll add success test later when backend user seeding is ready or mocked
});
