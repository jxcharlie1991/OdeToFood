<?php

// autoload_static.php @generated by Composer

namespace Composer\Autoload;

class ComposerStaticInit351caab8f714ccdc35ea231003a8b9c6
{
    public static $classMap = array (
        'Composer\\InstalledVersions' => __DIR__ . '/..' . '/composer/InstalledVersions.php',
    );

    public static function getInitializer(ClassLoader $loader)
    {
        return \Closure::bind(function () use ($loader) {
            $loader->classMap = ComposerStaticInit351caab8f714ccdc35ea231003a8b9c6::$classMap;

        }, null, ClassLoader::class);
    }
}