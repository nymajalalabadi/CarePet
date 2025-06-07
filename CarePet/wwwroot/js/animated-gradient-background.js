/**
 * AnimatedGradientBackground
 * 
 * This class creates a customizable animated radial gradient background with a subtle breathing effect.
 * Converted from React component to vanilla JavaScript for .NET MVC integration.
 */
class AnimatedGradientBackground {
    constructor(options = {}) {
        // Default configuration
        this.config = {
            startingGap: options.startingGap || 125,
            breathing: options.breathing !== undefined ? options.breathing : false,
            gradientColors: options.gradientColors || [
                "#0A0A0A",
                "#2979FF", 
                "#FF80AB",
                "#FF6D00",
                "#FFD600",
                "#00E676",
                "#3D5AFE"
            ],
            gradientStops: options.gradientStops || [35, 50, 60, 70, 80, 90, 100],
            animationSpeed: options.animationSpeed || 0.02,
            breathingRange: options.breathingRange || 5,
            topOffset: options.topOffset || 0,
            containerSelector: options.containerSelector || '.animated-gradient-bg'
        };

        // Validation
        if (this.config.gradientColors.length !== this.config.gradientStops.length) {
            throw new Error(
                `GradientColors and GradientStops must have the same length. ` +
                `Received gradientColors length: ${this.config.gradientColors.length}, ` +
                `gradientStops length: ${this.config.gradientStops.length}`
            );
        }

        this.container = null;
        this.animationFrame = null;
        this.width = this.config.startingGap;
        this.directionWidth = 1;
        this.isInitialized = false;
    }

    /**
     * Initialize the gradient background
     */
    init() {
        // Wait for DOM to be ready
        if (document.readyState === 'loading') {
            document.addEventListener('DOMContentLoaded', () => this.setupContainer());
        } else {
            this.setupContainer();
        }
    }

    /**
     * Setup the container element
     */
    setupContainer() {
        this.container = document.querySelector(this.config.containerSelector);
        
        if (!this.container) {
            console.error(`Container with selector "${this.config.containerSelector}" not found`);
            return;
        }

        // Apply initial styles
        this.container.style.position = 'fixed';
        this.container.style.top = '0';
        this.container.style.left = '0';
        this.container.style.width = '100%';
        this.container.style.height = '100%';
        this.container.style.zIndex = '-1';
        this.container.style.overflow = 'hidden';

        // Start animation
        this.startAnimation();
        this.isInitialized = true;

        // Trigger entrance animation
        this.container.classList.add('animated-gradient-bg');
    }

    /**
     * Start the breathing animation
     */
    startAnimation() {
        const animate = () => {
            // Breathing logic
            if (this.width >= this.config.startingGap + this.config.breathingRange) {
                this.directionWidth = -1;
            }
            if (this.width <= this.config.startingGap - this.config.breathingRange) {
                this.directionWidth = 1;
            }

            if (!this.config.breathing) {
                this.directionWidth = 0;
            }

            this.width += this.directionWidth * this.config.animationSpeed;

            // Generate gradient string
            const gradientStopsString = this.config.gradientStops
                .map((stop, index) => `${this.config.gradientColors[index]} ${stop}%`)
                .join(', ');

            const gradient = `radial-gradient(${this.width}% ${this.width + this.config.topOffset}% at 50% 20%, ${gradientStopsString})`;

            // Apply gradient
            if (this.container) {
                this.container.style.background = gradient;
            }

            this.animationFrame = requestAnimationFrame(animate);
        };

        this.animationFrame = requestAnimationFrame(animate);
    }

    /**
     * Stop the animation and cleanup
     */
    destroy() {
        if (this.animationFrame) {
            cancelAnimationFrame(this.animationFrame);
            this.animationFrame = null;
        }
        this.isInitialized = false;
    }

    /**
     * Update configuration and restart animation
     */
    updateConfig(newConfig) {
        this.destroy();
        this.config = { ...this.config, ...newConfig };
        
        if (this.container) {
            this.width = this.config.startingGap;
            this.directionWidth = 1;
            this.startAnimation();
        }
    }
}

// Auto-initialize when page loads
document.addEventListener('DOMContentLoaded', function() {
    // Create default instance
    window.gradientBackground = new AnimatedGradientBackground({
        breathing: true,
        animationSpeed: 0.02,
        breathingRange: 5,
        topOffset: 0
    });
    
    window.gradientBackground.init();
});

// Cleanup on page unload
window.addEventListener('beforeunload', function() {
    if (window.gradientBackground) {
        window.gradientBackground.destroy();
    }
}); 