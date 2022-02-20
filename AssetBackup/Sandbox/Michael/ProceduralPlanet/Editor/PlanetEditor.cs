using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Procedural
{
    [CustomEditor(typeof(PlanetTerrain))]
    public class PlanetEditor : Editor
    {
        PlanetTerrain planet;
        Editor shapeEditor;
        Editor colourEditor;

        public override void OnInspectorGUI()
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                base.OnInspectorGUI();
                if (check.changed)
                {
                    planet.GeneratePlanet();
                }
            }

            if (GUILayout.Button("Generate Planet"))
            {
                planet.GeneratePlanet();
            }

            DrawSettingsEditor(planet.shapeSetting, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldout, ref shapeEditor);
            DrawSettingsEditor(planet.colorSetting, planet.OnColorSettingsUpdated, ref planet.colorSettingsFoldout, ref colourEditor);
        }

        void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor)
        {
            if (settings != null)
            {
                foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
                using (var check = new EditorGUI.ChangeCheckScope())
                {
                    if (foldout)
                    {
                        CreateCachedEditor(settings, null, ref editor);
                        editor.OnInspectorGUI();

                        if (check.changed)
                        {
                            if (onSettingsUpdated != null)
                            {
                                onSettingsUpdated();
                            }
                        }
                    }
                }
            }
        }

        private void OnEnable()
        {
            planet = (PlanetTerrain)target;
        }
    }
}
